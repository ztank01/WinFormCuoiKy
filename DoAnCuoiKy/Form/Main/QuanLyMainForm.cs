using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class QuanLyMainForm : Form
    {
        public QuanLyMainForm()
        {
            InitializeComponent();
        }
        Khach khach = new Khach();
        private void chiaCaLamViecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiaCaLamViecForm frm = new ChiaCaLamViecForm();
            frm.Show();
        }

        private void quanLyTiepTanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ThemNhanVienForm();
            frm.Show();
        }

        private void danhSachNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DanhSachNhanVienForm();
            frm.Show();
        }

        private void chinhSuaQuanLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ChinhSuaThongTinNhanVienForm();
            frm.Show();
        }

        private void themQuanLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DuoiViecNhanVienForm();
            frm.Show();
        }

        private void checkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Check_in_outForm();
            frm.Show();
        }

        private void thayDoiThongTinCaNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ChinhSuaThongTinCaNhanForm();
            frm.Show();
        }

        private void thuChiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ThuChiForm();
            frm.Show();
        }

        private void QuanLyMainForm_Load(object sender, EventArgs e)
        {
            if (khach.getSoKhachNew() > 0)
            {
                if (MessageBox.Show("Trong Lúc Bạn Offline, đã có " + khach.getSoKhachNew().ToString() + " khách mới\nBạn có muốn xem không?",
                    "Thông báo có khách", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Form frm = new DanhSachKhach();
                    frm.ShowDialog();
                }
            }
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

        private void danhSachKhachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DanhSachKhach();
            frm.Show();
        }
    }
}
