using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
namespace NGANHANG
{
    public partial class Frpt_LietKeKhachHang : Form
    {
        public Frpt_LietKeKhachHang()
        {
            InitializeComponent();
            this.Load += new EventHandler(Frpt_LietKeKhachHangcs_Load);
        }

        private void Frpt_LietKeKhachHangcs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nGANHANGDataSet.ChiNhanh' table. You can move, or remove it, as needed.
            this.chiNhanhTableAdapter.Fill(this.nGANHANGDataSet.ChiNhanh);
            DataTable dtComboBox = new DataTable();
            dtComboBox = nGANHANGDataSet.Tables["ChiNhanh"].Clone();
            foreach (DataRow row in nGANHANGDataSet.Tables["ChiNhanh"].Rows)
            {
                dtComboBox.ImportRow(row);
            }

            // Gán DataTable mới làm nguồn dữ liệu cho ComboBox
            cmbChiNhanh.DataSource = dtComboBox;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "MACN";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;

            // Add event handler for ComboBox selection change
            cmbChiNhanh.SelectedIndexChanged += new EventHandler(cmbChiNhanh_SelectedIndexChanged);
        }
        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedItem != null)
            {
                string selectedMACN = cmbChiNhanh.SelectedValue.ToString();
            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            xrpt_LietKeKhachHang rpt = new xrpt_LietKeKhachHang(cmbLoai.Text.Substring(0, 1), cmbChiNhanh.SelectedValue.ToString());
            if (cmbLoai.Text == "Tất cả Chi Nhánh")
            {
                rpt.LabelChiNhanh.Text = "Tất cả Chi Nhánh";
            }
            else
            {
                if (cmbChiNhanh.SelectedValue.ToString().Trim().Equals("BENTHANH", StringComparison.OrdinalIgnoreCase))
                {
                    rpt.LabelChiNhanh.Text = "Chi Nhánh Bến Thành";
                }
                else
                {
                    rpt.LabelChiNhanh.Text = "Chi Nhánh Tân Định";
                }
            }
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
