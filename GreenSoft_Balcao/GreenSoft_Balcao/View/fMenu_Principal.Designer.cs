namespace GreenSoft_Balcao.View
{
    partial class fMenu_Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMenu_Principal));
            this.toolPrincipal = new System.Windows.Forms.ToolStrip();
            this.bProduto = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCadProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.bCliente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCadCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.bCompras = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.bRelatorios = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFerramentas = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCalculadora = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCalendario = new System.Windows.Forms.ToolStripMenuItem();
            this.bmanutencao = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCadastrarUsuário = new System.Windows.Forms.ToolStripMenuItem();
            this.bTrocaUser = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSair = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAjuda = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.statusPrincipal = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCooperativa = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblData = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnCalendario = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolPrincipal.SuspendLayout();
            this.statusPrincipal.SuspendLayout();
            this.pnCalendario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolPrincipal
            // 
            this.toolPrincipal.BackColor = System.Drawing.Color.PowderBlue;
            this.toolPrincipal.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolPrincipal.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bProduto,
            this.bCliente,
            this.bCompras,
            this.bRelatorios,
            this.btnFerramentas,
            this.bmanutencao,
            this.bTrocaUser,
            this.btnSair,
            this.btnAjuda});
            this.toolPrincipal.Location = new System.Drawing.Point(0, 0);
            this.toolPrincipal.Name = "toolPrincipal";
            this.toolPrincipal.Padding = new System.Windows.Forms.Padding(0);
            this.toolPrincipal.Size = new System.Drawing.Size(1022, 62);
            this.toolPrincipal.TabIndex = 0;
            this.toolPrincipal.Text = "Menu";
            // 
            // bProduto
            // 
            this.bProduto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCadProduto});
            this.bProduto.Image = ((System.Drawing.Image)(resources.GetObject("bProduto.Image")));
            this.bProduto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bProduto.Name = "bProduto";
            this.bProduto.Size = new System.Drawing.Size(68, 59);
            this.bProduto.Text = "&Produtos";
            this.bProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCadProduto
            // 
            this.btnCadProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnCadProduto.Image")));
            this.btnCadProduto.Name = "btnCadProduto";
            this.btnCadProduto.Size = new System.Drawing.Size(194, 46);
            this.btnCadProduto.Text = "&Cadastrar Produto";
            this.btnCadProduto.Click += new System.EventHandler(this.btnCadProduto_Click);
            // 
            // bCliente
            // 
            this.bCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCadCliente});
            this.bCliente.Image = ((System.Drawing.Image)(resources.GetObject("bCliente.Image")));
            this.bCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCliente.Name = "bCliente";
            this.bCliente.Size = new System.Drawing.Size(62, 59);
            this.bCliente.Text = "&Clientes";
            this.bCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCadCliente
            // 
            this.btnCadCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCadCliente.Image")));
            this.btnCadCliente.Name = "btnCadCliente";
            this.btnCadCliente.Size = new System.Drawing.Size(188, 46);
            this.btnCadCliente.Text = "&Cadastrar Cliente";
            this.btnCadCliente.Click += new System.EventHandler(this.btnCadCliente_Click);
            // 
            // bCompras
            // 
            this.bCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCompra});
            this.bCompras.Image = ((System.Drawing.Image)(resources.GetObject("bCompras.Image")));
            this.bCompras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCompras.Name = "bCompras";
            this.bCompras.Size = new System.Drawing.Size(68, 59);
            this.bCompras.Text = "&Compras";
            this.bCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCompra
            // 
            this.btnCompra.Image = ((System.Drawing.Image)(resources.GetObject("btnCompra.Image")));
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(176, 46);
            this.btnCompra.Text = "Iniciar Compra";
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // bRelatorios
            // 
            this.bRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("bRelatorios.Image")));
            this.bRelatorios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRelatorios.Name = "bRelatorios";
            this.bRelatorios.Size = new System.Drawing.Size(72, 59);
            this.bRelatorios.Text = "&Relatórios";
            this.bRelatorios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnFerramentas
            // 
            this.btnFerramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCalculadora,
            this.btnCalendario});
            this.btnFerramentas.Image = ((System.Drawing.Image)(resources.GetObject("btnFerramentas.Image")));
            this.btnFerramentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFerramentas.Name = "btnFerramentas";
            this.btnFerramentas.Size = new System.Drawing.Size(85, 59);
            this.btnFerramentas.Text = "&Ferramentas";
            this.btnFerramentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculadora.Image")));
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(176, 46);
            this.btnCalculadora.Text = "&Calculadora";
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // btnCalendario
            // 
            this.btnCalendario.Image = ((System.Drawing.Image)(resources.GetObject("btnCalendario.Image")));
            this.btnCalendario.Name = "btnCalendario";
            this.btnCalendario.Size = new System.Drawing.Size(176, 46);
            this.btnCalendario.Text = "Ca&lendário";
            this.btnCalendario.Click += new System.EventHandler(this.btnCalendario_Click);
            // 
            // bmanutencao
            // 
            this.bmanutencao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCadastrarUsuário});
            this.bmanutencao.Image = ((System.Drawing.Image)(resources.GetObject("bmanutencao.Image")));
            this.bmanutencao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bmanutencao.Name = "bmanutencao";
            this.bmanutencao.Size = new System.Drawing.Size(87, 59);
            this.bmanutencao.Text = "&Manutenção";
            this.bmanutencao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCadastrarUsuário
            // 
            this.btnCadastrarUsuário.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrarUsuário.Image")));
            this.btnCadastrarUsuário.Name = "btnCadastrarUsuário";
            this.btnCadastrarUsuário.Size = new System.Drawing.Size(191, 46);
            this.btnCadastrarUsuário.Text = "&Cadastrar Usuário";
            this.btnCadastrarUsuário.Click += new System.EventHandler(this.btnCadastrarUsuário_Click);
            // 
            // bTrocaUser
            // 
            this.bTrocaUser.Image = ((System.Drawing.Image)(resources.GetObject("bTrocaUser.Image")));
            this.bTrocaUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bTrocaUser.Name = "bTrocaUser";
            this.bTrocaUser.Size = new System.Drawing.Size(96, 59);
            this.bTrocaUser.Text = "&Trocar Usuário";
            this.bTrocaUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bTrocaUser.Click += new System.EventHandler(this.bTrocaUser_Click);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(53, 59);
            this.btnSair.Text = "&Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAjuda
            // 
            this.btnAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSobre});
            this.btnAjuda.Image = ((System.Drawing.Image)(resources.GetObject("btnAjuda.Image")));
            this.btnAjuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Size = new System.Drawing.Size(53, 59);
            this.btnAjuda.Text = "&Ajuda";
            this.btnAjuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSobre
            // 
            this.btnSobre.Image = ((System.Drawing.Image)(resources.GetObject("btnSobre.Image")));
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(176, 46);
            this.btnSobre.Text = "&Sobre";
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
            // 
            // statusPrincipal
            // 
            this.statusPrincipal.BackColor = System.Drawing.Color.PowderBlue;
            this.statusPrincipal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.statusPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblCooperativa,
            this.lblData,
            this.lblHora});
            this.statusPrincipal.Location = new System.Drawing.Point(0, 568);
            this.statusPrincipal.Name = "statusPrincipal";
            this.statusPrincipal.Size = new System.Drawing.Size(1022, 28);
            this.statusPrincipal.TabIndex = 1;
            this.statusPrincipal.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.Gainsboro;
            this.lblUsuario.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(143, 23);
            this.lblUsuario.Text = "toolStripStatusLabel1";
            // 
            // lblCooperativa
            // 
            this.lblCooperativa.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCooperativa.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblCooperativa.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblCooperativa.Name = "lblCooperativa";
            this.lblCooperativa.Size = new System.Drawing.Size(143, 23);
            this.lblCooperativa.Text = "toolStripStatusLabel1";
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.Color.Gainsboro;
            this.lblData.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblData.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(143, 23);
            this.lblData.Text = "toolStripStatusLabel1";
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.Color.Gainsboro;
            this.lblHora.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblHora.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(143, 23);
            this.lblHora.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnCalendario
            // 
            this.pnCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnCalendario.BackColor = System.Drawing.Color.LightGreen;
            this.pnCalendario.Controls.Add(this.pictureBox1);
            this.pnCalendario.Controls.Add(this.label1);
            this.pnCalendario.Controls.Add(this.monthCalendar1);
            this.pnCalendario.Controls.Add(this.btnClose);
            this.pnCalendario.Location = new System.Drawing.Point(774, 354);
            this.pnCalendario.Name = "pnCalendario";
            this.pnCalendario.Size = new System.Drawing.Size(246, 212);
            this.pnCalendario.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Calendário";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.Window;
            this.monthCalendar1.Location = new System.Drawing.Point(9, 38);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(220, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fMenu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1022, 596);
            this.Controls.Add(this.pnCalendario);
            this.Controls.Add(this.statusPrincipal);
            this.Controls.Add(this.toolPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "fMenu_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GreenSoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMenu_Principal_FormClosing);
            this.Load += new System.EventHandler(this.fMenu_Principal_Load);
            this.toolPrincipal.ResumeLayout(false);
            this.toolPrincipal.PerformLayout();
            this.statusPrincipal.ResumeLayout(false);
            this.statusPrincipal.PerformLayout();
            this.pnCalendario.ResumeLayout(false);
            this.pnCalendario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolPrincipal;
        private System.Windows.Forms.StatusStrip statusPrincipal;
        private System.Windows.Forms.ToolStripDropDownButton bmanutencao;
        private System.Windows.Forms.ToolStripDropDownButton bProduto;
        private System.Windows.Forms.ToolStripMenuItem btnCadProduto;
        private System.Windows.Forms.ToolStripDropDownButton bCliente;
        private System.Windows.Forms.ToolStripMenuItem btnCadCliente;
        private System.Windows.Forms.ToolStripDropDownButton bCompras;
        private System.Windows.Forms.ToolStripMenuItem btnCompra;
        private System.Windows.Forms.ToolStripDropDownButton bRelatorios;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblCooperativa;
        private System.Windows.Forms.ToolStripDropDownButton btnSair;
        private System.Windows.Forms.ToolStripDropDownButton bTrocaUser;
        private System.Windows.Forms.ToolStripMenuItem btnCadastrarUsuário;
        private System.Windows.Forms.ToolStripStatusLabel lblHora;
        private System.Windows.Forms.ToolStripStatusLabel lblData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripDropDownButton btnAjuda;
        private System.Windows.Forms.ToolStripMenuItem btnSobre;
        private System.Windows.Forms.ToolStripDropDownButton btnFerramentas;
        private System.Windows.Forms.ToolStripMenuItem btnCalculadora;
        private System.Windows.Forms.Panel pnCalendario;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem btnCalendario;
    }
}