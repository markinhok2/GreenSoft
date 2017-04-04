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
    public partial class fCad_Usuario : Form
    {
        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;

        public fCad_Usuario()
        {
            InitializeComponent();
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
                            if (innerControl.GetType() == txtNome.GetType())
                            {
                                innerControl.Text = "";
                            }
                            if (innerControl.GetType() == cboCooperativas.GetType())
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
                clsStatic.usuario_temp = null;
                if (FinalFrame.IsRunning == true)
                    FinalFrame.Stop();

                imgUsuario.BackgroundImage = imgList.Images[0] ;
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
                    if (clsStatic.usuario_temp == null)
                    {
                        //cria um novo cadastro
                        clsStatic.usuario_temp = new Usuario()
                        {
                            Ativo = chkAtivo.Checked,
                            Nome = txtNome.Text.Trim(),
                            Username = txtUsername.Text.Trim(),
                            Cooperativa_ID = (int)cboCooperativas.SelectedValue,
                            Senha = txtSenha.Text.Trim(),
                            Email = txtEmail.Text.Trim()
                        };

                        if (rbBalcao.Checked)
                            clsStatic.usuario_temp.StBalcao = true;
                        else
                            clsStatic.usuario_temp.StBalcao = false;

                        if (imgUsuario.BackgroundImage != null)
                        {
                            Bitmap bImage = new Bitmap(imgUsuario.BackgroundImage);  //Your Bitmap Image
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] byteImage = ms.ToArray();
                            clsStatic.usuario_temp.Imagem = Convert.ToBase64String(byteImage);
                        }

                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            dx.Usuario.Add(clsStatic.usuario_temp);
                            dx.SaveChanges();
                            CarregaCampos();
                        }
                        MessageBox.Show("Usuário cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //atualiza o cadastro
                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            var user = dx.Usuario.FirstOrDefault(x => x.Usuario_ID.Equals(clsStatic.usuario_temp.Usuario_ID));
                            if (user != null)
                            {
                                user.Ativo = chkAtivo.Checked;
                                user.Nome = txtNome.Text.Trim();
                                user.Username = txtUsername.Text.Trim();
                                user.Cooperativa_ID = (int)cboCooperativas.SelectedValue;
                                user.Senha = txtSenha.Text.Trim();
                                user.Email = txtEmail.Text.Trim();

                                if (rbBalcao.Checked)
                                    user.StBalcao = true;
                                else
                                    user.StBalcao = false;

                                if (imgUsuario.BackgroundImage != null)
                                {
                                    Bitmap bImage = new Bitmap(imgUsuario.BackgroundImage);  //Your Bitmap Image
                                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                                    bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    byte[] byteImage = ms.ToArray();
                                    user.Imagem = Convert.ToBase64String(byteImage);
                                }

                                dx.SaveChanges();
                                btnRefresh_Click(sender, e);
                            }
                        }
                        MessageBox.Show("Usuário atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Informe nome do usuário", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Informe o username do usuário", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return false;
            }
            if (txtSenha.Text.Trim() == "")
            {
                MessageBox.Show("Informe a senha do usuário", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Focus();
                return false;
            }
            if (cboCooperativas.Text.Trim() == "")
            {
                MessageBox.Show("Informe a cooperativa do usuário", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboCooperativas.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Informe o e-mail do usuário", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (clsStatic.usuario_temp != null)
            {
                using (var dx = new dbGreenSoftFinalEntities())
                {
                    clsStatic.usuario_temp = dx.Usuario.FirstOrDefault(x => x.Usuario_ID == clsStatic.usuario_temp.Usuario_ID);
                    CarregaCampos();
                }
            }
        }

        private void CarregaCampos()
        {
            try
            {
                txtIdUsuario.Text = clsStatic.usuario_temp.Usuario_ID.ToString();
                chkAtivo.Checked = clsStatic.usuario_temp.Ativo;
                txtNome.Text = clsStatic.usuario_temp.Nome;
                txtUsername.Text = clsStatic.usuario_temp.Username;
                txtEmail.Text = clsStatic.usuario_temp.Email;
                cboCooperativas.SelectedValue = clsStatic.usuario_temp.Cooperativa_ID;
                txtSenha.Text = clsStatic.usuario_temp.Senha.Trim();

                if (!String.IsNullOrEmpty(clsStatic.usuario_temp.Imagem))
                    imgUsuario.BackgroundImage = clsUtil.Base64ToImage(clsStatic.usuario_temp.Imagem);
                else
                    imgUsuario.BackgroundImage = imgList.Images[0];
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
                if (clsStatic.usuario_temp != null)
                {
                    if (MessageBox.Show("Deseja realmente excluir o cadastro do usuário '" + clsStatic.usuario_temp.Username + "'?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        using (var dx = new dbGreenSoftFinalEntities())
                        {
                            dx.Usuario.Remove(dx.Usuario.FirstOrDefault(x => x.Usuario_ID == clsStatic.usuario_temp.Usuario_ID));
                            dx.SaveChanges();
                            LimparCampos();
                            clsStatic.usuario_temp = null;
                            imgUsuario.BackgroundImage = imgList.Images[0];
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
            fBusca_Usuario fBuscaUser = new fBusca_Usuario();
            fBuscaUser.ShowDialog();

            if (clsStatic.usuario_temp == null)
                LimparCampos();
            else
                CarregaCampos();
        }

        private void fCad_Usuario_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
            foreach (FilterInfo Device in CaptureDevice)
                cboCameras.Items.Add(Device.Name);

            imgUsuario.BackgroundImage = imgList.Images[0];

            cboCameras.SelectedIndex = 0; // default
            FinalFrame = new VideoCaptureDevice();

            //cboCooperativas.SelectedIndex = 0;
            using (var dx = new Data.dbGreenSoftFinalEntities())
            {
                var qryUFs = (from c in dx.Cooperativa
                              orderby c.Cooperativa_ID
                              select new
                              {
                                  CoopID = c.Cooperativa_ID,
                                  CoopNome = c.Razao
                              }).ToList();

                qryUFs.Insert(0, new { CoopID = 0, CoopNome = "" });

                cboCooperativas.DataSource = qryUFs;
                cboCooperativas.DisplayMember = "CoopNome";
                cboCooperativas.ValueMember = "CoopID";
            }
        }

        private void btnAddFoto_Click(object sender, EventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                btnOk.Visible = false;
                FinalFrame.Stop();

                if (clsStatic.usuario_temp == null)
                    imgUsuario.BackgroundImage = imgList.Images[0];
                else
                {
                    if (String.IsNullOrEmpty(clsStatic.usuario_temp.Imagem))
                        imgUsuario.BackgroundImage = imgList.Images[0];
                    else
                    {
                        imgUsuario.BackgroundImage = clsUtil.Base64ToImage(clsStatic.usuario_temp.Imagem);
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
                    imgUsuario.BackgroundImage = System.Drawing.Image.FromFile(files);
                    imgUsuario.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }

        private void btnAddFotoCam_Click(object sender, EventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                btnOk.Visible = false;
                FinalFrame.Stop();

                if (clsStatic.usuario_temp == null)
                    imgUsuario.BackgroundImage = imgList.Images[0];
                else
                {
                    if (String.IsNullOrEmpty(clsStatic.usuario_temp.Imagem))
                        imgUsuario.BackgroundImage = imgList.Images[0];
                    else
                    {
                        imgUsuario.BackgroundImage = clsUtil.Base64ToImage(clsStatic.usuario_temp.Imagem);
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
            imgUsuario.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (imgUsuario.BackgroundImage != null)
            {
                if (FinalFrame.IsRunning == true)
                {
                    Bitmap foto = new Bitmap(imgUsuario.BackgroundImage);
                    imgUsuario.BackgroundImage = foto;
                    btnOk.Visible = false;
                    FinalFrame.Stop();
                }
            }
        }

        private void fCad_Usuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
                FinalFrame.Stop();
        }
    }
}
