using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreenSoft_Balcao.Data;

namespace GreenSoft_Balcao.View
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dx = new dbGreenSoftFinalEntities())
                {
                    Usuario user = dx.Usuario.FirstOrDefault(x => x.Username == txtUsuario.Text.Trim());

                    if (user == null)
                    {
                        MessageBox.Show("Usuário não cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsuario.Focus();
                        return;
                    }

                    if(user.Senha != txtSenha.Text.Trim())
                    {
                        MessageBox.Show("Usuário/Senha não conferem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsuario.Focus();
                        return;
                    }

                    Controller.clsStatic.Usuario = user;
                    fMenu_Principal fPrincipal = new fMenu_Principal();
                    this.Hide();
                    fPrincipal.ShowDialog();
                    if (Controller.clsStatic.bSolicitaLogin)
                    {
                        txtSenha.Clear();
                        txtUsuario.Clear();
                        Controller.clsStatic.Usuario = null;
                        Controller.clsStatic.bSolicitaLogin = false;
                        this.Show();
                        txtUsuario.Focus();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnLogin_Click - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }
    }
}
