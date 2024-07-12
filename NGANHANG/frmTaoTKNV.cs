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
using System.Text.RegularExpressions;
using System.Collections;



namespace NGANHANG
{
    public partial class frmTaoTKNV : DevExpress.XtraEditors.XtraForm
    {
        public frmTaoTKNV()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nhanVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmTaoTKNV_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false; // bỏ kiểm tra khóa ngoại STK.
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;    // gán thông tin đăng nhập vào các Adapter tương ứng để fill lấy thông tin đúng với thông tin đăng nhập.

            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

            txtMaNV.Enabled = false;

            gridView1.OptionsBehavior.Editable = false;

        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể trống");
                txtMatKhau.Focus();
                return;
            }
            //  /*
            //string cmdText = "sp_tao_tai_khoan_nhan_vien";
            string cmdText = "sp_create_account";
            SqlParameter parameterUsername = new SqlParameter("@USERNAME", txtMaNV.Text.Trim());
            SqlParameter parameterLoginname = new SqlParameter("@LGNAME", txtMaNV.Text.Trim());
            SqlParameter parameterPassword = new SqlParameter("@PASS", txtMatKhau.Text);
            SqlParameter parameterRole = new SqlParameter("@ROLE", Program.mGroup);
            try
            {
                 Lib.DbConnection.ExecuteNonQuery(cmdText, CommandType.StoredProcedure,
                   parameterUsername, parameterLoginname, parameterPassword, parameterRole);
                //Lib.DbConnection.ExecuteNonQuery(cmdText, CommandType.StoredProcedure,
               //    parameterUsername, parameterLoginname, parameterPassword);
                MessageBox.Show("Tạo tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tên đăng nhập đã có hoặc nhân viên đã có tài khoản\nChi tiết: {ex.Message}");
            }
            //*/
            /*
            string connectionString = Program.connstr; // Đảm bảo rằng bạn đã định nghĩa Program.connstr
            string cmdText = "sp_tao_tai_khoan_nhan_vien";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = txtMaNV.Text.Trim();
                    command.Parameters.Add("@loginname", SqlDbType.NVarChar).Value = txtMaNV.Text.Trim();
                    command.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtMatKhau.Text;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tạo tài khoản thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Tên đăng nhập đã có hoặc nhân viên đã có tài khoản\nChi tiết: {ex.Message}");
                    }
                }
            }
            */

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMaNV_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}