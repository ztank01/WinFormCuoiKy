using Microsoft.Office.Interop.Word;
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
    public partial class KhoanThuForm : Form
    {
        public KhoanThuForm()
        {
            InitializeComponent();
        }
        Khach khach = new Khach();
        Phong phong = new Phong();
        LichLamViec lichlv = new LichLamViec();
        Account account = new Account();
        private void KhoanThuForm_Load(object sender, EventArgs e)
        {
            System.Data.DataTable table = khach.getKhachinDay(DateTime.Now);
            DataColumn clm10 = new DataColumn();
            clm10.ColumnName = "Số ngày ở";
            table.Columns.Add(clm10);
            DataColumn clm11 = new DataColumn();
            clm11.ColumnName = "Khách còn phải thanh toán";
            table.Columns.Add(clm11);
            foreach (DataRow r in table.Rows)
            {
                //Lấy chi phí của khách
                DateTime thoigiandi = (DateTime)r[7];
                DateTime thoigianden = (DateTime)r[6];
                TimeSpan tmp = thoigiandi - thoigianden;
                double songayo = tmp.TotalDays;
                int ngayo = 1 + int.Parse(string.Format("{0:0.000}", songayo)[0].ToString());
                r[10] = ngayo.ToString();
                System.Data.DataTable thongtinPhong = phong.getById(int.Parse(r[8].ToString()));
                int datra = int.Parse(r[9].ToString());
                int giaPhong = int.Parse(thongtinPhong.Rows[0][2].ToString());
                r[11] = (giaPhong * ngayo) - datra;
            }
            //Định dạng DGV
            
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

        private void xuatFileBt_Click(object sender, EventArgs e)
        {
            //Xác định ngày hiện tại
            System.Data.DataTable caLam = lichlv.getLichLamViecById(Globals.GlobalUserId);
            DateTime ngayBd = (DateTime)caLam.Rows[0][3];
            TimeSpan tmp = DateTime.Now - ngayBd;
            double songay = tmp.TotalDays;
            int ngayHientai = int.Parse(string.Format("{0:0.000}", songay)[0].ToString());
            if (DateTime.Now.Hour < 7)
            {
                ngayHientai -= 1;
            }
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
                para.Range.Text = "Các Khoản Thu Ngày " + (ngayHientai + 1).ToString();
                para.CharacterUnitLeftIndent = 24;
                para.Range.Font.Size = 24;
                para.Range.Bold = 1;
                para.Range.Underline = 0;
                para.Range.InsertParagraphAfter();
                para.Range.Text = "     Người tạo: " + name;
                para.Range.Font.Size = 12;
                para.Range.Bold = 0;
                para.Range.InsertParagraphAfter();
                Paragraph para1 = wordDoc.Content.Paragraphs.Add(ref missing);
                //Xuat tieu de cho cac cot
                para.Range.Font.Size = 11;
                para.Range.Bold = 0;
                Table firstTable = wordDoc.Tables.Add(para1.Range, customerListDGV.Rows.Count + 2, customerListDGV.Columns.Count, ref missing, ref missing);
                firstTable.Borders.Enable = 1;
                for (int c = 0; c <= customerListDGV.Columns.Count - 1; c++)
                {
                    firstTable.Rows[1].Cells[c + 1].Range.Text = customerListDGV.Columns[c].HeaderText;
                }
                firstTable.Columns[1].PreferredWidth = 75;
                firstTable.Columns[2].PreferredWidth = 70;
                firstTable.Columns[3].PreferredWidth = 80;
                firstTable.Columns[4].PreferredWidth = 50;
                firstTable.Columns[5].PreferredWidth = 80;
                firstTable.Columns[6].PreferredWidth = 50;
                firstTable.Columns[7].PreferredWidth = 70;
                firstTable.Columns[8].PreferredWidth = 70;
                firstTable.Columns[9].PreferredWidth = 40;
                firstTable.Columns[10].PreferredWidth = 55;
                firstTable.Columns[11].PreferredWidth = 40;
                firstTable.Columns[12].PreferredWidth = 80;
                //Xuat noi dung cac cot
                for (int i = 2; i < firstTable.Rows.Count; i++)
                {
                    wordDoc.Application.Visible = true;
                    Row row = firstTable.Rows[i];
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.ColumnIndex == 6)
                        {
                            // https://stackoverflow.com/questions/37385875/how-to-convert-system-byte-into-an-image-to-be-displayed-into-word-c-sharp 
                            Object oMissing = wordDoc.Tables[1].Cell(cell.RowIndex, 6).Range;

                            byte[] pic = (byte[])customerListDGV.Rows[cell.RowIndex - 2].Cells[5].Value;
                            Image sparePicture = ByteArrayToImage(pic);
                            Clipboard.SetDataObject(sparePicture);
                            var oPara2 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                            oPara2.Range.Paste();
                            oPara2.Range.InsertParagraphAfter();
                        }
                        else
                        {
                            string str = customerListDGV.Rows[cell.RowIndex - 2].Cells[cell.ColumnIndex - 1].Value.ToString();
                            cell.Range.Text = str;
                        }
                    }
                }
                firstTable.Rows[customerListDGV.Rows.Count + 2].Cells[9].Range.Text = "Tổng:";
                int tongLuong = 0;
                for (int i = 0; i < customerListDGV.Rows.Count ; i++)
                {
                    tongLuong += int.Parse(customerListDGV.Rows[i].Cells[9].Value.ToString());
                }
                firstTable.Rows[customerListDGV.Rows.Count + 2].Cells[10].Range.Text = tongLuong.ToString();
                object filename = @"D:\KhoanThu.docx";
                wordDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
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
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
    }
}
