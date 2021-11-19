using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class XoaKhach : Form
    {
        public XoaKhach()
        {
            InitializeComponent();
        }
        Khach khach = new Khach();
        Phong phong = new Phong();
        mydb db = new mydb();
        private void XoaKhach_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Khach", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            customerListDGV.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            customerListDGV.RowTemplate.Height = 80;
            customerListDGV.DataSource = table;
            picCol = (DataGridViewImageColumn)customerListDGV.Columns[5];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            customerListDGV.AllowUserToAddRows = false;
            customerListDGV.Columns[0].HeaderText = "Customer ID";
            customerListDGV.Columns[1].HeaderText = "First Name";
            customerListDGV.Columns[2].HeaderText = "Last Name";
            customerListDGV.Columns[3].HeaderText = "Gender";
            customerListDGV.Columns[4].HeaderText = "Phone";
            customerListDGV.Columns[5].HeaderText = "Picture";
            customerListDGV.Columns[6].HeaderText = "Ngày đến";
            customerListDGV.Columns[7].HeaderText = "Ngày đi";
            customerListDGV.Columns[8].HeaderText = "Phòng";
            customerListDGV.Columns[9].HeaderText = "Đã thanh toán";
        }

        private void customerListDGV_Click(object sender, EventArgs e)
        {
            idTb.Text = customerListDGV.CurrentRow.Cells[0].Value.ToString();
        }

        private void removeBt_Click(object sender, EventArgs e)
        {
            if (idTb.Text.Trim() != "")
            {
                DataTable thongtinKhach = khach.getKhachById(int.Parse(idTb.Text));
                DateTime thoigiandi = (DateTime)thongtinKhach.Rows[0][7];
                DateTime thoigianden = (DateTime)thongtinKhach.Rows[0][6];
                TimeSpan tmp = thoigiandi - thoigianden;
                double songayo = tmp.TotalDays;
                int ngayo = 1 + int.Parse(string.Format("{0:0.000}", songayo)[0].ToString());
                DataTable thongtinPhong = phong.getById(int.Parse(thongtinKhach.Rows[0][8].ToString()));
                int datra = int.Parse(thongtinKhach.Rows[0][9].ToString());
                int giaPhong = int.Parse(thongtinPhong.Rows[0][2].ToString());
                if (datra < giaPhong * songayo)
                {
                    if (MessageBox.Show("Khách chưa trả đủ tiền. Vẫn xóa?","Xoa Khach",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        if (khach.deleteKhach(int.Parse(idTb.Text)))
                        {
                            MessageBox.Show("Da Xoa", "Xoa Khach");
                        }    
                        else
                        {
                            MessageBox.Show("Something Wrong", "Xoa Khach");
                        }    
                    }    
                } 
                else
                {
                    if (khach.deleteKhach(int.Parse(idTb.Text)))
                    {
                        MessageBox.Show("Da Xoa", "Xoa Khach");
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong", "Xoa Khach");
                    }
                }    
            }   
            else
            {
                MessageBox.Show("Please Click in Customer You Want To Remove", "Xoa Khach");
            }    
        }
    }
}
