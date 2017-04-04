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
    public partial class fCompra : Form
    {
        public Pedido pedido = new Pedido();
        public List<PedidoItem> pedidoItem = new List<PedidoItem>();
        public fCompra()
        {
            InitializeComponent();
        }

        private void fCompra_Load(object sender, EventArgs e)
        {
            txtCdCoop.Text = clsStatic.Usuario.Cooperativa.Cooperativa_ID.ToString();
            txtRazaoCoop.Text = clsStatic.Usuario.Cooperativa.Razao.ToString();
            txtCNPJCoop.Text = clsStatic.Usuario.Cooperativa.Cnpj.ToString();
            txtDtHora.Text = DateTime.Now.ToString();
            pedido.Cooperativa_ID = clsStatic.Usuario.Cooperativa.Cooperativa_ID;
            pedido.Usuario_ID = clsStatic.Usuario.Usuario_ID;
            clsStatic.cliente = null;
        }

        private void btnIncluiCliente_Click(object sender, EventArgs e)
        {
            fBusca_Cliente frmCliente = new fBusca_Cliente();
            frmCliente.ShowDialog();
            if (clsStatic.cliente != null)
            {
                pedido.Cliente_ID = clsStatic.cliente.Cliente_ID;
                txtBairro.Text = clsStatic.cliente.Bairro;
                txtCEP.Text = clsStatic.cliente.Cep;
                txtCPF.Text = clsStatic.cliente.Cpf;
                txtNome.Text = clsStatic.cliente.Nome;
                txtNumero.Text = clsStatic.cliente.Numero;
                txtRua.Text = clsStatic.cliente.Rua;
                txtCidade.Text = clsStatic.cliente.Cidade;
                txtIDCliente.Text = clsStatic.cliente.Cliente_ID.ToString();

                if (!String.IsNullOrEmpty(clsStatic.cliente.Imagem))
                    imgCliente.BackgroundImage = clsUtil.Base64ToImage(clsStatic.cliente.Imagem);
                else
                    imgCliente.BackgroundImage = null;
            }
            else
            {
                pedido.Cliente_ID = 0;
                txtBairro.Clear();
                txtCEP.Clear();
                txtCPF.Clear();
                txtNome.Clear();
                txtNumero.Clear();
                txtRua.Clear();
                txtCidade.Clear();
                txtIDCliente.Clear();
                imgCliente.BackgroundImage = null;
            }
        }

        private void txtIdProduto_Leave(object sender, EventArgs e)
        {
            if (txtIdProduto.Text.Trim() != "")
            {
                double Num;
                bool isNum = double.TryParse(txtIdProduto.Text.Trim(), out Num);
                if (isNum)
                {
                    using (var dx = new dbGreenSoftFinalEntities())
                    {
                        clsStatic.produto = dx.Produto.FirstOrDefault(x => x.Produto_ID == Num);
                    }
                    if (clsStatic.produto != null)
                    {
                        if (!clsStatic.produto.Ativo)
                        {
                            MessageBox.Show("O produto '" + clsStatic.produto.Descricao + "' não está ativo para compras!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            clsStatic.produto = null;
                            return;
                        }
                        txtIdProduto.Text = clsStatic.produto.Produto_ID.ToString();
                        txtDsProduto.Text = clsStatic.produto.Descricao;
                        txtUnidadeProduto.Text = clsStatic.produto.Unidade;
                        txtValor.Text = clsStatic.produto.Valor.ToString("#,##0.00");
                        if (!String.IsNullOrEmpty(clsStatic.produto.Image))
                            imgProduto.BackgroundImage = clsUtil.Base64ToImage(clsStatic.produto.Image);
                    }

                }
            }
        }

        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            fBusca_Produto frmProduto = new fBusca_Produto(1);
            frmProduto.ShowDialog();
            if (clsStatic.produto != null)
            {
                txtIdProduto.Text = clsStatic.produto.Produto_ID.ToString();
                txtDsProduto.Text = clsStatic.produto.Descricao;
                txtUnidadeProduto.Text = clsStatic.produto.Unidade;
                txtValor.Text = clsStatic.produto.Valor.ToString("#,##0.00");
                if (!String.IsNullOrEmpty(clsStatic.produto.Image))
                    imgProduto.BackgroundImage = clsUtil.Base64ToImage(clsStatic.produto.Image);
            }
            else
            {
                txtIdProduto.Text = "";
                txtDsProduto.Text = "";
                txtUnidadeProduto.Text = "";
                txtQtdProduto.Text = "";
                txtValor.Text = "";
                imgProduto.BackgroundImage = null;
            }
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            if (clsStatic.produto != null && txtQtdProduto.Text.Trim() != "")
            {
                PedidoItem pedidoItemNew = new PedidoItem();
                pedidoItemNew.Produto_ID = clsStatic.produto.Produto_ID;
                pedidoItemNew.Qtde = Convert.ToInt32(txtQtdProduto.Text);
                pedidoItemNew.DsProduto = clsStatic.produto.Descricao;
                pedidoItemNew.Unidade = clsStatic.produto.Unidade;
                pedidoItemNew.Valor = clsStatic.produto.Valor;
                pedidoItemNew.ValorTotal = pedidoItemNew.Valor * pedidoItemNew.Qtde;
                pedidoItem.Add(pedidoItemNew);
                AtualizaGrid();

                txtIdProduto.Text = "";
                txtDsProduto.Text = "";
                txtQtdProduto.Text = "";
                txtUnidadeProduto.Text = "";
                txtValor.Text = "";
                imgProduto.BackgroundImage = null;
                clsStatic.produto = null;
                txtIdProduto.Focus();
            }
        }

        private void AtualizaGrid()
        {
            try
            {
                dgvItens.DataSource = (from x in pedidoItem
                                       select new
                                       {
                                           Codigo = x.Produto_ID,
                                           Descricao = x.DsProduto,
                                           Unidade = x.Unidade,
                                           Valor = x.Valor,
                                           Qtde = x.Qtde,
                                           Total = x.ValorTotal
                                       }).ToList();
                txtValorTotal.Text = pedidoItem.Sum(x => x.ValorTotal).ToString("#,##0.00");
                txtTotalKG.Text = pedidoItem.Sum(x => x.Qtde).ToString("#,##0.00");
            }
            catch (Exception ex)
            {

            }
        }

        private void fCompra_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F12)
                {
                    btnFinalizaPedido_Click(sender, e);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnFinalizaPedido_Click(object sender, EventArgs e)
        {
            if (pedido.Cliente_ID != 0)
            {
                if (pedidoItem.Count > 0)
                {

                    using (var dx = new dbGreenSoftFinalEntities())
                    {
                        Produto product;
                        pedido.Status = 1;
                        pedido.ValorTotal = pedidoItem.Sum(x => x.ValorTotal);
                        pedido.DtPedido = DateTime.Now;
                        dx.Pedido.Add(pedido);
                        foreach (PedidoItem item in pedidoItem)
                        {
                            item.Pedido = pedido;
                            dx.PedidoItem.Add(item);
                            product = dx.Produto.FirstOrDefault(x => x.Produto_ID == item.Produto_ID);
                            //atualiza estoque
                            product.Estoque += item.Qtde;
                        }

                        dx.SaveChanges();

                        fPagamento fPag = new fPagamento(pedido.ValorTotal.ToString("#,##0.00"));
                        fPag.ShowDialog();
                        ClearCompra();
                    }
                }
            }
        }

        private void ClearCompra()
        {
            try
            {
                pedido = new Pedido();
                pedido.Cooperativa_ID = clsStatic.Usuario.Cooperativa.Cooperativa_ID;
                pedido.Usuario_ID = clsStatic.Usuario.Usuario_ID;
                pedidoItem = new List<PedidoItem>();
                txtIdProduto.Clear();
                txtDsProduto.Clear();
                txtUnidadeProduto.Clear();
                txtValor.Clear();
                clsStatic.produto = null;
                clsStatic.cliente = null;
                txtQtdProduto.Clear();
                txtTotalKG.Clear();
                txtValorTotal.Clear();
                dgvItens.DataSource = null;
                txtBairro.Clear();
                txtCEP.Clear();
                txtCPF.Clear();
                txtNome.Clear();
                txtNumero.Clear();
                txtRua.Clear();
                txtCidade.Clear();
                txtIDCliente.Clear();
                imgProduto.BackgroundImage = null;
                imgCliente.BackgroundImage = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtQtdProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddProduto_Click(sender, e);
        }
    }
}
