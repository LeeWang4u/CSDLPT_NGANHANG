using DevExpress.XtraEditors;
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

namespace NGANHANG
{
    public partial class frmTaoLoginKH : DevExpress.XtraEditors.XtraForm
    {
        String macn = "";
        public frmTaoLoginKH()
        {
            InitializeComponent();
        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.TaiKhoanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.NH);

        }

        private void frmTaoLoginKH_Load(object sender, EventArgs e)
        {
            NH.EnforceConstraints = false; // bỏ kiểm tra khóa ngoại STK.
            txtCMND.Enabled = false;
            this.TaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.TaiKhoanTableAdapter.Fill(this.NH.TaiKhoan);
            if (Program.mChinhanh == 1)
            {
                macn = "TANDINH";
            }
            else
            {
                macn = "BENTHANH";
            }

        }

        private void cMNDTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {

            if (txtMK.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể trống");
                txtMK.Focus();
                return;
            }
            if (macn != txtMaCN.Text.Trim())
            {
                MessageBox.Show("Không thể tạo tài khoản login cho chi nhánh khác!");
            }
            else
            {
                string cmdText = "sp_tao_login_khach_hang";
                SqlParameter parameterCMND = new SqlParameter("@cmnd", txtCMND.Text.Trim());
                SqlParameter parameterPassword = new SqlParameter("@pass", txtMK.Text);
                try
                {
                    Lib.DbConnection.ExecuteNonQuery(cmdText, CommandType.StoredProcedure,
                      parameterCMND, parameterPassword);
                    //Lib.DbConnection.ExecuteNonQuery(cmdText, CommandType.StoredProcedure,
                    //    parameterUsername, parameterLoginname, parameterPassword);
                    MessageBox.Show("Tạo login thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chi nhánh này khách hàng đã có tài khoản login\nChi tiết: {ex.Message}");
                }
            }
        }
    }
}