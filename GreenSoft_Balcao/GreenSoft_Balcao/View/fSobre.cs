using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenSoft_Balcao.View
{
    public partial class fSobre : Form
    {
        public fSobre()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fSobre_Load(object sender, EventArgs e)
        {
            lblCooperativa.Text = Controller.clsStatic.Usuario.Cooperativa.Razao;
            lblVersao.Text = Application.ProductVersion.ToString();
        }

        private void imgFace_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/markinhoo22");
        }
    }
}
