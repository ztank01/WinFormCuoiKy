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
    public partial class ChonPhongForm : Form
    {
        public ChonPhongForm()
        {
            InitializeComponent();
        }
        Phong phong = new Phong();
        private void ChonPhongForm_Load(object sender, EventArgs e)
        {
            roomListDGV.DataSource = phong.getAll();
            roomListDGV.Columns[0].HeaderText = "Phòng";
            roomListDGV.Columns[1].HeaderText = "Hạng";
            roomListDGV.Columns[2].HeaderText = "Giá 1 ngày";
        }

        private void roomListDGV_DoubleClick(object sender, EventArgs e)
        {
            Globals.SelectedID_Phong = int.Parse(roomListDGV.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }
    }
}
