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
    public partial class ThuChiForm : Form
    {
        public ThuChiForm()
        {
            InitializeComponent();
        }

        private void tinhTienLuongBt_Click(object sender, EventArgs e)
        {
            Form frm = new BangLuongForm();
            frm.Show();
        }

        private void ThuChiForm_Load(object sender, EventArgs e)
        {
            
        }

        private void xemKhoanThuBt_Click(object sender, EventArgs e)
        {
            Form frm = new KhoanThuForm();
            frm.Show();
        }
    }
}
