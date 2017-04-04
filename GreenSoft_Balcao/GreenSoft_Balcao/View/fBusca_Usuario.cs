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
    public partial class fBusca_Usuario : Form
    {
        public fBusca_Usuario()
        {
            InitializeComponent();
        }

        private void fBusca_Usuario_Load(object sender, EventArgs e)
        {
            clsStatic.usuario_temp = null;
            if (txtBusca.Text.Trim() != "")
            {
                FindUsuario();
            }
        }

        private void FindUsuario()
        {
            try
            {
                using (var dx = new dbGreenSoftFinalEntities())
                {
                    var qry = from user in dx.Usuario.Where(user => user.Nome.Contains(txtBusca.Text))
                              orderby user.Nome
                              select new {
                                  Id = user.Usuario_ID,
                                  Nome = user.Nome
                              };
                    dgvUsuarios.DataSource = qry.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FindUsuario - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FindUsuario();
            }
        }

        private void dgvProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idUser = (int)dgvUsuarios.Rows[e.RowIndex].Cells[0].Value;

            using(var dx = new dbGreenSoftFinalEntities())
            {
                clsStatic.usuario_temp = dx.Usuario.FirstOrDefault(x => x.Usuario_ID == idUser);
            }

            this.Close();
        }
    }
}
