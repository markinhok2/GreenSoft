using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenSoft_Balcao.View
{
    public partial class fPagamento : Form
    {
        public bool bFecha = false;
        public fPagamento(string sValor)
        {
            InitializeComponent();
            txtValor.Text = "R$ " + sValor;
        }

        private void fPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bFecha)
                e.Cancel = true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bFecha = true;
            this.Close();
        }
    }
}
