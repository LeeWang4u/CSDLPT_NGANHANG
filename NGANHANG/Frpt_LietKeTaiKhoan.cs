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
    public partial class Frpt_LietKeTaiKhoan : Form
    {
        public Frpt_LietKeTaiKhoan()
        {
            InitializeComponent();
        }

        private void Frpt_LietKeTaiKhoan_Load(object sender, EventArgs e)
        {
            //  cmbChiNhanh.DataSource = Program.bds_dspm;
            //   cmbChiNhanh.DisplayMember = "TENCN";
            //  cmbChiNhanh.ValueMember = "TENSERVER";
            //  cmbChiNhanh.SelectedIndex = Program.mChinhanh;
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
            if (Program.mGroup == "NGANHANG")
              cmbChiNhanh.Enabled = true;
              else cmbChiNhanh.Enabled = false;
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

    private void button1_Click_1(object sender, EventArgs e)
        {
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
            xrpt_LietKeTaiKhoan rpt = new xrpt_LietKeTaiKhoan(batdau.DateTime, ketthuc.DateTime, cmbLoai.Text.Substring(0, 1), cmbChiNhanh.SelectedValue.ToString());
            rpt.labelTieuDe.Text = "SỐ TÀI KHOẢN ĐƯỢC TAO TỪ NGÀY " + batdau.Text.ToUpper() + " ĐẾN NGÀY " + ketthuc.Text.ToUpper();
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