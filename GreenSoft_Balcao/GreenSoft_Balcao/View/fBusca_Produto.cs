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
    public partial class fBusca_Produto : Form
    {
        private int _iTpBusca;
        public fBusca_Produto(int tpBusca)
        {
            _iTpBusca = tpBusca;
            InitializeComponent();
        }

        private void fBusca_Produto_Load(object sender, EventArgs e)
        {
            clsStatic.produto = null;
            if (txtBusca.Text.Trim() != "")
            {
                FindProduto();
            }
        }

        private void FindProduto()
        {
            try
            {
                
                using (var dx = new dbGreenSoftFinalEntities())
                {
                    if (_iTpBusca == 0)
                    {
                        var qry = from prd in dx.Produto.Where(prd => prd.Descricao.Contains(txtBusca.Text))
                                  orderby prd.Descricao
                                  select new
                                  {
                                      Id = prd.Produto_ID,
                                      Descricao = prd.Descricao,
                                      Estoque = prd.Estoque
                                  };
                        dgvProdutos.DataSource = qry.ToList();
                    }
                    else
                    {
                        var qry = from prd in dx.Produto.Where(prd => prd.Descricao.Contains(txtBusca.Text))
                                  where prd.Ativo == true
                                  orderby prd.Descricao
                                  select new
                                  {
                                      Id = prd.Produto_ID,
                                      Descricao = prd.Descricao,
                                      Estoque = prd.Estoque
                                  };
                        dgvProdutos.DataSource = qry.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FindProduto - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FindProduto();
            }
        }

        private void dgvProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idProduto = (int)dgvProdutos.Rows[e.RowIndex].Cells[0].Value;

            using(var dx = new dbGreenSoftFinalEntities())
            {
                clsStatic.produto = dx.Produto.FirstOrDefault(x => x.Produto_ID == idProduto);
            }

            this.Close();
        }
    }
}
