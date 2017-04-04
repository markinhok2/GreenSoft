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
    public partial class fCad_Produto : Form
    {
        public fCad_Produto()
        {
            InitializeComponent();
        }

        private void fCad_Produto_Load(object sender, EventArgs e)
        {
            cboUnidade.DataSource = Controller.clsStatic.lsUnidades;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAdd_Click - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            try
            {
                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == groupBox1.GetType())
                    {
                        foreach (Control innerControl in control.Controls)
                        {
                            if (innerControl.GetType() == txtDescricao.GetType())
                            {
                                innerControl.Text = "";
                            }
                            if (innerControl.GetType() == cboUnidade.GetType())
                            {
                                ((ComboBox)innerControl).SelectedIndex = 0;
                            }
                            if (innerControl.GetType() == chkAtivo.GetType())
                            {
                                ((CheckBox)innerControl).Checked = false;
                            }
                        }
                    }
                }
                clsStatic.produto = null;
                imgProduto.BackgroundImage = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LimparCampos - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    if (clsStatic.produto == null)
                    {
                        //cria um novo cadastro
                        clsStatic.produto = new Produto()
                        {
                            Ativo = chkAtivo.Checked,
                            Descricao = txtDescricao.Text.Trim(),
                            Estoque = Convert.ToInt32(txtEstoque.Text.Trim()),
                            Unidade = cboUnidade.SelectedValue.ToString(),
                            Valor = Convert.ToDecimal(txtValor.Text)
                        };

                        if (imgProduto.BackgroundImage != null)
                            clsStatic.produto.Image = clsUtil.ImageToBase64(imgProduto.BackgroundImage, imgProduto.BackgroundImage.RawFormat);
                       
                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            dx.Produto.Add(clsStatic.produto);
                            dx.SaveChanges();
                            CarregaCampos();
                        }
                        MessageBox.Show("Produto cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //atualiza o cadastro
                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            var prd = dx.Produto.FirstOrDefault(x => x.Produto_ID.Equals(clsStatic.produto.Produto_ID));
                            if (prd != null)
                            {
                                prd.Ativo = chkAtivo.Checked;
                                prd.Descricao = txtDescricao.Text.Trim();
                                prd.Estoque = Convert.ToInt32(txtEstoque.Text.Trim());
                                prd.Unidade = cboUnidade.SelectedValue.ToString();
                                prd.Valor = Convert.ToDecimal(txtValor.Text);
                                if (imgProduto.BackgroundImage != null)
                                {
                                    prd.Image = clsUtil.ImageToBase64(imgProduto.BackgroundImage, imgProduto.BackgroundImage.RawFormat);
                                }
                                dx.SaveChanges();
                                btnRefresh_Click(sender, e);
                            }
                        }
                        MessageBox.Show("Produto atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSave_Click - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidaCampos()
        {
            if (txtDescricao.Text.Trim() == "")
            {
                MessageBox.Show("Informe a descrição do produto", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return false;
            }
            if (txtEstoque.Text.Trim() == "")
            {
                MessageBox.Show("Informe o estoque do produto", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEstoque.Focus();
                return false;
            }
            if (txtValor.Text.Trim() == "")
            {
                MessageBox.Show("Informe o valor do produto", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return false;
            }
            if (cboUnidade.Text.Trim() == "")
            {
                MessageBox.Show("Informe a unidade do produto", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboUnidade.Focus();
                return false;
            }
            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (clsStatic.produto != null)
            {
                using (var dx = new dbGreenSoftFinalEntities())
                {
                    clsStatic.produto = dx.Produto.FirstOrDefault(x => x.Produto_ID == clsStatic.produto.Produto_ID);
                    CarregaCampos();
                }
            }
        }

        private void CarregaCampos()
        {
            try
            {
                txtIdProduto.Text = clsStatic.produto.Produto_ID.ToString();
                chkAtivo.Checked = clsStatic.produto.Ativo;
                txtDescricao.Text = clsStatic.produto.Descricao;
                txtEstoque.Text = clsStatic.produto.Estoque.ToString();
                cboUnidade.Text = clsStatic.produto.Unidade;
                txtValor.Text = clsStatic.produto.Valor.ToString("#,##0.00");
                if (!String.IsNullOrEmpty(clsStatic.produto.Image))
                    imgProduto.BackgroundImage = clsUtil.Base64ToImage(clsStatic.produto.Image);
                else
                    imgProduto.BackgroundImage = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CarregaCampos - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsStatic.produto != null)
                {
                    if (MessageBox.Show("Deseja realmente excluir o cadastro do produto '" + clsStatic.produto.Descricao + "'?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            dx.Produto.Remove(dx.Produto.FirstOrDefault(x => x.Produto_ID == clsStatic.produto.Produto_ID));
                            dx.SaveChanges();
                            LimparCampos();
                            clsStatic.produto = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDelete_Click - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fBusca_Produto fBuscaPrd = new fBusca_Produto(0);
            fBuscaPrd.ShowDialog();
            if (clsStatic.produto == null)
                LimparCampos();
            else
                CarregaCampos();
        }

        private void btnAddFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = false;
                openFile.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
                DialogResult result = openFile.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    foreach (var files in openFile.FileNames)
                    {
                        imgProduto.BackgroundImage = Image.FromFile(files);
                        imgProduto.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
