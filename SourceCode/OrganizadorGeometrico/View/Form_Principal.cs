using OrganizadorGeometrico.Controller;
using System;
using System.Collections.Generic;
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
                diretorioPlacaGravacao = arquivo[0];
                string nomeComExtensao = Path.GetFileName(arquivo[0]);
                txtNomePlacaGravacao.Text = nomeComExtensao.Substring(0, nomeComExtensao.ToUpper().IndexOf(".DXF"));
                Bitmap bm = control.AdicionarPlacaGravacao(diretorioPlacaGravacao, pbVisaoGrafica.Width, pbVisaoGrafica.Height);
                pbVisaoGrafica.BackgroundImage = bm;
                pbVisaoGrafica.Refresh();
                //Desabilita o botao de importar
                btnImportarPlanoGeometrico.Enabled = false;
                btnRemoverPlanoGeometrico.Enabled = true;
                zoom = 1f;
                offsetX = 0f;
                offsetY = 0f;
            }
        }
        

        private void BtnRemoverPlanoGeometrico_Click(object sender, EventArgs e)
        {
            diretorioPlacaGravacao = "";
            //Desabilita o botao de importar
            btnImportarPlanoGeometrico.Enabled = true;
            btnRemoverPlanoGeometrico.Enabled = false;

            //Remove o nome do arquivo
            txtNomePlacaGravacao.Text = "";
        }

        private void BtnImportarFigurasGeometricas_Click(object sender, EventArgs e)
        {
            foreach (var item in AbrirDXF(true))
            {
                dgvArquivos.Rows.Add(NomeArquivo(item));
                control.AdicionarFiguraGeometrica(item, pbVisaoGrafica.Width, pbVisaoGrafica.Height);
            }
            zoom = 1f;
            offsetX = 0f;
            offsetY = 0f;
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

            foreach (DataGridViewRow item in dgvArquivos.SelectedRows)
            {
                dgvArquivos.Rows.RemoveAt(item.Index);
            }

            foreach (DataGridViewCell oneCell in dgvArquivos.SelectedCells)
            {
                if (oneCell.Selected)
                    dgvArquivos.Rows.RemoveAt(oneCell.RowIndex);
            }

        }

        private void IniciarOrganizadorAutomaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control.IniciarOrganizador();
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
