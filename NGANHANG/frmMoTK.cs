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
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace NGANHANG
{
    public partial class frmMoTK : DevExpress.XtraEditors.XtraForm
    {
        String trong = "";
        decimal khong = 0;
        String macn = "";
        int tmp = 1;
        public frmMoTK()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmMoTK_Load);
        }
        private bool kiemTraDuLieuDauVao()
        {
            
            
            
            /*kiem tra txtTEN*/
            if (txtSoTK.Text == "")
            {
                MessageBox.Show("Không bỏ trống số tài khoản ", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return false;
            }
            if (Regex.IsMatch(txtSoTK.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số", "Thông báo", MessageBoxButtons.OK);
                txtSoTK.Focus();
                return false;
            }
            if (txtSoTK.Text.Trim().Length != 9)
            {
                MessageBox.Show("Số tài khoản phải có đúng 9 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtSoTK.Focus();
                return false;
            }



            return true;
        }

        private void frmMoTK_Load(object sender, EventArgs e)
        {

            txtNgayCap.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
            txtNgayCap.Enabled = false;
            txtCMND.Enabled = false;
            txtMaChiNhanh.Enabled = false;
            NH.EnforceConstraints = false; // bỏ kiểm tra khóa ngoại STK.

            this.KhachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.KhachHangTableAdapter.Fill(this.NH.KhachHang);
           
          if(Program.mChinhanh==1)
            {
                macn = "TANDINH";
            }
            else
            {
                macn = "BENTHANH";
            }
            txtMaChiNhanh.Text = macn;
            cmbChiNhanh.DataSource = Program.bds_dspm;  //sao chép dspm đã load ở form đăng nhập.
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;

            gridView1.OptionsBehavior.Editable = false;
            /*if (Program.mGroup == "NGANHANG")
            {
                cmbChiNhanh.Enabled = true;
                //btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                // thay đổi chi nhánh để 
                cmbChiNhanh.Enabled = false;
                //btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = true;
            }*/

        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;  //Kiểm tra cmb này đã có số liệu hay chưa.Trong thực tế có trường hợp mới mở form lên thì nó tự chạy rồi.Nhưng khi nó chạy mã mình vẫn chưa chọn gì thì sẽ báo lỗi.
            Program.servername = cmbChiNhanh.SelectedValue.ToString();

            if (cmbChiNhanh.SelectedIndex != Program.mChinhanh)  //nếu ta chọn chi nhánh khác với chi nhánh ở thời điểm đăng nhập thì ta sẽ dùng tk HTKN;
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới!", "", MessageBoxButtons.OK);
            else
            {
                this.KhachHangTableAdapter.Connection.ConnectionString = Program.connstr;    // gán thông tin đăng nhập vào các Adapter tương ứng để fill lấy thông tin đúng với thông tin đăng nhập.
                this.KhachHangTableAdapter.Fill(this.NH.KhachHang);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnMo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnMoTK_Click(object sender, EventArgs e)
        {

            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false)
                return;
           // Console.WriteLine("truoc sp ");
            string cmdText = "sp_tao_tai_khoan_khach_hang";
           // Console.WriteLine(" sp");
            SqlParameter parameterSTK = new SqlParameter("@stk", txtSoTK.Text.Trim());
            SqlParameter parameterCMND = new SqlParameter("@cmnd", txtCMND.Text.Trim());
            SqlParameter parameterMaCN = new SqlParameter("@maChiNhanh", txtMaChiNhanh.Text.Trim());
            SqlParameter parameterSoDu = new SqlParameter("@sodu", txtSoDu.Text.Trim());
            SqlParameter parameterNgayCap = new SqlParameter("@ngaycap", txtNgayCap.Text.Trim());
            SqlParameter parameterExists = new SqlParameter("@exists", SqlDbType.Int);
            parameterExists.Direction = ParameterDirection.Output;
           // Console.WriteLine("KT sp");
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connstr))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                       // Console.WriteLine("Out");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(parameterSTK);
                        cmd.Parameters.Add(parameterCMND);
                        cmd.Parameters.Add(parameterMaCN);
                        cmd.Parameters.Add(parameterSoDu);
                        cmd.Parameters.Add(parameterNgayCap);

                        cmd.Parameters.Add(parameterExists);

                        connection.Open();
                        cmd.ExecuteNonQuery();

                        int result = (int)parameterExists.Value;
                        if (result == 1)
                        {
                            Console.WriteLine(1);
                            bdsKhachHang.CancelEdit();
                            MessageBox.Show("Số tài khoản đã tồn tại.", "", MessageBoxButtons.OK);
                            txtSoTK.Focus();
                            return;
                        }
                        else if (result == 2)
                        {
                            bdsKhachHang.CancelEdit();
                            MessageBox.Show("CMND Khách hàng không tồn tại", "", MessageBoxButtons.OK);
                            txtCMND.Focus();
                            return;
                        }
                        else if (result == 3)
                        {
                            bdsKhachHang.CancelEdit();
                            MessageBox.Show("Khách hàng đã mở tài khoản ở trong chi nhánh này rồi", "", MessageBoxButtons.OK);
                            txtCMND.Focus();
                            return;
                        }
                        else
                        {
                          //  Console.WriteLine(0);
                            /*string cmnd = txtCMND.Text.Trim();
                            string maChiNhanh = txtMaChiNhanh.Text.Trim();
                            string soTK = txtSoTK.Text.Trim();
                            decimal soDu;*/


                            /*if (!decimal.TryParse(txtSoDu.Text.Trim(), out soDu))
                            {
                                MessageBox.Show("Số dư không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }*/
                            //Console.WriteLine(10);
                            // Thêm dữ liệu vào bdsTaiKhoan
                            /*DataRowView drvTaiKhoan = (DataRowView)bdsTaiKhoan.AddNew();
                            drvTaiKhoan["CMND"] = cmnd;
                            drvTaiKhoan["MaCN"] = maChiNhanh;
                            drvTaiKhoan["SoTK"] = soTK;
                            drvTaiKhoan["SoDu"] = soDu;
                            drvTaiKhoan["NgayCap"] = DateTime.Now;  // Ngày cấp là ngày hiện tại
                            Console.WriteLine(soTK);
                            Console.WriteLine(soDu);
                            // Kết thúc quá trình chỉnh sửa
                            bdsTaiKhoan.EndEdit();
                            bdsTaiKhoan.ResetCurrentItem();   // Đưa những thông tin đó lên lưới
                          //  Console.WriteLine(1000);
                            // Lưu dữ liệu từ bdsTaiKhoan vào cơ sở dữ liệu*/
                            this.TaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.TaiKhoanTableAdapter.Update(this.NH.TaiKhoan);
                          //  Console.WriteLine(1000);
                            MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Console.WriteLine(10000);
                            txtSoTK.Text = trong;
                            txtSoDu.Text = trong;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: CMND " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

        }

        private void txtSoTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && txtSoTK.Text.Length < 9)
            {
                e.Handled = true;
            }
            if (txtSoTK.Text.Trim().Length > 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
        }
    }
}