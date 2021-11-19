using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DoAnCuoiKy
{
    public partial class ThemNhanVienForm : Form
    {
        public ThemNhanVienForm()
        {
            InitializeComponent();
        }
        Account account = new Account();
        private void ThemNhanVienForm_Load(object sender, EventArgs e)
        {
            
            if (Globals.role.Contains("QuanLy"))
            {
                quanlyRBt.Visible = true;
                tieptanRBt.Visible = true;
            }
            else
            {
                if (Globals.role.Contains("TiepTan"))
                {
                    laocongRBt.Checked = true;
                    laocongRBt.Enabled = false;
                }    
            }    
            idTb.Text = (account.getIdMax() + 1).ToString();
        }

        private void uploadBt_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadFileSteam = new OpenFileDialog();

            uploadFileSteam.InitialDirectory = "D:\\Example Image";
            uploadFileSteam.Filter = "Image|*.jpg;*.jfif;*.bmp;*.png";
            uploadFileSteam.FilterIndex = 2;

            if (uploadFileSteam.ShowDialog() == DialogResult.OK)
            {
                //File.Copy(uploadFileSteam.FileName, Directory.GetCurrentDirectory() + "\\Data\\" + stdIDtb.Text +".png");
                this.imgBox.Image = Image.FromFile(uploadFileSteam.FileName);
            }
        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptBt_Click(object sender, EventArgs e)
        {
            if (verified())
            {
                int id = int.Parse(idTb.Text);
                if (quanlyRBt.Checked || tieptanRBt.Checked || laocongRBt.Checked)
                {
                    string role = "";
                    if (quanlyRBt.Checked)
                    {
                        role = "QuanLy";
                    }    
                    else
                    {
                        if (tieptanRBt.Checked)
                        {
                            role = "TiepTan";
                        }    
                        else
                        {
                            role = "LaoCong";
                        }    
                    }    
                    MemoryStream pic = new MemoryStream();
                    imgBox.Image.Save(pic, imgBox.Image.RawFormat);
                    if (MessageBox.Show("Thao tac nay se xoa lich lam viec hien tai, Ban chac chu","Them nhan vien",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (account.insertEmployee(id, usernameTb.Text, passwordTb.Text,
                            role, fnameTb.Text, lnameTb.Text, emailTb.Text, phoneTb.Text, addressTb.Text, pic))
                        {
                            MessageBox.Show("Employee Added", "Them Nhan Vien");
                        }
                        else
                        {
                            MessageBox.Show("Something Wrong", "Them Nhan Vien");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Choose Employee's Role", "Them Nhan Vien");
                }
            }
            else
            {
                MessageBox.Show("Please Enter All Fields","Them Nhan Vien");
            }
        }
        bool verified()
        {
            if ((fnameTb.Text.Trim() == "")
                || (lnameTb.Text.Trim() == "")
                || (phoneTb.Text.Trim() == "")
                || (emailTb.Text.Trim() == "")
                || (addressTb.Text.Trim() == "")
                || (usernameTb.Text.Trim() == "")
                || (passwordTb.Text.Trim() == "")
                || imgBox.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
