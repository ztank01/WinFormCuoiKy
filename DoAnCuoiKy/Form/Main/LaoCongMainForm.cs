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
    public partial class LaoCongMainForm : Form
    {
        public LaoCongMainForm()
        {
            InitializeComponent();
        }

        private void checkInoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Check_in_outForm();
            frm.Show();
        }
    }
}
