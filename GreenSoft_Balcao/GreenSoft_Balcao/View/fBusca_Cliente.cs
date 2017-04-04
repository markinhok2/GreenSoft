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
using GreenSoft_Balcao.Controller;

namespace GreenSoft_Balcao.View
{
    public partial class fBusca_Cliente : Form
    {
        public fBusca_Cliente()
        {
            InitializeComponent();
        }

        private void fBusca_Cliente_Load(object sender, EventArgs e)
        {
            clsStatic.cliente = null;
            if (txtBusca.Text.Trim() != "")
            {
                FindClient();
            }
        }

        private void FindClient()
        {
            try
            {
                using (var dx = new dbGreenSoftFinalEntities())
                {
                    var qry = from cli in dx.Cliente.Where(cli => cli.Nome.Contains(txtBusca.Text))
                              orderby cli.Nome
                              select new {
                                  Id = cli.Cliente_ID,
                                  Nome = cli.Nome,
                                  CPF = cli.Cpf
                              };
                    dgvClientes.DataSource = qry.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FindClient - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FindClient();
            }
        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idCliente = (int)dgvClientes.Rows[e.RowIndex].Cells[0].Value;

            using(var dx = new dbGreenSoftFinalEntities())
            {
                clsStatic.cliente = dx.Cliente.FirstOrDefault(x => x.Cliente_ID == idCliente);
            }

            this.Close();
        }
    }
}
