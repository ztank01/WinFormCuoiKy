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
    public partial class ChinhSuaThongTinKhach : Form
    {
        public ChinhSuaThongTinKhach()
        {
            InitializeComponent();
        }
        Khach khach = new Khach();
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

        private void selectPhongBt_Click(object sender, EventArgs e)
        {
            Form frm = new ChonPhongTrongForm();
            frm.ShowDialog();
            phongTb.Text = Globals.SelectedID_Phong.ToString();
        }

        private void selectKhachBt_Click(object sender, EventArgs e)
        {
            Form frm = new ChonKhachForm();
            frm.ShowDialog();
            idTb.Text = Globals.SelectedID_Khach.ToString();
            this.ChinhSuaThongTinKhach_Load(null, null);
        }

        private void ChinhSuaThongTinKhach_Load(object sender, EventArgs e)
        {
            try
            {
                if (idTb.Text.Trim() != "")
                {
                    DataTable table = khach.getKhachById(int.Parse(idTb.Text));
                    fnameTb.Text = table.Rows[0][1].ToString().Trim();
                    lnameTb.Text = table.Rows[0][2].ToString().Trim();
                    phoneTb.Text = table.Rows[0][4].ToString().Trim();
                    datraTb.Text = table.Rows[0][9].ToString().Trim();
                    phongTb.Text = table.Rows[0][8].ToString().Trim();
                    ngaydiDTP.Value = (DateTime)table.Rows[0][7];
                    byte[] pic = (byte[])table.Rows[0][5];
                    MemoryStream picture = new MemoryStream(pic);
                    imgBox.Image = Image.FromStream(picture);
                    string gender = table.Rows[0][3].ToString().Trim();
                    if (gender.Contains("Male"))
                    {
                        maleRBt.Checked = true;
                    }
                    else
                    {
                        femaleRBt.Checked = true;
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Not Found", "Chinh sua thong tin Khach");
            }
            
        }

        private void editBt_Click(object sender, EventArgs e)
        {
            if (verified())
            {
                DateTime ngaydi = ngaydiDTP.Value;
                DateTime thoigiandi = new DateTime(ngaydi.Year, ngaydi.Month, ngaydi.Day, 7, 0, 0);
                string gender = "Female";
                if (maleRBt.Checked)
                {
                    gender = "Male";
                }
                MemoryStream pic = new MemoryStream();
                imgBox.Image.Save(pic, imgBox.Image.RawFormat);
                if (khach.updateKhach(int.Parse(idTb.Text), fnameTb.Text, lnameTb.Text, gender, phoneTb.Text,
                    pic, DateTime.Now, thoigiandi, int.Parse(phongTb.Text), int.Parse(datraTb.Text)))
                {
                    MessageBox.Show("Chinh sua thanh cong", "Chinh sua thong tin Khach");
                    this.ChinhSuaThongTinKhach_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Chinh sua thong tin Khach");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Valid Values", "Chinh sua thong tin Khach", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool verified()
        {
            int tmp;
            bool flag = true;
            if (idTb.Text.Trim() == ""
                || fnameTb.Text.Trim() == ""
                || lnameTb.Text.Trim() == ""
                || phongTb.Text.Trim() == ""
                || imgBox.Image == null
                || phongTb.Text.Trim() == ""
                || datraTb.Text.Trim() == ""
                || (maleRBt.Checked && femaleRBt.Checked))
            {
                flag = false;
            }
            else
            {
                if (DateTime.Now.CompareTo(ngaydiDTP.Value) > 0)
                {
                    flag = false;
                }

            }
            return flag && int.TryParse(idTb.Text, out tmp) && int.TryParse(datraTb.Text, out tmp);
        }
    }
}
