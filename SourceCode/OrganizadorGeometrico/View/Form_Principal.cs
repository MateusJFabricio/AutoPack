using OrganizadorGeometrico.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizadorGeometrico
{
    public partial class Form_Principal : Form
    {
        private DXF dxf;

        public Form_Principal()
        {
            //dxf = new DXF();
            //dxf.Teste();
            InitializeComponent();
        }

        private void BtnImportarPlanoGeometrico_Click(object sender, EventArgs e)
        {
            //FileDialog fileDialog;
            //fileDialog.ShowDialog();
        }

        private void BtnRemoverPlanoGeometrico_Click(object sender, EventArgs e)
        {

        }
    }
}
