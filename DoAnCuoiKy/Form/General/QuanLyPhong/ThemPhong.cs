using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class ThemPhong : Form
    {
        public ThemPhong()
        {
            InitializeComponent();
        }
        Phong phong = new Phong();
        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool verified()
        {
            int kw;
            return int.TryParse(idTb.Text, out kw) && int.TryParse(hangCbB.Text, out kw) && int.TryParse(giaTb.Text, out kw);
    
        }

        private void addBt_Click(object sender, EventArgs e)
        {
            if (verified())
            {
                if ( !(phong.exists(int.Parse(idTb.Text))) )
                {
                    if (phong.insertPhong(int.Parse(idTb.Text), int.Parse(hangCbB.Text), int.Parse(giaTb.Text)))
                    {
                        MessageBox.Show("Them Phong Thanh Cong", "Them Phong");
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong", "Them Phong");
                    }
                }
                else
                {
                    MessageBox.Show("Phong da ton tai", "Them Phong");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Valid Values","Them Phong",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void hangCbB_SelectedValueChanged(object sender, EventArgs e)
        {
            int hang = int.Parse(hangCbB.Text);
            if (hang == 1)
            {
                giaTb.Text = "500";
            }
            else
                if (hang == 2)
                {
                    giaTb.Text = "300";
                }
                else
                {
                    giaTb.Text = "200";
                }
        }

        private void ThemPhong_Load(object sender, EventArgs e)
        {
            if (Globals.role.Contains("QuanLy"))
            {
                giaTb.Enabled = true;
            }
        }
    }
}
