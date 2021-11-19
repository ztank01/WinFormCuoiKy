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
    public partial class XoaPhong : Form
    {
        public XoaPhong()
        {
            InitializeComponent();
        }
        Phong phong = new Phong();
        private void XoaPhong_Load(object sender, EventArgs e)
        {
            roomListDGV.DataSource = phong.getAll();
            roomListDGV.Columns[0].HeaderText = "Phòng";
            roomListDGV.Columns[1].HeaderText = "Hạng";
            roomListDGV.Columns[2].HeaderText = "Giá 1 ngày";
        }

        private void roomListDGV_DoubleClick(object sender, EventArgs e)
        {
            idTb.Text = roomListDGV.CurrentRow.Cells[0].Value.ToString();
        }

        private void removeBt_Click(object sender, EventArgs e)
        {
            if (idTb.Text == "")
            {
                if (phong.deletePhong(int.Parse(idTb.Text)))
                {
                    MessageBox.Show("Da xoa", "Xoa Phong");
                    this.XoaPhong_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Xoa Phong");
                }
            }
            else
            {
                MessageBox.Show("Please Double Click in Room You Want To Remove", "Xoa Phong");
            }    
        }
    }
}
