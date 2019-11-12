using OrganizadorGeometrico.Controller;
using OrganizadorGeometrico.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OrganizadorGeometrico
{
    public partial class Form_Principal : Form
    {
        private string diretorioPlacaGravacao;
        private List<string> diretoriosFigurasGeometricas = new List<string>();
        private DXFController control = new DXFController();
        private bool moverHabilitado = false;
        private bool zoomHabilitado = false;
        private bool transformarFigura;
        private float zoom = 1.1f, offsetX = 0f, offsetY = 0f;
        private int mousePosX = 0, mousePosY = 0;
        private bool figurasOrdenadas = false;
        private bool figurasOrganizadas = false;

        public Form_Principal()
        {
            InitializeComponent();
        }

        private void BtnImportarPlanoGeometrico_Click(object sender, EventArgs e)
        {

            //Abre o gerenciador de arquivo
            var arquivo = AbrirDXF(false);

            //Caso o usuario tenha selecionado um arquivo valido
            if (arquivo.Count > 0)
            {
                progressBar.Value = 0;
                try
                {
                    //Limpa a tela
                    pbVisaoGrafica.BackgroundImage = new Bitmap(1, 1);
                    pbVisaoGrafica.Refresh();

                    //Pega o arquivo
                    diretorioPlacaGravacao = arquivo[0];
                    string nomeComExtensao = Path.GetFileName(arquivo[0]);
                    txtNomePlacaGravacao.Text = nomeComExtensao.Substring(0, nomeComExtensao.ToUpper().IndexOf(".DXF"));

                    //Cria o objeto DXF e carrega o bitmap
                    Bitmap bm = control.AdicionarPlacaGravacao(diretorioPlacaGravacao);
                    pbVisaoGrafica.BackgroundImage = bm;
                    pbVisaoGrafica.Refresh();

                    //Carrega as informacoes do objeto
                    lblInformacaoPlanoGeometrico.Text = "Area: " + control.figuraGeometricaAtual.Area + " mm2 ";
                    lblInformacaoPlanoGeometrico.Text += ", Altura: " + control.figuraGeometricaAtual.Altura + " mm ";
                    lblInformacaoPlanoGeometrico.Text += ", Largura: " + control.figuraGeometricaAtual.Largura + " mm ";

                    //Desabilita o botao de importar
                    btnImportarPlanoGeometrico.Enabled = false;
                    btnRemoverPlanoGeometrico.Enabled = true;
                    btnVisualizarPlanoGeometrico.Enabled = true;

                    //Atualiza as informacoes de Zoom
                    zoom = 1f;
                    offsetX = 0f;
                    offsetY = 0f;

                    //Bitmap bm = control.ResizeFiguraAtual(zoom, offsetX, offsetY, pbVisaoGrafica.Width, pbVisaoGrafica.Height);
                    //pbVisaoGrafica.BackgroundImage = bm;
                    //pbVisaoGrafica.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtNomePlacaGravacao.Text = "";
                }

            }
        }
        

        private void BtnRemoverPlanoGeometrico_Click(object sender, EventArgs e)
        {
            diretorioPlacaGravacao = "";
            //Desabilita o botao de importar
            btnImportarPlanoGeometrico.Enabled = true;
            btnRemoverPlanoGeometrico.Enabled = false;
            btnVisualizarPlanoGeometrico.Enabled = false;

            //Remove o nome do arquivo
            txtNomePlacaGravacao.Text = "";
            lblInformacaoPlanoGeometrico.Text = "Nenhum plano carregado";

            //Remove a placa de gravacao
            control.RemoverPlacaGravacao();
        }

        private void BtnImportarFigurasGeometricas_Click(object sender, EventArgs e)
        {
            figurasOrdenadas = false;

            foreach (var item in AbrirDXF(true))
            {
                control.AdicionarFiguraGeometrica(item);

                AdicionarFiguraDataGridView(control.figuraGeometricaAtual);

                //control.ResizeFiguraAtual(zoom, offsetX, offsetY, pbVisaoGrafica.Width, pbVisaoGrafica.Height);
            }
            progressBar.Value = 0;
            zoom = 1f;
            offsetX = 0f;
            offsetY = 0f;
        }

        private void AdicionarFiguraDataGridView(DXFItem figura)
        {
            dgvArquivos.Rows.Add(figura.id.ToString(),
                    figura.nome,
                    figura.Ordem.ToString(),
                    figura.Area.ToString(),
                    figura.Largura.ToString(),
                    figura.Altura.ToString()
                    );
        }

        private List<string> AbrirDXF(bool multiFile)
        {
            List<string> arquivosValidos = new List<string>();
            List<string> arquivosInvalidos = new List<string>();
            string mensagem = "Arquivos Invalidos: " + Environment.NewLine;
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "DXF (*.dxf)|*.dxf";
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.Multiselect = multiFile;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (var arquivo in openFile.FileNames)
                {
                    if (control.ValidarArquivoDXF(openFile.FileName))
                        arquivosValidos.Add(arquivo);
                    else
                        arquivosInvalidos.Add(NomeArquivo(arquivo));
                }
            }

            foreach (var ai in arquivosInvalidos)
            {
                mensagem += ai;
            }

            if (arquivosInvalidos.Count > 0)
                MessageBox.Show(mensagem);

            return arquivosValidos;
        }

        private string NomeArquivo(string path)
        {
            string nomeComExtensao = Path.GetFileName(path);
            return nomeComExtensao.Substring(0, nomeComExtensao.ToUpper().IndexOf(".DXF"));
        }

        private void BtnRemoverFigurasGeometricas_Click(object sender, EventArgs e)
        {
            figurasOrdenadas = false; 
            if (dgvArquivos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecione ao menos uma linha para excluir");
                return;
            }

            foreach (DataGridViewRow item in dgvArquivos.SelectedRows)
            {
                control.RemoverFiguraGeometrica(Convert.ToInt32(item.Cells[0].Value));
                dgvArquivos.Rows.RemoveAt(item.Index);
            }

        }

        private void IniciarOrganizadorAutomaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            
            //Ordena de acordo com o que esta selecionado
            if (!figurasOrdenadas && control.figurasGeometricas.Count > 1)
            {
                MessageBox.Show("Voce deve ordenar as figuras geometricas antes");
                return;
            }

            try
            {
                figurasOrganizadas = false;
                rtResultados.Clear();
                stopwatch.Start();
                timerProgressbar.Start();

                Bitmap bm = control.IniciarOrganizador();
                pbVisaoGrafica.BackgroundImage = bm;
                pbVisaoGrafica.Refresh();

                figurasOrganizadas = control.FigurasOrganizadas;
                stopwatch.Stop();
                rtResultados.AppendText($"Tempo total de execucao do algoritmo: {stopwatch.Elapsed.TotalSeconds} segundos" + Environment.NewLine);
            } catch (Exception ex)
            {
                figurasOrganizadas = false;
                timerProgressbar.Stop();
                stopwatch.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            btnMover.UseVisualStyleBackColor = false;
            btnZoom.UseVisualStyleBackColor = true;
            moverHabilitado = true;
            zoomHabilitado = false;
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            btnZoom.UseVisualStyleBackColor = false;
            btnMover.UseVisualStyleBackColor = true;
            moverHabilitado = false;
            zoomHabilitado = true;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (dgvArquivos.SelectedRows.Count < 1)
            {
                MessageBox.Show("Selecione a linha da figura geometrica");
                return;
            }

            if (dgvArquivos.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecione somente uma figura geometrica");
                return;
            }

            int idFigura = Convert.ToInt32(dgvArquivos.SelectedRows[0].Cells[0].Value);
            Bitmap bitmap = control.VisualizarFiguraGeometrica(idFigura);
            pbVisaoGrafica.BackgroundImage = bitmap;
            pbVisaoGrafica.Refresh();

            //Tamanho normal
            zoom = 1f;
            offsetX = 0f;
            offsetY = 0f;
        }

        private void btnVisualizarPlanoGeometrico_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = control.VisualizarPlanoGeomtrico();
            pbVisaoGrafica.BackgroundImage = bitmap;
            pbVisaoGrafica.Refresh();

            //Tamanho normal
            zoom = 1f;
            offsetX = 0f;
            offsetY = 0f;

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (rbArea.Checked)
            {
                control.OrganizarFigurasArea();
            }
            else if (rbAltura.Checked)
            {
                control.OrganizarFigurasAltura();
            }
            else if (rbLargura.Checked)
            {
                control.OrganizarFigurasLargura();
            }
            else if (rbCustomizada.Checked)
            {
                control.OrganizarFigurasOrdemCustomizada();
            }
            else
            {
                MessageBox.Show("Selecione um tipo de ordenacao");
                return;
            }

            //Popula o data grid view
            dgvArquivos.Rows.Clear();
            foreach (var figura in control.figurasGeometricas)
            {
                AdicionarFiguraDataGridView(figura);
            }

            figurasOrdenadas = true;
        }

        private void dgvArquivos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int valor = 0;
                if (Int32.TryParse(dgvArquivos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out valor))
                {
                    for (int i = 0; i < control.figurasGeometricas.Count; i++)
                    {
                        if (control.figurasGeometricas[i].id.ToString() == dgvArquivos.Rows[e.RowIndex].Cells[0].Value.ToString())
                        {
                            control.figurasGeometricas[i].Ordem = valor;
                        }
                    }
                }else
                {
                    dgvArquivos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    MessageBox.Show("Somente valor numero aceito");
                }
            }
        }

        private void timerResultados_Tick(object sender, EventArgs e)
        {
            int qntMensagens = control.mensagens.Count;

            for (int i = 0; i < qntMensagens; i++)
            {
                rtResultados.AppendText(control.mensagens.Dequeue() + Environment.NewLine);
            }
        }

        private void exportarDXFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (figurasOrganizadas)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "DXF (*.dxf)|*.dxf";
                saveFile.Title = "Exportar resultado";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    control.ExportarResultado(saveFile.FileName);
                    rtResultados.AppendText("Figura exportada para o caminho " + saveFile.FileName);
                    Process.Start(saveFile.FileName);
                }
            }
            else
                MessageBox.Show("Nao ha o que exportar! Execute o algoritmo de organizacao");
        }

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            if (figurasOrganizadas)
            {
                progressBar.Value = 100;
                timerProgressbar.Stop();
                return;
            }

            switch (control.FigurasProcessadas)
            {
                case 0:
                    progressBar.Value = 0;
                    break;
                case 1:
                    progressBar.Value = 25;
                    break;
                case 2:
                    progressBar.Value = 50;
                    break;
                case 3:
                    progressBar.Value = 75;
                    break;
                case 4:
                    progressBar.Value = 100;
                    timerProgressbar.Stop();
                    break;
                default:
                    break;
            }
        }

        private void pbVisaoGrafica_MouseDown(object sender, MouseEventArgs e)
        {
            transformarFigura = true;
            mousePosX = e.X;
            mousePosY = e.Y;
        }

        private void pbVisaoGrafica_MouseUp(object sender, MouseEventArgs e)
        {
            transformarFigura = false;
        }

        private void pbVisaoGrafica_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (control.figuraGeometricaAtual != null))
            {
                if (zoomHabilitado)
                {
                    if (mousePosX < e.X)
                        zoom-=0.1f;
                    else
                        zoom+=0.1f;

                }
                
                if (moverHabilitado)
                {
                    if (mousePosX < e.X)
                        offsetX += 1f;
                    else if (mousePosX > e.X)
                        offsetX -= 1f;

                    if (mousePosY < e.Y)
                        offsetY += 1f;
                    else if (mousePosY > e.Y)
                        offsetY -= 1f;

                }

                mousePosX = e.X;
                mousePosY = e.Y;

                Bitmap bm = control.ResizeFiguraAtual(zoom, offsetX, offsetY, pbVisaoGrafica.Width, pbVisaoGrafica.Height);
                pbVisaoGrafica.BackgroundImage = bm;
                pbVisaoGrafica.Refresh();
            }
        }
    }


}
