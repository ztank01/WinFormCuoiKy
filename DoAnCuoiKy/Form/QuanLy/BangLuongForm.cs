using System;
using System.Windows.Forms;
using System.Data;
using Microsoft.Office.Interop.Word;

namespace DoAnCuoiKy
{
    public partial class BangLuongForm : Form
    {
        public BangLuongForm()
        {
            InitializeComponent();
        }
        CheckInOut inOut = new CheckInOut();
        Account account = new Account();
        LichLamViec lichlv = new LichLamViec();
        int ngayHientai = 0;
        private void BangLuongForm_Load(object sender, EventArgs e)
        {
            //Xác định ngày hiện tại
            System.Data.DataTable caLam = lichlv.getLichLamViecById(Globals.GlobalUserId);
            DateTime ngayBd = (DateTime)caLam.Rows[0][3];
            TimeSpan tmp = DateTime.Now - ngayBd;
            double songay = tmp.TotalDays;
            ngayHientai = int.Parse(string.Format("{0:0.000}", songay)[0].ToString());
            if (DateTime.Now.Hour < 7)
            {
                ngayHientai -= 1;
            }
            //Định dạng DGV
            System.Data.DataTable table = new System.Data.DataTable();
            DataColumn clm0 = new DataColumn();
            clm0.ColumnName = "ID";
            table.Columns.Add(clm0);
            DataColumn clm1 = new DataColumn();
            clm1.ColumnName = "Tên NV";
            table.Columns.Add(clm1);
            DataColumn clm2 = new DataColumn();
            clm2.ColumnName = "Họ NV";
            table.Columns.Add(clm2);
            DataColumn clm3 = new DataColumn();
            clm3.ColumnName = "Thời gian làm việc";
            table.Columns.Add(clm3);
            DataColumn clm4 = new DataColumn();
            clm4.ColumnName = "Số ca trong ngày";
            table.Columns.Add(clm4);
            DataColumn clm5 = new DataColumn();
            clm5.ColumnName = "Lương";
            table.Columns.Add(clm5);
            DataColumn clm6= new DataColumn();
            clm6.ColumnName = "Thưởng/Phạt";
            table.Columns.Add(clm6);
            DataColumn clm7 = new DataColumn();
            clm7.ColumnName = "Thực nhận";
            table.Columns.Add(clm7);
            System.Data.DataTable bangLuong = inOut.getWorkTimeTotal(ngayHientai);
            foreach (DataRow r in bangLuong.Rows)
            {
                DataRow row = table.NewRow();
                row[0] = r[0];
                row[1] = r[1];
                row[2] = r[2];
                row[3] = r[3];
                row[4] = r[4];
                if (account.defineRole(int.Parse(r[0].ToString())).Contains("TiepTan"))
                {
                    row[5] = int.Parse(r[4].ToString()) * 4 * 60;
                    row[6] = (int.Parse(r[3].ToString()) - (int.Parse(r[4].ToString()) * 4)) * 120;
                    row[7] = int.Parse(row[5].ToString()) + int.Parse(row[6].ToString());
                }
                else
                {
                    row[5] = int.Parse(r[4].ToString()) * 4 * 40;
                    row[6] = (int.Parse(r[3].ToString()) - (int.Parse(r[4].ToString()) * 4)) * 80;
                    row[7] = int.Parse(row[5].ToString()) + int.Parse(row[6].ToString());
                }    

                table.Rows.Add(row);
            }
            
            bangLuongDGV.DataSource = table;
        }

        private void xuatFileBt_Click(object sender, EventArgs e)
        {   
            //Lấy họ tên User
            System.Data.DataTable table = account.getEmployeeById(Globals.GlobalUserId);
            string name = table.Rows[0][4].ToString().Trim() + " " + table.Rows[0][5].ToString().Trim();
            try
            {
                _Application oWord = new Microsoft.Office.Interop.Word.Application();
                //Nếu tạo một Document
                _Document wordDoc = oWord.Documents.Add();
                object missing = System.Reflection.Missing.Value;
                Paragraph para = wordDoc.Content.Paragraphs.Add(ref missing);
                para.Range.Text = "Bảng Lương Ngày " + (ngayHientai + 1).ToString();
                para.CharacterUnitLeftIndent = 13;
                para.Range.Font.Size = 24;
                para.Range.Bold = 1;
                para.Range.Underline = 0;
                para.Range.InsertParagraphAfter();
                para.Range.Text = "Người tạo: " + name;
                para.Range.Font.Size = 12;
                para.Range.Bold = 0;
                para.Range.InsertParagraphAfter();
                Paragraph para1 = wordDoc.Content.Paragraphs.Add(ref missing);
                //Xuat tieu de cho cac cot
                para.Range.Font.Size = 11;
                para.Range.Bold = 0;
                Table firstTable = wordDoc.Tables.Add(para1.Range, bangLuongDGV.Rows.Count + 1, bangLuongDGV.Columns.Count, ref missing, ref missing);
                firstTable.Borders.Enable = 1;
                for (int c = 0; c <= bangLuongDGV.Columns.Count - 1; c++)
                {
                    firstTable.Rows[1].Cells[c + 1].Range.Text = bangLuongDGV.Columns[c].HeaderText;
                }
                firstTable.Columns[7].PreferredWidth = 75;
                //Xuat noi dung cac cot
                for (int i = 2; i < firstTable.Rows.Count; i++)
                {
                    wordDoc.Application.Visible = true;
                    Row row = firstTable.Rows[i];
                    foreach (Cell cell in row.Cells)
                    {
                        string str = bangLuongDGV.Rows[cell.RowIndex - 2].Cells[cell.ColumnIndex - 1].Value.ToString();
                        cell.Range.Text = str;
                    }
                }
                firstTable.Rows[bangLuongDGV.Rows.Count + 1].Cells[7].Range.Text = "Tổng:";
                int tongLuong = 0;
                for (int i = 0; i < bangLuongDGV.Rows.Count - 1; i++)
                {
                    tongLuong += int.Parse(bangLuongDGV.Rows[i].Cells[7].Value.ToString());
                }
                firstTable.Rows[bangLuongDGV.Rows.Count + 1].Cells[8].Range.Text = tongLuong.ToString();
                object filename = @"D:\BangLuong.docx";
                wordDoc.SaveAs2(ref filename);
                wordDoc.Close();
                oWord.Quit();
                MessageBox.Show("Data is Saved in D:\\", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
