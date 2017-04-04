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
            this.bmanutencao = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCadastrarUsuário = new System.Windows.Forms.ToolStripMenuItem();
            this.bTrocaUser = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAjuda = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSair = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusPrincipal = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCooperativa = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblData = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFerramentas = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCalculadora = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPrincipal.SuspendLayout();
            this.statusPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolPrincipal
            // 
            this.toolPrincipal.BackColor = System.Drawing.Color.PaleGreen;
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
            this.toolPrincipal.Size = new System.Drawing.Size(834, 62);
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
            this.btnCadProduto.Name = "btnCadProduto";
            this.btnCadProduto.Size = new System.Drawing.Size(170, 22);
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
            this.btnCadCliente.Name = "btnCadCliente";
            this.btnCadCliente.Size = new System.Drawing.Size(164, 22);
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
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(152, 22);
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
            this.btnCadastrarUsuário.Name = "btnCadastrarUsuário";
            this.btnCadastrarUsuário.Size = new System.Drawing.Size(167, 22);
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
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(104, 22);
            this.btnSobre.Text = "&Sobre";
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
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
            // statusPrincipal
            // 
            this.statusPrincipal.BackColor = System.Drawing.Color.PaleGreen;
            this.statusPrincipal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.statusPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblCooperativa,
            this.lblData,
            this.lblHora});
            this.statusPrincipal.Location = new System.Drawing.Point(0, 274);
            this.statusPrincipal.Name = "statusPrincipal";
            this.statusPrincipal.Size = new System.Drawing.Size(834, 28);
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
            // btnFerramentas
            // 
            this.btnFerramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCalculadora});
            this.btnFerramentas.Image = ((System.Drawing.Image)(resources.GetObject("btnFerramentas.Image")));
            this.btnFerramentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFerramentas.Name = "btnFerramentas";
            this.btnFerramentas.Size = new System.Drawing.Size(85, 59);
            this.btnFerramentas.Text = "&Ferramentas";
            this.btnFerramentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(152, 22);
            this.btnCalculadora.Text = "&Calculadora";
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // fMenu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 302);
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
    }
}