using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreenSoft_Balcao.Controller;

namespace GreenSoft_Balcao.View
{
    public partial class fMenu_Principal : Form
    {
        public fMenu_Principal()
        {
            InitializeComponent();
        }

        private void fMenu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!clsStatic.bSaiu && !clsStatic.bSolicitaLogin)
                e.Cancel = true;
        }

        private void fMenu_Principal_Load(object sender, EventArgs e)
        {
            VerificaPermissoes();
            lblUsuario.Text = clsStatic.Usuario.Nome + ", seja bem-vindo!";
            lblCooperativa.Text = "Cooperativa: " + clsStatic.Usuario.Cooperativa.Razao;
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair da aplicação?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsStatic.bSaiu = true;
                this.Close();
            }

        }

        private void btnCadProduto_Click(object sender, EventArgs e)
        {
            try
            {
                View.fCad_Produto fProduto = new fCad_Produto();
                fProduto.MdiParent = this;
                fProduto.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnCadProduto_Click - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnCadCliente_Click(object sender, EventArgs e)
        {
            try
            {
                View.fCad_Cliente fProduto = new fCad_Cliente();
                fProduto.MdiParent = this;
                fProduto.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnCadCliente_Click - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void VerificaPermissoes()
        {
            if (clsStatic.Usuario.StBalcao)
            {
                bProduto.Visible = false;
                bCliente.Visible = true;
                bCompras.Visible = true;
                this.Text = "GreeSoft - Versão Balcão";
            }
            else
            {
                bProduto.Visible = true;
                bCliente.Visible = false;
                bCompras.Visible = false;
                this.Text = "GreeSoft - Versão Escritório";
            }
            if(clsStatic.Usuario.Usuario_ID == 1)
            {
                //ADM
                bProduto.Visible = true;
                bCliente.Visible = true;
                bCompras.Visible = true;
                this.Text = "GreeSoft - Versão Admin";
            }
        }

        private void bTrocaUser_Click(object sender, EventArgs e)
        {
            clsStatic.bSolicitaLogin = true;
            this.Close();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            fCompra frmCompra = new fCompra();
            frmCompra.MdiParent = this;
            frmCompra.Show();
        }

        private void btnCadastrarUsuário_Click(object sender, EventArgs e)
        {
            fCad_Usuario frmUsuario = new fCad_Usuario();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            fSobre frmSobre = new fSobre();
            frmSobre.ShowDialog();
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            fCalculadora fCalc = new fCalculadora();
            fCalc.MdiParent = this;
            fCalc.Show();
            // System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
        }
    }
}
