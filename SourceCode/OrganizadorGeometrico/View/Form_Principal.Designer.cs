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
            this.exportarDXFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpFigurasGeometricas = new System.Windows.Forms.GroupBox();
            this.dgvArquivos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Largura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Altura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAltura = new System.Windows.Forms.RadioButton();
            this.rbLargura = new System.Windows.Forms.RadioButton();
            this.rbCustomizada = new System.Windows.Forms.RadioButton();
            this.rbArea = new System.Windows.Forms.RadioButton();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnRemoverFigurasGeometricas = new System.Windows.Forms.Button();
            this.btnImportarFigurasGeometricas = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVisualizarPlanoGeometrico = new System.Windows.Forms.Button();
            this.lblInformacaoPlanoGeometrico = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoverPlanoGeometrico = new System.Windows.Forms.Button();
            this.btnImportarPlanoGeometrico = new System.Windows.Forms.Button();
            this.txtNomePlacaGravacao = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbVisaoGrafica = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMover = new System.Windows.Forms.Button();
            this.btnZoom = new System.Windows.Forms.Button();
            this.Resultados = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtResultados = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerResultados = new System.Windows.Forms.Timer(this.components);
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpFigurasGeometricas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArquivos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisaoGrafica)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1323, 24);
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
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarOrganizadorAutomaticoToolStripMenuItem,
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
            // exportarDXFToolStripMenuItem
            // 
            this.exportarDXFToolStripMenuItem.Name = "exportarDXFToolStripMenuItem";
            this.exportarDXFToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.exportarDXFToolStripMenuItem.Text = "Exportar DXF";
            this.exportarDXFToolStripMenuItem.Click += new System.EventHandler(this.exportarDXFToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creditosToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.helpToolStripMenuItem.Text = "Sobre";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // creditosToolStripMenuItem
            // 
            this.creditosToolStripMenuItem.Name = "creditosToolStripMenuItem";
            this.creditosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.creditosToolStripMenuItem.Text = "Creditos";
            this.creditosToolStripMenuItem.Click += new System.EventHandler(this.creditosToolStripMenuItem_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(1323, 726);
            this.splitContainer1.SplitterDistance = 707;
            this.splitContainer1.TabIndex = 2;
            // 
            // gpFigurasGeometricas
            // 
            this.gpFigurasGeometricas.Controls.Add(this.dgvArquivos);
            this.gpFigurasGeometricas.Controls.Add(this.groupBox2);
            this.gpFigurasGeometricas.Controls.Add(this.btnVisualizar);
            this.gpFigurasGeometricas.Controls.Add(this.btnRemoverFigurasGeometricas);
            this.gpFigurasGeometricas.Controls.Add(this.btnImportarFigurasGeometricas);
            this.gpFigurasGeometricas.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpFigurasGeometricas.Location = new System.Drawing.Point(0, 138);
            this.gpFigurasGeometricas.Name = "gpFigurasGeometricas";
            this.gpFigurasGeometricas.Size = new System.Drawing.Size(707, 478);
            this.gpFigurasGeometricas.TabIndex = 2;
            this.gpFigurasGeometricas.TabStop = false;
            this.gpFigurasGeometricas.Text = "Figuras Geometricas";
            // 
            // dgvArquivos
            // 
            this.dgvArquivos.AllowUserToAddRows = false;
            this.dgvArquivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArquivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome,
            this.Ordem,
            this.Area,
            this.Largura,
            this.Altura});
            this.dgvArquivos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvArquivos.Location = new System.Drawing.Point(3, 79);
            this.dgvArquivos.Name = "dgvArquivos";
            this.dgvArquivos.Size = new System.Drawing.Size(701, 345);
            this.dgvArquivos.TabIndex = 11;
            this.dgvArquivos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArquivos_CellEndEdit);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 200;
            // 
            // Ordem
            // 
            this.Ordem.HeaderText = "Ordem";
            this.Ordem.Name = "Ordem";
            this.Ordem.Width = 50;
            // 
            // Area
            // 
            this.Area.HeaderText = "Area (mm2)";
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 50;
            // 
            // Largura
            // 
            this.Largura.HeaderText = "Largura (mm)";
            this.Largura.Name = "Largura";
            this.Largura.ReadOnly = true;
            this.Largura.Width = 50;
            // 
            // Altura
            // 
            this.Altura.FillWeight = 80F;
            this.Altura.HeaderText = "Altura (mm)";
            this.Altura.Name = "Altura";
            this.Altura.ReadOnly = true;
            this.Altura.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAltura);
            this.groupBox2.Controls.Add(this.rbLargura);
            this.groupBox2.Controls.Add(this.rbCustomizada);
            this.groupBox2.Controls.Add(this.rbArea);
            this.groupBox2.Controls.Add(this.btnOrdenar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 63);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordem da disposicao das figuras no plano geometrico";
            // 
            // rbAltura
            // 
            this.rbAltura.AutoSize = true;
            this.rbAltura.Location = new System.Drawing.Point(97, 34);
            this.rbAltura.Name = "rbAltura";
            this.rbAltura.Size = new System.Drawing.Size(52, 17);
            this.rbAltura.TabIndex = 13;
            this.rbAltura.Text = "Altura";
            this.rbAltura.UseVisualStyleBackColor = true;
            // 
            // rbLargura
            // 
            this.rbLargura.AutoSize = true;
            this.rbLargura.Location = new System.Drawing.Point(97, 17);
            this.rbLargura.Name = "rbLargura";
            this.rbLargura.Size = new System.Drawing.Size(61, 17);
            this.rbLargura.TabIndex = 12;
            this.rbLargura.Text = "Largura";
            this.rbLargura.UseVisualStyleBackColor = true;
            // 
            // rbCustomizada
            // 
            this.rbCustomizada.AutoSize = true;
            this.rbCustomizada.Location = new System.Drawing.Point(5, 34);
            this.rbCustomizada.Name = "rbCustomizada";
            this.rbCustomizada.Size = new System.Drawing.Size(85, 17);
            this.rbCustomizada.TabIndex = 11;
            this.rbCustomizada.Text = "Customizada";
            this.rbCustomizada.UseVisualStyleBackColor = true;
            // 
            // rbArea
            // 
            this.rbArea.AutoSize = true;
            this.rbArea.Checked = true;
            this.rbArea.Location = new System.Drawing.Point(6, 17);
            this.rbArea.Name = "rbArea";
            this.rbArea.Size = new System.Drawing.Size(47, 17);
            this.rbArea.TabIndex = 10;
            this.rbArea.TabStop = true;
            this.rbArea.Text = "Area";
            this.rbArea.UseVisualStyleBackColor = true;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Location = new System.Drawing.Point(188, 19);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(83, 31);
            this.btnOrdenar.TabIndex = 9;
            this.btnOrdenar.Text = "Ordenar";
            this.btnOrdenar.UseVisualStyleBackColor = true;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(246, 430);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(122, 40);
            this.btnVisualizar.TabIndex = 8;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnRemoverFigurasGeometricas
            // 
            this.btnRemoverFigurasGeometricas.Location = new System.Drawing.Point(120, 430);
            this.btnRemoverFigurasGeometricas.Name = "btnRemoverFigurasGeometricas";
            this.btnRemoverFigurasGeometricas.Size = new System.Drawing.Size(122, 40);
            this.btnRemoverFigurasGeometricas.TabIndex = 5;
            this.btnRemoverFigurasGeometricas.Text = "Remover";
            this.btnRemoverFigurasGeometricas.UseVisualStyleBackColor = true;
            this.btnRemoverFigurasGeometricas.Click += new System.EventHandler(this.BtnRemoverFigurasGeometricas_Click);
            // 
            // btnImportarFigurasGeometricas
            // 
            this.btnImportarFigurasGeometricas.Location = new System.Drawing.Point(6, 430);
            this.btnImportarFigurasGeometricas.Name = "btnImportarFigurasGeometricas";
            this.btnImportarFigurasGeometricas.Size = new System.Drawing.Size(110, 40);
            this.btnImportarFigurasGeometricas.TabIndex = 4;
            this.btnImportarFigurasGeometricas.Text = "Importar";
            this.btnImportarFigurasGeometricas.UseVisualStyleBackColor = true;
            this.btnImportarFigurasGeometricas.Click += new System.EventHandler(this.BtnImportarFigurasGeometricas_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVisualizarPlanoGeometrico);
            this.groupBox1.Controls.Add(this.lblInformacaoPlanoGeometrico);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRemoverPlanoGeometrico);
            this.groupBox1.Controls.Add(this.btnImportarPlanoGeometrico);
            this.groupBox1.Controls.Add(this.txtNomePlacaGravacao);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plano Geometrico";
            // 
            // btnVisualizarPlanoGeometrico
            // 
            this.btnVisualizarPlanoGeometrico.Enabled = false;
            this.btnVisualizarPlanoGeometrico.Location = new System.Drawing.Point(230, 89);
            this.btnVisualizarPlanoGeometrico.Name = "btnVisualizarPlanoGeometrico";
            this.btnVisualizarPlanoGeometrico.Size = new System.Drawing.Size(125, 43);
            this.btnVisualizarPlanoGeometrico.TabIndex = 6;
            this.btnVisualizarPlanoGeometrico.Text = "Visualizar";
            this.btnVisualizarPlanoGeometrico.UseVisualStyleBackColor = true;
            this.btnVisualizarPlanoGeometrico.Click += new System.EventHandler(this.btnVisualizarPlanoGeometrico_Click);
            // 
            // lblInformacaoPlanoGeometrico
            // 
            this.lblInformacaoPlanoGeometrico.AutoSize = true;
            this.lblInformacaoPlanoGeometrico.Location = new System.Drawing.Point(23, 62);
            this.lblInformacaoPlanoGeometrico.Name = "lblInformacaoPlanoGeometrico";
            this.lblInformacaoPlanoGeometrico.Size = new System.Drawing.Size(127, 13);
            this.lblInformacaoPlanoGeometrico.TabIndex = 5;
            this.lblInformacaoPlanoGeometrico.Text = "Nenhum plano carregado";
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
            this.btnRemoverPlanoGeometrico.Location = new System.Drawing.Point(118, 89);
            this.btnRemoverPlanoGeometrico.Name = "btnRemoverPlanoGeometrico";
            this.btnRemoverPlanoGeometrico.Size = new System.Drawing.Size(106, 43);
            this.btnRemoverPlanoGeometrico.TabIndex = 3;
            this.btnRemoverPlanoGeometrico.Text = "Remover";
            this.btnRemoverPlanoGeometrico.UseVisualStyleBackColor = true;
            this.btnRemoverPlanoGeometrico.Click += new System.EventHandler(this.BtnRemoverPlanoGeometrico_Click);
            // 
            // btnImportarPlanoGeometrico
            // 
            this.btnImportarPlanoGeometrico.Location = new System.Drawing.Point(20, 89);
            this.btnImportarPlanoGeometrico.Name = "btnImportarPlanoGeometrico";
            this.btnImportarPlanoGeometrico.Size = new System.Drawing.Size(92, 43);
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
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(612, 554);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visao Grafica";
            // 
            // pbVisaoGrafica
            // 
            this.pbVisaoGrafica.BackColor = System.Drawing.Color.White;
            this.pbVisaoGrafica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbVisaoGrafica.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbVisaoGrafica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVisaoGrafica.Location = new System.Drawing.Point(3, 39);
            this.pbVisaoGrafica.Name = "pbVisaoGrafica";
            this.pbVisaoGrafica.Size = new System.Drawing.Size(606, 512);
            this.pbVisaoGrafica.TabIndex = 7;
            this.pbVisaoGrafica.TabStop = false;
            this.pbVisaoGrafica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbVisaoGrafica_MouseDown);
            this.pbVisaoGrafica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbVisaoGrafica_MouseMove);
            this.pbVisaoGrafica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbVisaoGrafica_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMover);
            this.panel2.Controls.Add(this.btnZoom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 23);
            this.panel2.TabIndex = 6;
            // 
            // btnMover
            // 
            this.btnMover.BackColor = System.Drawing.Color.Lime;
            this.btnMover.Location = new System.Drawing.Point(3, 0);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(75, 23);
            this.btnMover.TabIndex = 6;
            this.btnMover.Text = "Mover";
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.BackColor = System.Drawing.Color.Lime;
            this.btnZoom.ForeColor = System.Drawing.Color.Black;
            this.btnZoom.Location = new System.Drawing.Point(84, -1);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(75, 23);
            this.btnZoom.TabIndex = 5;
            this.btnZoom.Text = "Zoom";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // Resultados
            // 
            this.Resultados.Controls.Add(this.panel1);
            this.Resultados.Controls.Add(this.label2);
            this.Resultados.Controls.Add(this.progressBar);
            this.Resultados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Resultados.Location = new System.Drawing.Point(0, 554);
            this.Resultados.Name = "Resultados";
            this.Resultados.Size = new System.Drawing.Size(612, 172);
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
            this.panel1.Size = new System.Drawing.Size(606, 119);
            this.panel1.TabIndex = 4;
            // 
            // rtResultados
            // 
            this.rtResultados.BackColor = System.Drawing.Color.White;
            this.rtResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtResultados.Location = new System.Drawing.Point(0, 0);
            this.rtResultados.Name = "rtResultados";
            this.rtResultados.ReadOnly = true;
            this.rtResultados.Size = new System.Drawing.Size(606, 119);
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
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(3, 148);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(606, 21);
            this.progressBar.TabIndex = 2;
            // 
            // timerResultados
            // 
            this.timerResultados.Enabled = true;
            this.timerResultados.Interval = 1000;
            this.timerResultados.Tick += new System.EventHandler(this.timerResultados_Tick);
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Interval = 10;
            this.timerProgressbar.Tick += new System.EventHandler(this.timerProgressbar_Tick);
            // 
            // Form_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 750);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoPack - Organizador Automatico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpFigurasGeometricas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArquivos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVisaoGrafica)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtResultados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pbVisaoGrafica;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.Label lblInformacaoPlanoGeometrico;
        private System.Windows.Forms.Button btnVisualizarPlanoGeometrico;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbAltura;
        private System.Windows.Forms.RadioButton rbLargura;
        private System.Windows.Forms.RadioButton rbCustomizada;
        private System.Windows.Forms.RadioButton rbArea;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.DataGridView dgvArquivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Largura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Altura;
        private System.Windows.Forms.Timer timerResultados;
        private System.Windows.Forms.Timer timerProgressbar;
    }
}

