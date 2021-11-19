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
    public partial class DanhSachPhong : Form
    {
        public DanhSachPhong()
        {
            InitializeComponent();
        }
        Phong phong = new Phong();
        private bool verified()
        {
            int kw;
            return int.TryParse(idTb.Text, out kw) && int.TryParse(hangCbB.Text, out kw) && int.TryParse(giaTb.Text, out kw);

        }
        private void DanhSachPhong_Load(object sender, EventArgs e)
        {
            if (Globals.role.Contains("QuanLy"))
            {
                giaTb.Enabled = true;
            }
            roomListDGV.DataSource = phong.getAll();
            roomListDGV.Columns[0].HeaderText = "Phòng";
            roomListDGV.Columns[1].HeaderText = "Hạng";
            roomListDGV.Columns[2].HeaderText = "Giá 1 ngày";
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

        private void roomListDGV_Click(object sender, EventArgs e)
        {
            hangCbB.Text = "";
            idTb.Text = roomListDGV.CurrentRow.Cells[0].Value.ToString();
            hangCbB.Text = roomListDGV.CurrentRow.Cells[1].Value.ToString();
            giaTb.Text = roomListDGV.CurrentRow.Cells[2].Value.ToString();
        }

        private void addBt_Click(object sender, EventArgs e)
        {
            if (verified())
            {
                if (!(phong.exists(int.Parse(idTb.Text))))
                {
                    if (phong.insertPhong(int.Parse(idTb.Text), int.Parse(hangCbB.Text), int.Parse(giaTb.Text)))
                    {
                        MessageBox.Show("Them Phong Thanh Cong", "Them Phong");
                        this.DanhSachPhong_Load(null, null);
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
                MessageBox.Show("Please Enter Valid Values", "Them Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editBt_Click(object sender, EventArgs e)
        {
            if (verified())
            {
                if (phong.updatePhong(int.Parse(idTb.Text), int.Parse(hangCbB.Text), int.Parse(giaTb.Text)))
                {
                    MessageBox.Show("Chinh Sua Phong Thanh Cong", "Chinh Sua Phong");
                    this.DanhSachPhong_Load(null, null);
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

        private void removeBt_Click(object sender, EventArgs e)
        {
            if (idTb.Text == "")
            {
                if (phong.deletePhong(int.Parse(idTb.Text)))
                {
                    MessageBox.Show("Da xoa", "Xoa Phong");
                    this.DanhSachPhong_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Xoa Phong");
                }
            }
            else
            {
                MessageBox.Show("Please Click in Room You Want To Remove", "Xoa Phong");
            }
        }
    }
}
