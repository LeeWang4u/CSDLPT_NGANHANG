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
using System.Globalization;

namespace NGANHANG
{
    public partial class frmKH : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        string macn = "";   //Dùng cho btnThem.
        int check_Luu_HieuChinh = 0;    // Nếu chọn btnThem thì ta gán = 1, nếu btnHieuChinh thì ta gán = 2. Mục đích là để biết ta chọn btnThem hay không để chạy SP kiểm tra mã nv bị trùng.
        private SqlDataReader checkCMND;
        Stack undoList = new Stack();
        private bool kiemTraDuLieuDauVao()
        {
            /*kiem tra txtMANV*/
            /*kiem tra txtHO*/
            if (txtHo.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ và tên", "Thông báo", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            //"^[0-9A-Za-z ]+$"
            if (Regex.IsMatch(txtHo.Text, @"^[A-Za-z\u00C0-\u1EF9 ]+$") == false)
            {
                MessageBox.Show("Họ của người chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            if (txtHo.Text.Length > 40)
            {
                MessageBox.Show("Họ không thể lớn hơn 40 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            /*kiem tra txtTEN*/
            if (txtTen.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ và tên", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTen.Text, @"^[a-zA-Z\u00C0-\u1EF9 ]+$") == false)
            {
                MessageBox.Show("Tên người chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }

            if (txtTen.Text.Length > 40)
            {
                MessageBox.Show("Tên không thể lớn hơn 40 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            /*kiem tra txtDIACHI*/
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Không bỏ trống địa chỉ", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (Regex.IsMatch(txtDiaChi.Text, @"^[a-zA-Z0-9\u00C0-\u1EF9, ]+$") == false)
            {
                MessageBox.Show("Địa chỉ chỉ chấp nhận chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (txtDiaChi.Text.Length > 100)
            {
                MessageBox.Show("Không bỏ trống địa chỉ", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (Regex.IsMatch(txtCMND.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("CMND chỉ nhận số", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return false;
            }

            if (Regex.IsMatch(txtSdt.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("SDT chỉ nhận số", "Thông báo", MessageBoxButtons.OK);
                txtSdt.Focus();
                return false;
            }


            return true;
        }
        public frmKH()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            vitri = bdsKhachHang.Position;
            txtCMND.Enabled = false;    
            panelControl2.Enabled = true;
            // btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled =  btnThoat.Enabled = false;
            //btnLuu.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = true;
            //btnLuu.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled =  false;
            btnLuu.Enabled = btnTaiLai.Enabled = true;
            gcKhachHang.Enabled = false;
            check_Luu_HieuChinh = 2;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undoList.Count == 0)
            {
                MessageBox.Show("Không còn thao tác nào để khôi phục", "Thông báo", MessageBoxButtons.OK);
                btnPhucHoi.Enabled = false;
                return;
            }
            bdsKhachHang.CancelEdit();
            String cauTruyVanHoanTac = undoList.Pop().ToString();

            if (Program.KetNoi() == 0)
            {
                return;
            }
            System.Console.WriteLine(cauTruyVanHoanTac);

            int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);
            this.KhachHangTableAdapter.Fill(this.DS.KhachHang);
            string m = undoList.Pop().ToString();
            vitri = bdsKhachHang.Find("CMND", m);
            //bdsNhanVien.Position = vitri + 1; // đưa con trỏ nhảy đến vị trí manv đã xóa thất bại trước đó.
            bdsKhachHang.Position = bdsKhachHang.Find("CMND", m);
            // bdsNhanVien.Position = vitri;



            // this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
             
        }

        private void btnChuyenDoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void frmKH_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false; // bỏ kiểm tra khóa ngoại STK.
            
            this.KhachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.KhachHangTableAdapter.Fill(this.DS.KhachHang);
            macn = ((DataRowView)bdsKhachHang[0])["MACN"].ToString();
            panelControl2.Enabled = false;
            cmbChiNhanh.DataSource = Program.bds_dspm;  //sao chép dspm đã load ở form đăng nhập.
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "NGANHANG")
            {
                cmbChiNhanh.Enabled = true;
                 btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                // thay đổi chi nhánh để 
                cmbChiNhanh.Enabled = false;
                 //btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void cMNDLabel_Click(object sender, EventArgs e)
        {

        }

        private void khachHangGridControl_Click(object sender, EventArgs e)
        {

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
                this.KhachHangTableAdapter.Fill(this.DS.KhachHang);
                
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            vitri = bdsKhachHang.Position; 
            panelControl2.Enabled = true;
            bdsKhachHang.AddNew();
            txtChiNhanh.Text = macn;
            txtChiNhanh.Enabled = false;
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled= btnPhucHoi.Enabled  = btnThoat.Enabled = false;
            btnLuu.Enabled  = btnTaiLai.Enabled = true;
            gcKhachHang.Enabled = false;
            check_Luu_HieuChinh = 1;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false)
                return;
            txtHo.Text = CorrectString(txtHo.Text);
            txtTen.Text = CorrectString(txtTen.Text);
            String cauTruyVanHoanTac = "" +
                                "DELETE DBO.KHACHHANG " +
                                "WHERE CMND = " + txtCMND.Text.Trim();
            DataRowView drv = ((DataRowView)bdsKhachHang[bdsKhachHang.Position]);
            String ho = drv["HO"].ToString();
            String ten = drv["TEN"].ToString();
            String ngayCap = drv["NGAYCAP"].ToString();
            String diaChi = drv["DIACHI"].ToString();
            String phai = drv["PHAI"].ToString();
            String sdt = drv["SODT"].ToString();

            String cauTruyVanHoanTac2 = "UPDATE DBO.KhachHang " +
    "SET " +
    "[HO] = '" + ho + "', " +
    "[TEN] = '" + ten + "', " +
    "[DIACHI] = '" + diaChi + "', " +
    "[PHAI] = '" + phai + "', " +
    "[NGAYCAP} = '" + ngayCap+"',"+
    "[SODT] = '" + sdt + "', " +
    "[MACN] = '" + macn + "', " +
    "WHERE CMND = '" + txtCMND.Text.Trim() + "'";

            vitri = bdsKhachHang.Position;
            if (check_Luu_HieuChinh == 1)     
            {
                string strLenh = "EXEC [SP_KiemtraKH] '" + txtCMND.Text + "'";
                try
                {
                    checkCMND = Program.ExecSqlDataReader(strLenh);
                    checkCMND.Read();
                    System.Console.WriteLine(checkCMND.GetBoolean(0));
                    if (checkCMND.GetBoolean(0))   //đã tồn tại cmnd trùng.
                    {
                        bdsKhachHang.CancelEdit();
                        MessageBox.Show("CMDN Khách hàng đã tồn tại.", "", MessageBoxButtons.OK);
                        txtCMND.Focus();
                        checkCMND.Close();
                        return;
                    }
                    else
                    {
                        bdsKhachHang.EndEdit();    // kết thúc quá trình tạo. -> Ghi vào trong bds.
                        bdsKhachHang.ResetCurrentItem();   //Đưa những thông tin đó lên lưới.
                        this.KhachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.KhachHangTableAdapter.Update(this.DS.KhachHang); // Update trên adapter có 3 nghĩa: vừa là insert, update, delete. Nó tùy vào tình huống cụ thể để đưa lệnh tương ứng.
                        MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK);
                        checkCMND.Close();
                    }
                }
                catch (Exception ex)
                {
                    checkCMND.Close();
                    MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                try
                {
                    bdsKhachHang.EndEdit();    // kết thúc quá trình hiệu chỉnh. -> Ghi vào trong bds.
                    bdsKhachHang.ResetCurrentItem();   //Đưa những thông tin đó lên lưới.
                    this.KhachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.KhachHangTableAdapter.Update(this.DS.KhachHang); // Update trên adapter có 3 nghĩa: vừa là insert, update, delete. Nó tùy vào tình huống cụ thể để đưa lệnh tương ứng.
                    undoList.Push(txtCMND.Text.Trim());
                    undoList.Push(cauTruyVanHoanTac2);

                    btnPhucHoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Khách Hàng.\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }

            gcKhachHang.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;
            btnLuu.Enabled = btnPhucHoi.Enabled = false;

            panelControl2.Enabled = false;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnThoat.Enabled = true;
            btnLuu.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = true;
            // btnLuu.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = true;
            gcKhachHang.Enabled = true;
            try
            {
                this.KhachHangTableAdapter.Fill(this.DS.KhachHang);   // tải lại Nhân Viên.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Tải lại danh sách nhân viên: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        static string CorrectString(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string[] words = input.Split(' '); // Tách chuỗi thành các từ
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                // Sửa chữ cái đầu tiên của mỗi từ thành chữ hoa, và chữ cái còn lại thành chữ thường
                string correctedWord = textInfo.ToTitleCase(word.ToLower());
                result.Append(correctedWord).Append(" ");
            }

            // Loại bỏ khoảng trắng ở cuối chuỗi
            return result.ToString().TrimEnd();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           

            string cmdText = "SP_Check_CMND_MoTK";
            SqlParameter parameterCMND = new SqlParameter("@cmnd", txtCMND.Text.Trim());
            SqlParameter parameterMaCN = new SqlParameter("@maChiNhanh", macn.Trim());
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connstr))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(parameterCMND);
                        cmd.Parameters.Add(parameterMaCN);
                        SqlParameter parameterExists = new SqlParameter("@exists", SqlDbType.Bit);
                        parameterExists.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(parameterExists);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        bool result = (bool)parameterExists.Value;
                        if (result)
                        {
                            bdsKhachHang.CancelEdit();
                            MessageBox.Show("Khách hàng đã mở tài khoản không thể xóa.", "", MessageBoxButtons.OK);
                            txtCMND.Focus();
                            return;
                        }
                        else
                        {
                            String cmnd = ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["CMND"].ToString();
                            string cauTruyVanHoanTac =
                                           string.Format("INSERT INTO DBO.KHACHHANG( [CMND],[HO],[TEN],[DIACHI],[PHAI],[NGAYCAP],[SODT],[MACN])" +
                                       "VALUES('{0}','{1}','{2}','{3}','{4}', '{5}','{6}', '{7}')", txtCMND.Text, txtHo.Text, txtTen.Text, txtDiaChi.Text, cmbGioiTinh.Text, txtNgayCap.Text, txtSdt.Text, macn, "0");

                            Console.WriteLine(cauTruyVanHoanTac);
                            undoList.Push(cmnd);
                            undoList.Push(cauTruyVanHoanTac);
                            btnPhucHoi.Enabled = true;

                            if (MessageBox.Show("Bạn có thật sự muốn xóa khách hàng này ??", "Xác nhận",
                                MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                try
                                {
                                    vitri = bdsKhachHang.Position;
                                    // manv = int.Parse(((DataRowView)bdsNhanVien[bdsNhanVien.Position])["MANV"].ToString());  // Giữ lại mã nhân viên hiện tại đang đứng để nếu xóa ở máy hiện tại thành công mà xóa ở CSDL thất bại thì ta sẽ fill data về lại máy và nhờ manv đó thì con trỏ nó sẽ nhảy đến manv vừa xóa.
                                    bdsKhachHang.RemoveCurrent();  // Xóa trên máy hiện tại trước, sau đó mới xóa trên CSDL sau.
                                    this.KhachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                                    this.KhachHangTableAdapter.Update(this.DS.KhachHang); // xóa dữ liệu đó ở CSDL.

                                    /*   try
                                       {   
                                           Program.ExecSqlNonQuery($"EXEC sp_xoa_tai_khoan_nhan_vien '{manv}'");
                                       }
                                       catch {
                                           Console.WriteLine(manv);
                                       }
                                    */
                                    // Gọi sp xóa tài khoản login nếu có
                                }
                                catch (Exception ex)    // Trong thực tế sẽ có lỗi phát sinh mà thầy Thư cũng không biết.
                                {
                                    MessageBox.Show("Lỗi xóa khách hàng. Bạn hãy xóa lại\n" + ex.Message, "",
                                        MessageBoxButtons.OK);
                                    this.KhachHangTableAdapter.Fill(this.DS.KhachHang);   // Trường hợp xóa ở máy hiện tạo thành công nhưng xóa trên CSDL bị lỗi thì ta phải tải về lại máy hiện tại.
                                                                                              // bdsNhanVien.Position = bdsNhanVien.Find("MANV", manv); // đưa con trỏ nhảy đến vị trí manv đã xóa thất bại trước đó.
                                    bdsKhachHang.Position = vitri;
                                    return;
                                }
                            }
                            else
                            {
                                undoList.Pop();
                                undoList.Pop();
                            }
                            if (bdsKhachHang.Count == 0) btnXoa.Enabled = false;   // trường hợp ta xóa hết nhân viên hoặc trong Grid không có ai thì ta làm mờ nút xóa đi. Nếu không nó sẽ báo lỗi ở dòng code 102 là khi ta lấy manv trước khi xóa ra thì bdsNV.Position không tìm thấy vị trí nào thì nó báo lỗi.

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

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && txtCMND.Text.Length < 10)
            {
                e.Handled = true;
            }
            if (txtCMND.Text.Trim().Length > 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
        }

        private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtTen.Text.Trim().Length > 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtSdt.Text.Trim().Length > 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
        }
    }
}