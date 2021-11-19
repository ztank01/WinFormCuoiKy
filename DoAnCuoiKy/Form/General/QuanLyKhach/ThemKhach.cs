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
    public partial class ThemKhach : Form
    {
        public ThemKhach()
        {
            InitializeComponent();
            
        }
        Khach khach = new Khach();
        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectBt_Click(object sender, EventArgs e)
        {
            Form frm = new ChonPhongTrongForm();
            frm.ShowDialog();
            phongTb.Text = Globals.SelectedID_Phong.ToString();
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

        private void addBt_Click(object sender, EventArgs e)
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
                if (khach.insertKhach(int.Parse(idTb.Text),fnameTb.Text,lnameTb.Text,gender,phoneTb.Text,
                    pic,DateTime.Now,thoigiandi,int.Parse(phongTb.Text),int.Parse(datraTb.Text)) )
                {
                    MessageBox.Show("Da them", "Them Khach");
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Them Khach");
                }    
            }   
            else
            {
                MessageBox.Show("Please Enter Valid Values", "Them Khach", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                || (maleRBt.Checked && femaleRBt.Checked ))
            {
                flag = false;
            }
            else
            {
                if ( DateTime.Now.CompareTo(ngaydiDTP.Value) > 0 )
                {
                    flag = false;
                }    
                
            }
            return flag && int.TryParse(idTb.Text, out tmp) && int.TryParse(datraTb.Text,out tmp);
        }
    }
}
