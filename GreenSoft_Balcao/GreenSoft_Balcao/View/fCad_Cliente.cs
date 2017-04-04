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
using AForge.Video;
using AForge.Video.DirectShow;

namespace GreenSoft_Balcao.View
{
    public partial class fCad_Cliente : Form
    {
        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;

        public fCad_Cliente()
        {
            InitializeComponent();
        }

        private void fCad_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
                foreach (FilterInfo Device in CaptureDevice)
                    cboCameras.Items.Add(Device.Name);

                cboCameras.SelectedIndex = 0; // default
                FinalFrame = new VideoCaptureDevice();

                imgCliente.BackgroundImage = imgList.Images[0];

                txtDtCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");
                cboPais.SelectedIndex = 0;
                using (var dx = new Data.dbGreenSoftFinalEntities())
                {
                    var qryUFs = (from c in dx.UnidadeFederativa
                                  orderby c.Descricao
                                  select new
                                  {
                                      UfID = c.UF_ID,
                                      UfNome = c.Descricao
                                  }).ToList();

                    qryUFs.Insert(0, new { UfID = 0, UfNome = "" });

                    cboUF.DataSource = qryUFs;
                    cboUF.DisplayMember = "UfNome";
                    cboUF.ValueMember = "UfID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                            if (innerControl.GetType() == txtNome.GetType() && innerControl.Name != "txtDtCadastro")
                            {
                                innerControl.Text = "";
                            }
                            if (innerControl.GetType() == cboUF.GetType())
                            {
                                if (innerControl.Name == cboPais.Name || innerControl.Name == cboCameras.Name)
                                    ((ComboBox)innerControl).SelectedIndex = 0;
                                else
                                    ((ComboBox)innerControl).SelectedIndex = -1;

                                ((ComboBox)innerControl).Text = "";
                            }
                            if (innerControl.GetType() == dtNascimento.GetType())
                            {
                                ((DateTimePicker)innerControl).Value = DateTime.Now;
                            }
                            if (innerControl.GetType() == chkAtivo.GetType())
                            {
                                ((CheckBox)innerControl).Checked = false;
                            }
                        }

                    }
                }
                clsStatic.cliente = null;
                if (FinalFrame.IsRunning == true)
                    FinalFrame.Stop();

                imgCliente.BackgroundImage = imgList.Images[0];
                btnOk.Visible = false;
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
                    if (clsStatic.cliente == null)
                    {
                        //cria um novo cadastro
                        clsStatic.cliente = new Cliente()
                        {
                            Ativo = chkAtivo.Checked,
                            Bairro = txtBairro.Text.Trim(),
                            Cep = txtCEP.Text.Trim(),
                            Cpf = txtCPF.Text.Trim(),
                            DtCadastro = DateTime.Now,
                            DtNascimento = dtNascimento.Value,
                            Nome = txtNome.Text.Trim(),
                            Numero = txtNumero.Text.Trim(),
                            Pais = cboPais.Text,
                            Rua = txtRua.Text.Trim(),
                            UF_ID = (int)cboUF.SelectedValue,
                            Cidade = txtCidade.Text.Trim()
                        };

                        if (imgCliente.BackgroundImage != null)
                        {
                            Bitmap bImage = new Bitmap(imgCliente.BackgroundImage);  //Your Bitmap Image
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] byteImage = ms.ToArray();
                            clsStatic.cliente.Imagem = Convert.ToBase64String(byteImage);
                        }

                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            dx.Cliente.Add(clsStatic.cliente);
                            dx.SaveChanges();
                        }
                        MessageBox.Show("Cliente cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //atualiza o cadastro
                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            var cli = dx.Cliente.FirstOrDefault(x => x.Cliente_ID.Equals(clsStatic.cliente.Cliente_ID));
                            if (cli != null)
                            {
                                cli.Ativo = chkAtivo.Checked;
                                cli.Bairro = txtBairro.Text.Trim();
                                cli.Cep = txtCEP.Text.Trim();
                                cli.Cpf = txtCPF.Text.Trim();
                                cli.DtNascimento = dtNascimento.Value;
                                cli.Nome = txtNome.Text.Trim();
                                cli.Numero = txtNumero.Text.Trim();
                                cli.Pais = cboPais.Text;
                                cli.Rua = txtRua.Text.Trim();
                                cli.UF_ID = (int)cboUF.SelectedValue;
                                cli.Cidade = txtCidade.Text.Trim();

                                if (imgCliente.BackgroundImage != null)
                                {
                                    Bitmap bImage = new Bitmap(imgCliente.BackgroundImage);  //Your Bitmap Image
                                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                                    bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    byte[] byteImage = ms.ToArray();
                                    cli.Imagem = Convert.ToBase64String(byteImage);
                                }

                                dx.SaveChanges();
                                btnRefresh_Click(sender, e);
                            }
                        }
                        MessageBox.Show("Cliente atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSave_Click - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaCampos()
        {
            try
            {
                chkAtivo.Checked = clsStatic.cliente.Ativo;
                txtBairro.Text = clsStatic.cliente.Bairro;
                txtCEP.Text = clsStatic.cliente.Cep;
                txtCPF.Text = clsStatic.cliente.Cpf;
                txtDtCadastro.Text = clsStatic.cliente.DtCadastro.ToString("dd/MM/yyyy");
                dtNascimento.Value = clsStatic.cliente.DtNascimento;
                txtNome.Text = clsStatic.cliente.Nome;
                txtNumero.Text = clsStatic.cliente.Numero;
                cboPais.SelectedText = clsStatic.cliente.Pais;
                txtRua.Text = clsStatic.cliente.Rua;
                cboUF.SelectedValue = clsStatic.cliente.UF_ID;
                txtCidade.Text = clsStatic.cliente.Cidade;

                if (!String.IsNullOrEmpty(clsStatic.cliente.Imagem))
                    imgCliente.BackgroundImage = clsUtil.Base64ToImage(clsStatic.cliente.Imagem);
                else
                    imgCliente.BackgroundImage = imgList.Images[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("CarregaCampos - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fBusca_Cliente fBuscaCli = new fBusca_Cliente();
            fBuscaCli.ShowDialog();
            if (clsStatic.cliente == null)
                LimparCampos();
            else
                CarregaCampos();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (clsStatic.cliente != null)
            {
                using (var dx = new dbGreenSoftFinalEntities())
                {
                    clsStatic.cliente = dx.Cliente.FirstOrDefault(x => x.Cliente_ID == clsStatic.cliente.Cliente_ID);
                    CarregaCampos();
                }
            }

        }

        private bool ValidaCampos()
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Informe o nome do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }
            if (txtCPF.Text.Trim() == "")
            {
                MessageBox.Show("Informe o CPF/CNPJ do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Focus();
                return false;
            }
            if (txtRua.Text.Trim() == "")
            {
                MessageBox.Show("Informe a rua do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRua.Focus();
                return false;
            }
            if (txtNumero.Text.Trim() == "")
            {
                MessageBox.Show("Informe o número do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumero.Focus();
                return false;
            }
            if (txtCEP.Text.Trim() == "")
            {
                MessageBox.Show("Informe o CEP do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCEP.Focus();
                return false;
            }
            if (txtCidade.Text.Trim() == "")
            {
                MessageBox.Show("Informe a cidade do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCidade.Focus();
                return false;
            }
            if (txtBairro.Text.Trim() == "")
            {
                MessageBox.Show("Informe o bairro do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBairro.Focus();
                return false;
            }
            if (cboPais.Text.Trim() == "")
            {
                MessageBox.Show("Informe o país do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPais.Focus();
                return false;
            }
            if (cboUF.Text.Trim() == "")
            {
                MessageBox.Show("Informe o estado do cliente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboUF.Focus();
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsStatic.cliente != null)
                {
                    if (MessageBox.Show("Deseja realmente excluir o cadastro do cliente '" + clsStatic.cliente.Nome + "'?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            dx.Cliente.Remove(dx.Cliente.FirstOrDefault(x => x.Cliente_ID == clsStatic.cliente.Cliente_ID));
                            dx.SaveChanges();
                            LimparCampos();
                            clsStatic.cliente = null;
                            imgCliente.BackgroundImage = imgList.Images[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDelete_Click - " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddFotoCam_Click(object sender, EventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                btnOk.Visible = false;
                FinalFrame.Stop();

                if (clsStatic.cliente == null)
                    imgCliente.BackgroundImage = imgList.Images[0];
                else
                {
                    if (String.IsNullOrEmpty(clsStatic.cliente.Imagem))
                        imgCliente.BackgroundImage = imgList.Images[0];
                    else
                    {
                        imgCliente.BackgroundImage = clsUtil.Base64ToImage(clsStatic.cliente.Imagem);
                    }
                }
            }
            else
            {
                btnOk.Visible = true;
                FinalFrame = new VideoCaptureDevice(CaptureDevice[cboCameras.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
                FinalFrame.Start();
            }
        }

        void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs) // must be void so that it can be accessed everywhere.
        {
            imgCliente.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
        }

        private void fCad_Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
                FinalFrame.Stop();
        }

        private void btnAddFoto_Click(object sender, EventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                btnOk.Visible = false;
                FinalFrame.Stop();

                if (clsStatic.cliente == null)
                    imgCliente.BackgroundImage = imgList.Images[0];
                else
                {
                    if (String.IsNullOrEmpty(clsStatic.cliente.Imagem))
                        imgCliente.BackgroundImage = imgList.Images[0];
                    else
                    {
                        imgCliente.BackgroundImage = clsUtil.Base64ToImage(clsStatic.cliente.Imagem);
                    }
                }


            }

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            openFile.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (var files in openFile.FileNames)
                {
                    imgCliente.BackgroundImage = System.Drawing.Image.FromFile(files);
                    imgCliente.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (imgCliente.BackgroundImage != null)
            {
                if (FinalFrame.IsRunning == true)
                {
                    Bitmap foto = new Bitmap(imgCliente.BackgroundImage);
                    imgCliente.BackgroundImage = foto;
                    btnOk.Visible = false;
                    FinalFrame.Stop();
                }
            }
        }
    }
}
