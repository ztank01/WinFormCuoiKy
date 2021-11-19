using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class ChinhSuaThongTinNhanVienForm : Form
    {
        public ChinhSuaThongTinNhanVienForm()
        {
            InitializeComponent();
        }
        Account account = new Account();
        private void ChinhSuaThongTinNhanVienForm_Load(object sender, EventArgs e)
        {
            if (Globals.role.Contains("QuanLy"))
            {
                tieptanRBt.Visible = true;
            }
            if (Globals.role.Contains("QuanLy"))
            {
                quanlyRBt.Enabled = true;
                tieptanRBt.Enabled = true;
                laocongRBt.Enabled = true;
            }
            if (idTb.Text !="")
            {
                DataTable table = account.getEmployeeById(int.Parse(idTb.Text));
                if (table.Rows.Count != 0)
                {
                    usernameTb.Text = table.Rows[0][1].ToString();
                    passwordTb.Text = table.Rows[0][2].ToString();
                    fnameTb.Text = table.Rows[0][4].ToString();
                    lnameTb.Text = table.Rows[0][5].ToString();
                    emailTb.Text = table.Rows[0][6].ToString();
                    phoneTb.Text = table.Rows[0][7].ToString();
                    addressTb.Text = table.Rows[0][8].ToString();
                    string role = table.Rows[0][3].ToString();
                    if (role.Contains("QuanLy"))
                    {
                        quanlyRBt.Checked = true;
                    }
                    else
                    {
                        if (role.Contains("TiepTan"))
                        {
                            tieptanRBt.Checked = true;
                        }
                        else
                        {
                            laocongRBt.Checked = true;
                        }
                    }
                    byte[] pic = (byte[])table.Rows[0][9];
                    MemoryStream picture = new MemoryStream(pic);
                    imgBox.Image = Image.FromStream(picture);
                }
                else
                {
                    MessageBox.Show("Not Found","Chinh Sua Nhan Vien");
                }
            }
        }

        private void selectBt_Click(object sender, EventArgs e)
        {
            Form frm = new SelectAccountForm();
            frm.ShowDialog();
            idTb.Text = Globals.SelectedID.ToString(); ;
            this.ChinhSuaThongTinNhanVienForm_Load(null, null);
        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editBt_Click(object sender, EventArgs e)
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
                    if (MessageBox.Show("Thao tac nay se xoa lich lam viec hien tai, Ban chac chu", "Chinh sua thong tin nhan vien",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (account.updateEmployee(id, usernameTb.Text, passwordTb.Text,
                        role, fnameTb.Text, lnameTb.Text, emailTb.Text, phoneTb.Text, addressTb.Text, pic))
                        {
                            MessageBox.Show("Employee Edited", "Chinh sua thong tin nhan vien");
                        }
                        else
                        {
                            MessageBox.Show("Something Wrong", "Chinh sua thong tin nhan vien");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Choose Employee's Role", "Chinh sua thong tin nhan vien");
                }
            }
            else
            {
                MessageBox.Show("Please Enter All Fields", "Chinh sua thong tin nhan vien");
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
    }
}
