using OrganizadorGeometrico.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OrganizadorGeometrico
{
    public partial class Form_Principal : Form
    {
        private string diretorioPlacaGravacao;
        private List<string> diretoriosFigurasGeometricas = new List<string>();
        private DXFController control = new DXFController();

        public Form_Principal()
        {
            InitializeComponent();
        }

        private void BtnImportarPlanoGeometrico_Click(object sender, EventArgs e)
        {
            var arquivo = AbrirDXF(false);
            if (arquivo.Count > 0)
            {
                diretorioPlacaGravacao = arquivo[0];
                string nomeComExtensao = Path.GetFileName(arquivo[0]);
                txtNomePlacaGravacao.Text = nomeComExtensao.Substring(0, nomeComExtensao.ToUpper().IndexOf(".DXF"));

                //Desabilita o botao de importar
                btnImportarPlanoGeometrico.Enabled = false;
                btnRemoverPlanoGeometrico.Enabled = true;
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
            }
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

        }
    }
}
