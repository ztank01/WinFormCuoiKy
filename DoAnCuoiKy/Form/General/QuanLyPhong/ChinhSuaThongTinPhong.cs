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
    public partial class ChinhSuaThongTinPhong : Form
    {
        public ChinhSuaThongTinPhong()
        {
            InitializeComponent();
        }
        Phong phong = new Phong();
        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectBt_Click(object sender, EventArgs e)
        {
            Form frm = new ChonPhongForm();
            frm.ShowDialog();
            idTb.Text = Globals.SelectedID_Phong.ToString();
            this.ChinhSuaThongTinPhong_Load(null, null);
        }

        private void ChinhSuaThongTinPhong_Load(object sender, EventArgs e)
        {
            if (idTb.Text.Trim() != "" )
            {
                hangCbB.Text = "";
                DataTable table = phong.getById(int.Parse(idTb.Text));
                hangCbB.Text = table.Rows[0][1].ToString();
                giaTb.Text = table.Rows[0][2].ToString();
            }
            if (Globals.role.Contains("QuanLy"))
            {
                giaTb.Enabled = true;
            }    
        }

        private void editBt_Click(object sender, EventArgs e)
        {
            if (verified())
            {
                    if (phong.updatePhong(int.Parse(idTb.Text), int.Parse(hangCbB.Text), int.Parse(giaTb.Text)))
                    {
                        MessageBox.Show("Chinh Sua Phong Thanh Cong", "Chinh Sua Phong");
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong", "Chinh Sua Phong");
                    }
            }
            else
            {
                MessageBox.Show("Please Enter Valid Values", "Chinh Sua Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool verified()
        {
            int kw;
            return int.TryParse(idTb.Text, out kw) && int.TryParse(hangCbB.Text, out kw) && int.TryParse(giaTb.Text, out kw);

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
    }
}
