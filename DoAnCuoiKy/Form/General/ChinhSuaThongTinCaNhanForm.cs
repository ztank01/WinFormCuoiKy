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
    public partial class ChinhSuaThongTinCaNhanForm : Form
    {
        public ChinhSuaThongTinCaNhanForm()
        {
            InitializeComponent();
        }
        Account account = new Account();
        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChinhSuaThongTinCaNhanForm_Load(object sender, EventArgs e)
        {
            DataTable table = account.getEmployeeById(Globals.GlobalUserId);
            idTb.Text = Globals.GlobalUserId.ToString();
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
                    if (MessageBox.Show("Thao tac nay se xoa lich lam viec hien tai, Ban chac chu", "Chinh sua thong tin ca nhan",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (account.updateEmployee(id, usernameTb.Text, passwordTb.Text,
                        role, fnameTb.Text, lnameTb.Text, emailTb.Text, phoneTb.Text, addressTb.Text, pic))
                        {
                            MessageBox.Show("Employee Edited", "Chinh sua thong tin ca nhan");
                        }
                        else
                        {
                            MessageBox.Show("Something Wrong", "Chinh sua thong tin ca nhan");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Choose Employee's Role", "Chinh sua thong tin ca nhan");
                }
            }
            else
            {
                MessageBox.Show("Please Enter All Fields", "Chinh sua thong tin ca nhan");
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
