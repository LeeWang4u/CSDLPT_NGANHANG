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
using DevExpress.XtraReports.UI; 

namespace NGANHANG
{
    public partial class Frpt_SaoKeTaiKhoanNganHang : Form
    {
        private string connectionString = Program.connstr;
        private DataTable taiKhoanTable;
        public Frpt_SaoKeTaiKhoanNganHang()
        {
            InitializeComponent();
            LoadTaiKhoanData();
        }
        private void LoadTaiKhoanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT CMND, SOTK FROM TaiKhoan", conn);
                    taiKhoanTable = new DataTable();
                    adapter.Fill(taiKhoanTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (SoTK.Text.Trim() == "")
            {
                MessageBox.Show("Số tài khoản không được trống", "", MessageBoxButtons.OK);
                SoTK.Focus();
                return;
            }
            if (batdau.DateTime > DateTime.Now || batdau.Text.Trim() == "")
            {
                MessageBox.Show("Ngày bắt đầu trống hoặc mốc thời gian là trước hiện tại", "", MessageBoxButtons.OK);
                batdau.Focus();
                return;
            }
            if (ketthuc.DateTime > DateTime.Now || ketthuc.Text.Trim() == "")
            {
                MessageBox.Show("Ngày kết thúc trống hoặc mốc thời gian là trước hiện tại", "", MessageBoxButtons.OK);
                ketthuc.Focus();
                return;
            }
            if (Program.KetNoi() == 0) return;
            string strlenh = "EXEC SP_Thong_Tin_KH'" + SoTK.Text + "'";
            Program.myReader = Program.ExecSqlDataReader(strlenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            if (!Program.myReader.HasRows)
            {
                MessageBox.Show("Số tài khoản không tồn tại \nVui lòng nhập lại", "", MessageBoxButtons.OK);
                return;
            }
            DateTime adjustedKetthuc = ketthuc.DateTime.AddDays(1);
            xrpt_SaoKeTaiKhoanNganHang rpt = new xrpt_SaoKeTaiKhoanNganHang(SoTK.Text, batdau.DateTime, adjustedKetthuc);
            rpt.labelTieuDe.Text = "SAO KÊ TÀI KHOẢN " + SoTK.Text.ToUpper() + " TỪ NGÀY " + batdau.Text.ToUpper() + " ĐẾN NGÀY " + ketthuc.Text.ToUpper();
            rpt.labelHoTen.Text = Program.myReader.GetString(0);
            Program.myReader.Close();
            Program.conn.Close();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void Frpt_SaoKeTaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "KHACHHANG")
            {
                SoTK.Enabled = false;
                SoTK.Text = GetSOTKFromCMND(Program.username);
            }

        }

        private string GetSOTKFromCMND(string cmnd)
        {
            DataRow[] rows = taiKhoanTable.Select($"CMND = '{cmnd}'");

            if (rows.Length > 0)
            {
                return rows[0]["SOTK"].ToString();
            }

            return null;
        }

    }
}
