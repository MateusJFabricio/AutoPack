namespace OrganizadorGeometrico
{
    partial class Form_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarOrganizadorAutomaticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarDXFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpFigurasGeometricas = new System.Windows.Forms.GroupBox();
            this.dgvArquivos = new System.Windows.Forms.DataGridView();
            this.Arquivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoverFigurasGeometricas = new System.Windows.Forms.Button();
            this.btnImportarFigurasGeometricas = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoverPlanoGeometrico = new System.Windows.Forms.Button();
            this.btnImportarPlanoGeometrico = new System.Windows.Forms.Button();
            this.txtNomePlacaGravacao = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbVisaoGrafica = new System.Windows.Forms.PictureBox();
            this.Resultados = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtResultados = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpFigurasGeometricas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArquivos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisaoGrafica)).BeginInit();
            this.Resultados.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1122, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarOrganizadorAutomaticoToolStripMenuItem,
            this.configuracoesToolStripMenuItem,
            this.exportarDXFToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // iniciarOrganizadorAutomaticoToolStripMenuItem
            // 
            this.iniciarOrganizadorAutomaticoToolStripMenuItem.Name = "iniciarOrganizadorAutomaticoToolStripMenuItem";
            this.iniciarOrganizadorAutomaticoToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.iniciarOrganizadorAutomaticoToolStripMenuItem.Text = "Iniciar Organizador Automatico";
            this.iniciarOrganizadorAutomaticoToolStripMenuItem.Click += new System.EventHandler(this.IniciarOrganizadorAutomaticoToolStripMenuItem_Click);
            // 
            // configuracoesToolStripMenuItem
            // 
            this.configuracoesToolStripMenuItem.Name = "configuracoesToolStripMenuItem";
            this.configuracoesToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.configuracoesToolStripMenuItem.Text = "Configuracoes";
            // 
            // exportarDXFToolStripMenuItem
            // 
            this.exportarDXFToolStripMenuItem.Name = "exportarDXFToolStripMenuItem";
            this.exportarDXFToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.exportarDXFToolStripMenuItem.Text = "Exportar DXF";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creditosToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // creditosToolStripMenuItem
            // 
            this.creditosToolStripMenuItem.Name = "creditosToolStripMenuItem";
            this.creditosToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.creditosToolStripMenuItem.Text = "Creditos";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpFigurasGeometricas);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.Resultados);
            this.splitContainer1.Size = new System.Drawing.Size(1122, 618);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 2;
            // 
            // gpFigurasGeometricas
            // 
            this.gpFigurasGeometricas.Controls.Add(this.dgvArquivos);
            this.gpFigurasGeometricas.Controls.Add(this.btnRemoverFigurasGeometricas);
            this.gpFigurasGeometricas.Controls.Add(this.btnImportarFigurasGeometricas);
            this.gpFigurasGeometricas.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpFigurasGeometricas.Location = new System.Drawing.Point(0, 138);
            this.gpFigurasGeometricas.Name = "gpFigurasGeometricas";
            this.gpFigurasGeometricas.Size = new System.Drawing.Size(373, 479);
            this.gpFigurasGeometricas.TabIndex = 2;
            this.gpFigurasGeometricas.TabStop = false;
            this.gpFigurasGeometricas.Text = "Figuras Geometricas";
            // 
            // dgvArquivos
            // 
            this.dgvArquivos.AllowUserToAddRows = false;
            this.dgvArquivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArquivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Arquivos});
            this.dgvArquivos.Location = new System.Drawing.Point(17, 29);
            this.dgvArquivos.Name = "dgvArquivos";
            this.dgvArquivos.ReadOnly = true;
            this.dgvArquivos.Size = new System.Drawing.Size(343, 388);
            this.dgvArquivos.TabIndex = 6;
            // 
            // Arquivos
            // 
            this.Arquivos.HeaderText = "Arquivos";
            this.Arquivos.Name = "Arquivos";
            this.Arquivos.ReadOnly = true;
            this.Arquivos.Width = 300;
            // 
            // btnRemoverFigurasGeometricas
            // 
            this.btnRemoverFigurasGeometricas.Location = new System.Drawing.Point(171, 433);
            this.btnRemoverFigurasGeometricas.Name = "btnRemoverFigurasGeometricas";
            this.btnRemoverFigurasGeometricas.Size = new System.Drawing.Size(122, 40);
            this.btnRemoverFigurasGeometricas.TabIndex = 5;
            this.btnRemoverFigurasGeometricas.Text = "Remover";
            this.btnRemoverFigurasGeometricas.UseVisualStyleBackColor = true;
            this.btnRemoverFigurasGeometricas.Click += new System.EventHandler(this.BtnRemoverFigurasGeometricas_Click);
            // 
            // btnImportarFigurasGeometricas
            // 
            this.btnImportarFigurasGeometricas.Location = new System.Drawing.Point(33, 433);
            this.btnImportarFigurasGeometricas.Name = "btnImportarFigurasGeometricas";
            this.btnImportarFigurasGeometricas.Size = new System.Drawing.Size(110, 40);
            this.btnImportarFigurasGeometricas.TabIndex = 4;
            this.btnImportarFigurasGeometricas.Text = "Importar";
            this.btnImportarFigurasGeometricas.UseVisualStyleBackColor = true;
            this.btnImportarFigurasGeometricas.Click += new System.EventHandler(this.BtnImportarFigurasGeometricas_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRemoverPlanoGeometrico);
            this.groupBox1.Controls.Add(this.btnImportarPlanoGeometrico);
            this.groupBox1.Controls.Add(this.txtNomePlacaGravacao);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plano Geometrico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do Arquivo";
            // 
            // btnRemoverPlanoGeometrico
            // 
            this.btnRemoverPlanoGeometrico.Enabled = false;
            this.btnRemoverPlanoGeometrico.Location = new System.Drawing.Point(191, 72);
            this.btnRemoverPlanoGeometrico.Name = "btnRemoverPlanoGeometrico";
            this.btnRemoverPlanoGeometrico.Size = new System.Drawing.Size(164, 60);
            this.btnRemoverPlanoGeometrico.TabIndex = 3;
            this.btnRemoverPlanoGeometrico.Text = "Remover";
            this.btnRemoverPlanoGeometrico.UseVisualStyleBackColor = true;
            this.btnRemoverPlanoGeometrico.Click += new System.EventHandler(this.BtnRemoverPlanoGeometrico_Click);
            // 
            // btnImportarPlanoGeometrico
            // 
            this.btnImportarPlanoGeometrico.Location = new System.Drawing.Point(20, 72);
            this.btnImportarPlanoGeometrico.Name = "btnImportarPlanoGeometrico";
            this.btnImportarPlanoGeometrico.Size = new System.Drawing.Size(165, 60);
            this.btnImportarPlanoGeometrico.TabIndex = 2;
            this.btnImportarPlanoGeometrico.Text = "Importar";
            this.btnImportarPlanoGeometrico.UseVisualStyleBackColor = true;
            this.btnImportarPlanoGeometrico.Click += new System.EventHandler(this.BtnImportarPlanoGeometrico_Click);
            // 
            // txtNomePlacaGravacao
            // 
            this.txtNomePlacaGravacao.BackColor = System.Drawing.Color.White;
            this.txtNomePlacaGravacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomePlacaGravacao.Location = new System.Drawing.Point(20, 36);
            this.txtNomePlacaGravacao.Name = "txtNomePlacaGravacao";
            this.txtNomePlacaGravacao.ReadOnly = true;
            this.txtNomePlacaGravacao.Size = new System.Drawing.Size(335, 23);
            this.txtNomePlacaGravacao.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbVisaoGrafica);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(745, 446);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visao Grafica";
            // 
            // pbVisaoGrafica
            // 
            this.pbVisaoGrafica.BackColor = System.Drawing.Color.Silver;
            this.pbVisaoGrafica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbVisaoGrafica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVisaoGrafica.Location = new System.Drawing.Point(3, 16);
            this.pbVisaoGrafica.Name = "pbVisaoGrafica";
            this.pbVisaoGrafica.Size = new System.Drawing.Size(739, 427);
            this.pbVisaoGrafica.TabIndex = 2;
            this.pbVisaoGrafica.TabStop = false;
            // 
            // Resultados
            // 
            this.Resultados.Controls.Add(this.panel1);
            this.Resultados.Controls.Add(this.label2);
            this.Resultados.Controls.Add(this.progressBar1);
            this.Resultados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Resultados.Location = new System.Drawing.Point(0, 446);
            this.Resultados.Name = "Resultados";
            this.Resultados.Size = new System.Drawing.Size(745, 172);
            this.Resultados.TabIndex = 1;
            this.Resultados.TabStop = false;
            this.Resultados.Text = "Resultados";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtResultados);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 119);
            this.panel1.TabIndex = 4;
            // 
            // rtResultados
            // 
            this.rtResultados.BackColor = System.Drawing.Color.White;
            this.rtResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtResultados.Location = new System.Drawing.Point(0, 0);
            this.rtResultados.Name = "rtResultados";
            this.rtResultados.ReadOnly = true;
            this.rtResultados.Size = new System.Drawing.Size(739, 119);
            this.rtResultados.TabIndex = 1;
            this.rtResultados.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(3, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Progresso:";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 148);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(739, 21);
            this.progressBar1.TabIndex = 2;
            // 
            // Form_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 642);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Principal";
            this.Text = "Organizador Automatico";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpFigurasGeometricas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArquivos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVisaoGrafica)).EndInit();
            this.Resultados.ResumeLayout(false);
            this.Resultados.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarOrganizadorAutomaticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracoesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditosToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gpFigurasGeometricas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoverPlanoGeometrico;
        private System.Windows.Forms.Button btnImportarPlanoGeometrico;
        private System.Windows.Forms.TextBox txtNomePlacaGravacao;
        private System.Windows.Forms.Button btnRemoverFigurasGeometricas;
        private System.Windows.Forms.Button btnImportarFigurasGeometricas;
        private System.Windows.Forms.GroupBox Resultados;
        private System.Windows.Forms.ToolStripMenuItem exportarDXFToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvArquivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arquivos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtResultados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pbVisaoGrafica;
    }
}

