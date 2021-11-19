using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAnCuoiKy
{
    public partial class ChiaCaLamViecForm : Form
    {
        public ChiaCaLamViecForm()
        {
            InitializeComponent();
        }
        Account account = new Account();
        LichLamViec lichlv = new LichLamViec();
        private void ChiaCaLamViecForm_Load(object sender, EventArgs e)
        {
            DataTable lichlamviec = lichlv.getLichLamViec();
            qlLb.Text = "So Quan Ly: " + account.countRole("QuanLy").ToString();
            ttLb.Text = "So Tiep Tan: " + account.countRole("TiepTan").ToString();
            lcLb.Text = "So Lao Cong: " + account.countRole("LaoCong").ToString();
            if (lichlamviec.Rows.Count != 0)
            {
                int soTuan = lichlamviec.Rows.Count / 171;
                DataTable table = new DataTable();
                DataColumn clm = new DataColumn();
                clm.ColumnName = "Employee ID";
                table.Columns.Add(clm);
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
                DataTable nvDangLv = lichlv.getAllEmployeeWorking();
                foreach (DataRow r in nvDangLv.Rows)
                {
                    DataRow row = table.NewRow();
                    row[0] = r[0];
                    table.Rows.Add(row);                    
                }
                caLamViecDGV.DataSource = table;
                for (int i =0; i < lichlamviec.Rows.Count; i++)
                {
                    int id = int.Parse(lichlamviec.Rows[i][0].ToString());
                    int ca = int.Parse(lichlamviec.Rows[i][1].ToString());
                    int tuan = int.Parse(lichlamviec.Rows[i][2].ToString());
                    if (account.defineRole(id).Contains("QuanLy"))
                    {
                        if (ca < 15)
                        {
                            int vitri = (ca / 3) * 6 + ca % 3;
                            caLamViecDGV.Rows[id-1].Cells[1 + vitri + tuan*42].Style.BackColor = Color.Lime;
                        }   
                        else
                        {
                            ca -= 15;
                            if (ca < 15)
                            {
                                int vitri = (ca / 3) * 6 + 3 + ca % 3;
                                caLamViecDGV.Rows[id - 1].Cells[1 + vitri + tuan * 42].Style.BackColor = Color.Lime;
                            }   
                            else
                            {
                                ca -= 15;
                                int vitri = (5 + ca / 6) * 6 + ca % 6;
                                caLamViecDGV.Rows[id - 1].Cells[1 + vitri + tuan * 42].Style.BackColor = Color.Lime;
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
                            caLamViecDGV.Rows[id - 1].Cells[1 + vitri + tuan * 42].Style.BackColor = Color.Lime;
                            }
                            else
                            {
                                ca -= 30;
                                if (ca < 15)
                                {
                                    int vitri = (ca / 3) * 6 + 3 + ca % 3;
                                    caLamViecDGV.Rows[id - 1].Cells[1 + vitri + tuan * 42].Style.BackColor = Color.Lime;
                                }
                                else
                                {
                                    ca -= 15;
                                    int vitri = (5 + ca / 6) * 6 + ca % 6;
                                    caLamViecDGV.Rows[id - 1].Cells[1 + vitri + tuan * 42].Style.BackColor = Color.Lime;
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
                            if (ca % 15 == 12  )
                            {
                                vitri += 3;
                            }
                            else
                            if (ca % 15 == 13 )
                            {
                                vitri += 4;
                            }
                            else
                            if (ca % 15 == 14)
                            {
                                vitri += 5;
                            }
                            caLamViecDGV.Rows[id - 1].Cells[1 + vitri + tuan * 42].Style.BackColor = Color.Lime;
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
                                if (ca % 12 == 9 )
                                {
                                    vitri += 3;
                                }
                                else
                                if (ca % 12 == 10 )
                                {
                                    vitri += 4;
                                }
                                else
                                if (ca % 12 == 11 )
                                {
                                    vitri += 5;
                                }
                                caLamViecDGV.Rows[id - 1].Cells[1 + vitri + tuan * 42].Style.BackColor = Color.Lime;
                            }
                        }
                }    
            }
        }

        private void chiaCaBt_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("Thao tac nay se khien lich chia ca cu bi xoa, Ban chac chu?","Bat dau chia ca",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lichlv.deleteLichLamViec();
                Random random = new Random();
                DataTable qlTable = account.getEmployeeByRole("QuanLy");
                DataTable ttTable = account.getEmployeeByRole("TiepTan");
                DataTable lcTable = account.getEmployeeByRole("LaoCong");
                List<int> listql = new List<int>();
                List<int> listtt = new List<int>();
                List<int> listlc = new List<int>();
                for (int i = 0; i < qlTable.Rows.Count; i++)
                {
                    listql.Add(i);
                }
                for (int i = 0; i < ttTable.Rows.Count; i++)
                {
                    listtt.Add(i);
                }
                for (int i = 0; i < lcTable.Rows.Count; i++)
                {
                    listlc.Add(i);
                }
                int rint = random.Next(0, 5);       //tao chuoi truy xuat ngau nhien
                List<int> tmp = new List<int>();
                for (int i = 0; i < rint; i++)
                {
                    tmp.Clear();
                    tmp.AddRange(this.Shuffle(listql));
                    listql.Clear();
                    listql.AddRange(tmp);
                    tmp.Clear();
                    tmp.AddRange(this.Shuffle(listtt));
                    listtt.Clear();
                    listtt.AddRange(tmp);
                    tmp.Clear();
                    tmp.AddRange(this.Shuffle(listlc));
                    listlc.Clear();
                    listlc.AddRange(tmp);
                }
                for (int i =0; i < soTuanNUD.Value; i++)
                {
                    DateTime ngaybd = DateTime.Now;
                    int soCaQl = 15;
                    int soCatt = 30;
                    int soCalc = 99;
                    int soCaQlvstt = 27;
                    int j = 0;
                    while (j < soCaQl)
                    {
                        foreach (int k in listql)
                        {
                            lichlv.insertLichLamViec(int.Parse(qlTable.Rows[k][0].ToString()), j,i,ngaybd);
                            j++;
                            if (j >= soCaQl)
                            {
                                break;
                            }
                        }
                    }
                    j = 0;
                    while (j < soCatt)
                    {
                        foreach (int k in listtt)
                        {
                            lichlv.insertLichLamViec(int.Parse(ttTable.Rows[k][0].ToString()), j,i, ngaybd);
                            j++;
                            if (j >= soCatt)
                            {
                                break;
                            }
                        }
                    }
                    j =0;
                    while (j < soCalc)
                    {
                        foreach (int k in listlc)
                        {
                            lichlv.insertLichLamViec(int.Parse(lcTable.Rows[k][0].ToString()), j,i, ngaybd);
                            j++;
                            if (j >= soCalc)
                            {
                                break;
                            }
                        }
                    }
                    j = 0;
                    while (j < soCaQlvstt)
                    {
                        foreach (int k in listql)
                        {
                            lichlv.insertLichLamViec(int.Parse(qlTable.Rows[k][0].ToString()), 15 + j,i, ngaybd);
                            j++;
                            if (j >= soCaQlvstt)
                            {
                                break;
                            }
                        }
                        foreach (int k in listtt)
                        {
                            lichlv.insertLichLamViec(int.Parse(ttTable.Rows[k][0].ToString()), 30 +j,i, ngaybd);
                            j++;
                            if (j >= soCaQlvstt)
                            {
                                break;
                            }
                        }
                    }
                }
                MessageBox.Show("Da chia ca xong", "Bat dau chia ca", MessageBoxButtons.OK);
                this.ChiaCaLamViecForm_Load(null, null);
            }
        }
        public  IEnumerable<T> Shuffle<T>(IEnumerable<T> sequence)// shuffle list
        {
            //https://www.it-swarm-vi.com/vi/c%23/cach-hieu-qua-nhat-de-sap-xep-ngau-nhien-xao-tron-danh-sach-cac-so-nguyen-trong-c/958058359/
            Random random = new Random();
            T[] retArray = sequence.ToArray();


            for (int i = 0; i < retArray.Length - 1; i += 1)
            {
                int swapIndex = random.Next(i, retArray.Length);
                if (swapIndex != i)
                {
                    T temp = retArray[i];
                    retArray[i] = retArray[swapIndex];
                    retArray[swapIndex] = temp;
                }
            }

            return retArray;
        }

    }
}
