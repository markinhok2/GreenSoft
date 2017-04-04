using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenSoft_Balcao.View.Reports
{
    public partial class fRPI_Pedidos : Form
    {
        public fRPI_Pedidos()
        {
            InitializeComponent();
        }

        private void fRPI_Pedidos_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
