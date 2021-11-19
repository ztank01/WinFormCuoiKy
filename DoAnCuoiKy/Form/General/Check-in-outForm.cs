using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class Check_in_outForm : Form
    {
        public Check_in_outForm()
        {
            InitializeComponent();
        }
        Account account = new Account();
        LichLamViec lichlv = new LichLamViec();
        int ngayHientai = 0;
        CheckInOut inOut = new CheckInOut();
        private void checkinBt_Click(object sender, EventArgs e)
        {
            if (Globals.role.Contains("QuanLy"))
            {
                MessageBox.Show("Bạn không cần phải check-in", "Check in", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int ca = this.caHienTai();
                if (caLamViecDGV.Rows[0].Cells[ngayHientai * 6 + ca].Style.BackColor.Name.Contains(Color.Lime.Name))
                {
                    Globals.CheckInTime = DateTime.Now;
                    MessageBox.Show("Check in at " + Globals.CheckInTime.ToString("T"), "Check in");
                    this.Check_in_outForm_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Hiện tại không trong ca làm", "Check in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }    
        }

        private void checkoutBt_Click(object sender, EventArgs e)
        {
            int time = 0;
            if (DateTime.Compare(Globals.CheckInTime,new DateTime()) != 0)
            {
                TimeSpan khoangTg = DateTime.Now - Globals.CheckInTime;
                time = int.Parse(string.Format("{0:0.000}", khoangTg.TotalHours)[0].ToString());
                if (inOut.insertCheckIn(Globals.CheckInTime,DateTime.Now,ngayHientai,time,Globals.ShiftinDay) )
                {
                    MessageBox.Show("Check in out at " + DateTime.Now.ToString("T") + " \nWork time: " + time.ToString(),
                    "Check out");
                    this.Check_in_outForm_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Something Wrong","Check out");
                }
            }
            else
            {
                MessageBox.Show("Please Check In First", "Check out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }
        private void Check_in_outForm_Load(object sender, EventArgs e)
        {
            //Load ca làm vào DGV
            this.loadDGV();
            //Xác định ngày hiện tại
            DataTable caLam = lichlv.getLichLamViecById(Globals.GlobalUserId);
            DateTime ngayBd = (DateTime)caLam.Rows[0][3];
            TimeSpan tmp = DateTime.Now - ngayBd;
            double songay = tmp.TotalDays;
            ngayHientai = int.Parse(string.Format("{0:0.000}", songay)[0].ToString()) ;
            if (DateTime.Now.Hour < 7)
            {
                ngayHientai-=1;
            }
            //Lấy thông tin User
            DataTable table = account.getEmployeeById(Globals.GlobalUserId);
            welcomeLb.Text = "Welcome " + table.Rows[0][4].ToString().Trim() + " " + table.Rows[0][5].ToString().Trim() + "(" + table.Rows[0][1].ToString().Trim() + ")";
            byte[] pic = (byte[])table.Rows[0][9];
            MemoryStream picture = new MemoryStream(pic);
            imgBox.Image = Image.FromStream(picture);
            //Xác định số ca trong ngày của nhân viên này
            int soCaLam = 0;
            for(int i = 0; i < 6; i++)
            {
                if (caLamViecDGV.Rows[0].Cells[ngayHientai * 6 + i].Style.BackColor.Name.Contains(Color.Lime.Name))
                {
                    soCaLam++;
                }    
            }
            Globals.ShiftinDay = soCaLam;
            //Xác định ca làm hiện tại
            int gioHienTai = DateTime.Now.Hour;
            if ( gioHienTai >= 7 && gioHienTai < 11)
            {
                shiftLb.Text = "Ca hiện tại: Sáng ngày ";
            }
            else
                if (gioHienTai >= 11 && gioHienTai < 15)
                {
                    shiftLb.Text = "Ca hiện tại: Trưa ngày ";
                }
                else
                    if (gioHienTai >= 15 && gioHienTai < 19)
                    {
                        shiftLb.Text = "Ca hiện tại: Chiều ngày ";
                    }
                    else
                        if (gioHienTai >= 19 && gioHienTai < 23)
                        {
                            shiftLb.Text = "Ca hiện tại: Tối ngày ";
                        }
                        else
                            if (gioHienTai >= 23 || gioHienTai < 3)
                            {
                                shiftLb.Text = "Ca hiện tại: Khuya ngày ";
                            }
                            else
                                if (gioHienTai >= 3 && gioHienTai < 7)
                                {
                                    shiftLb.Text = "Ca hiện tại: Sáng sớm ngày ";
                                }
            shiftLb.Text += (ngayHientai + 1).ToString();            
        }
        private void loadDGV()
        {
            DataTable lichlamviec = lichlv.getLichLamViecById(Globals.GlobalUserId);
            if (lichlamviec.Rows.Count != 0)
            {
                int soTuan = lichlv.getSoTuanLamViec();
                DataTable table = new DataTable();
                for (int i = 0; i < soTuan * 42; i++)
                {
                    DataColumn tmp = new DataColumn();
                    int flag = i % 6;
                    switch (flag)
                    {
                        case 0:
                            tmp.ColumnName = "Sáng ngày " + int.Parse((i / 6 + 1).ToString()).ToString();
                            break;
                        case 1:
                            tmp.ColumnName = "Trưa ngày " + int.Parse((i / 6 + 1).ToString()).ToString();
                            break;
                        case 2:
                            tmp.ColumnName = "Chiều ngày " + int.Parse((i / 6 + 1).ToString()).ToString();
                            break;
                        case 3:
                            tmp.ColumnName = "Tối ngày " + int.Parse((i / 6 + 1).ToString()).ToString();
                            break;
                        case 4:
                            tmp.ColumnName = "Khuya ngày " + int.Parse((i / 6 + 1).ToString()).ToString();
                            break;
                        case 5:
                            tmp.ColumnName = "Sáng Sớm ngày " + int.Parse((i / 6 + 1).ToString()).ToString();
                            break;
                    }
                    table.Columns.Add(tmp);
                }
                caLamViecDGV.DataSource = table;
                for (int i = 0; i < lichlamviec.Rows.Count; i++)
                {
                    int id = int.Parse(lichlamviec.Rows[i][0].ToString());
                    int ca = int.Parse(lichlamviec.Rows[i][1].ToString());
                    int tuan = int.Parse(lichlamviec.Rows[i][2].ToString());
                    if (account.defineRole(id).Contains("QuanLy"))
                    {
                        if (ca < 15)
                        {
                            int vitri = (ca / 3) * 6 + ca % 3;
                            caLamViecDGV.Rows[0].Cells[vitri + tuan * 42].Style.BackColor = Color.Lime;
                        }
                        else
                        {
                            ca -= 15;
                            if (ca < 15)
                            {
                                int vitri = (ca / 3) * 6 + 3 + ca % 3;
                                caLamViecDGV.Rows[0].Cells[vitri + tuan * 42].Style.BackColor = Color.Lime;
                            }
                            else
                            {
                                ca -= 15;
                                int vitri = (5 + ca / 6) * 6 + ca % 6;
                                caLamViecDGV.Rows[0].Cells[vitri + tuan * 42].Style.BackColor = Color.Lime;
                            }
                        }
                    }
                    else
                        if (account.defineRole(int.Parse(lichlamviec.Rows[i][0].ToString())).Contains("TiepTan"))
                        {
                        if (ca < 30)
                        {
                            int vitri = (ca / 6) * 6;
                            if (ca % 6 == 0 || ca % 6 == 1)
                            {
                                vitri += 0;
                            }
                            else
                            if (ca % 6 == 2 || ca % 6 == 3)
                            {
                                vitri += 1;
                            }
                            else
                            if (ca % 6 == 4 || ca % 6 == 5)
                            {
                                vitri += 2;
                            }
                            caLamViecDGV.Rows[0].Cells[vitri + tuan * 42].Style.BackColor = Color.Lime;
                        }
                        else
                        {
                            ca -= 30;
                            if (ca < 15)
                            {
                                int vitri = (ca / 3) * 6 + 3 + ca % 3;
                                caLamViecDGV.Rows[0].Cells[vitri + tuan * 42].Style.BackColor = Color.Lime;
                            }
                            else
                            {
                                ca -= 15;
                                int vitri = (5 + ca / 6) * 6 + ca % 6;
                                caLamViecDGV.Rows[0].Cells[vitri + tuan * 42].Style.BackColor = Color.Lime;
                            }
                        }
                    }
                    else
                        if (account.defineRole(int.Parse(lichlamviec.Rows[i][0].ToString())).Contains("LaoCong"))
                    {
                        if (ca < 75)
                        {
                            int vitri = (ca / 15) * 6;
                            if (ca % 15 == 0 || ca % 15 == 1 || ca % 15 == 2 || ca % 15 == 3)
                            {
                                vitri += 0;
                            }
                            else
                            if (ca % 15 == 4 || ca % 15 == 5 || ca % 15 == 6 || ca % 15 == 7)
                            {
                                vitri += 1;
                            }
                            else
                            if (ca % 15 == 8 || ca % 15 == 9 || ca % 15 == 10 || ca % 15 == 11)
                            {
                                vitri += 2;
                            }
                            else
                            if (ca % 15 == 12)
                            {
                                vitri += 3;
                            }
                            else
                            if (ca % 15 == 13)
                            {
                                vitri += 4;
                            }
                            else
                            if (ca % 15 == 14)
                            {
                                vitri += 5;
                            }
                            caLamViecDGV.Rows[0].Cells[vitri + tuan * 42].Style.BackColor = Color.Lime;
                        }
                        else
                        {
                            ca -= 75;
                            int vitri = (5 + ca / 12) * 6;
                            if (ca % 12 == 0 || ca % 12 == 1 || ca % 12 == 2)
                            {
                                vitri += 0;
                            }
                            else
                            if (ca % 12 == 3 || ca % 12 == 4 || ca % 12 == 5)
                            {
                                vitri += 1;
                            }
                            else
                            if (ca % 12 == 6 || ca % 12 == 7 || ca % 12 == 8)
                            {
                                vitri += 2;
                            }
                            else
                            if (ca % 12 == 9)
                            {
                                vitri += 3;
                            }
                            else
                            if (ca % 12 == 10)
                            {
                                vitri += 4;
                            }
                            else
                            if (ca % 12 == 11)
                            {
                                vitri += 5;
                            }
                            caLamViecDGV.Rows[0].Cells[vitri + tuan * 42].Style.BackColor = Color.Lime;
                        }
                    }
                }
            }
        }
        private int caHienTai()
        {
            int gioHienTai = DateTime.Now.Hour;
            int ca = 0;
                if (gioHienTai >= 11 && gioHienTai < 15)
                {
                ca =  1;
                }
                else
                    if (gioHienTai >= 15 && gioHienTai < 19)
                    {
                    ca =  2;
                    }
                    else
                        if (gioHienTai >= 19 && gioHienTai < 23)
                        {
                            ca =  3;
                        }
                        else
                            if (gioHienTai >= 23 || gioHienTai < 3)
                            {
                                ca =  4;
                            }
                            else
                                if (gioHienTai >= 3 && gioHienTai < 7)
                                {
                                    ca =  5;
                                }
            return ca;
        }
    }
}
