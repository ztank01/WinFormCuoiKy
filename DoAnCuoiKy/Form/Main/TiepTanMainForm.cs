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
    public partial class TiepTanMainForm : Form
    {
        public TiepTanMainForm()
        {
            InitializeComponent();
        }

        private void themLaoCongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ThemNhanVienForm();
            frm.Show();
        }

        private void duoiViecLaoCongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DuoiViecNhanVienForm();
            frm.Show();
        }

        private void chinhSuaThongTinLaoCongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ChinhSuaThongTinNhanVienForm();
            frm.Show();
        }

        private void danhSachLaoCongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DanhSachNhanVienForm();
            frm.Show();
        }

        private void thayDoiThongRinCaNhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ChinhSuaThongTinCaNhanForm();
            frm.Show();
        }

        private void checkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Check_in_outForm();
            frm.Show();
        }

        private void themPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ThemPhong();
            frm.Show();
        }

        private void chinhSuaPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ChinhSuaThongTinPhong();
            frm.Show();
        }

        private void xoaPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new XoaPhong();
            frm.Show();
        }

        private void danhSachPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DanhSachPhong();
            frm.Show();
        }

        private void themKhachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ThemKhach();
            frm.Show();
        }

        private void chinhSuaThongTinKhachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ChinhSuaThongTinKhach();
            frm.Show();
        }

        private void xoaKhachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new XoaKhach();
            frm.Show();
        }
    }
}
