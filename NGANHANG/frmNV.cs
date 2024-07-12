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
    public partial class frmNV : DevExpress.XtraEditors.XtraForm
    {

        int vitri = 0;
        string macn = "";   //Dùng cho btnThem.
        int check_Luu_HieuChinh = 0;    // Nếu chọn btnThem thì ta gán = 1, nếu btnHieuChinh thì ta gán = 2. Mục đích là để biết ta chọn btnThem hay không để chạy SP kiểm tra mã nv bị trùng.
        private SqlDataReader checkMaNV;
        string maxMaNV = "";

        Stack undoList = new Stack();



        public frmNV()
        {
            InitializeComponent();
        }
    

        // btnxoa
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Console.WriteLine(txtDiaChi.Text);
            String tenNV = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])["MANV"].ToString();
            if (tenNV == Program.username)
            {
                MessageBox.Show("Không thể xóa chính tài khoản đang đăng nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            Int32 manv = 0;
            if (bdsGD_CHUYENTIEN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập GIAO DỊCH CHUYỂN TIỀN", "",
                    MessageBoxButtons.OK);
                return;
            }
            if (bdsGD_GUIRUT.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập GIAO DỊCH GỬI RÚT", "",
                    MessageBoxButtons.OK);
                return;
            }

            string cauTruyVanHoanTac =
                string.Format("INSERT INTO DBO.NHANVIEN( [MANV],[HO],[TEN],[CMND],[DIACHI],[PHAI],[SODT],[MACN],[TrangThaiXoa])" +
            "VALUES('{0}','{1}','{2}','{3}','{4}', '{5}','{6}', '{7}',{8})", txtMaNV.Text, txtHo.Text, txtTen.Text,txtCMND.Text, txtDiaChi.Text, cmbGioiTinh.Text, txtSDT.Text, macn, "0");

           // Console.WriteLine(cauTruyVanHoanTac);

            
            undoList.Push(tenNV);
            undoList.Push(cauTruyVanHoanTac);
            btnPhucHoi.Enabled = true;

            if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này ??", "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    vitri = bdsNhanVien.Position;
                   // manv = int.Parse(((DataRowView)bdsNhanVien[bdsNhanVien.Position])["MANV"].ToString());  // Giữ lại mã nhân viên hiện tại đang đứng để nếu xóa ở máy hiện tại thành công mà xóa ở CSDL thất bại thì ta sẽ fill data về lại máy và nhờ manv đó thì con trỏ nó sẽ nhảy đến manv vừa xóa.
                    bdsNhanVien.RemoveCurrent();  // Xóa trên máy hiện tại trước, sau đó mới xóa trên CSDL sau.
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien); // xóa dữ liệu đó ở CSDL.
                    
                    try
                    {   
                        Program.ExecSqlNonQuery($"EXEC SP_XoaLogin '{tenNV}', '{tenNV}'");
                    }
                    catch {
                        Console.WriteLine(tenNV);
                    }
                 
                   
                }
                catch (Exception ex)    // Trong thực tế sẽ có lỗi phát sinh mà thầy Thư cũng không biết.
                {
                    Console.WriteLine(manv);
                    Console.WriteLine(vitri);
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.FillByCmnd(this.DS.NhanVien);   // Trường hợp xóa ở máy hiện tạo thành công nhưng xóa trên CSDL bị lỗi thì ta phải tải về lại máy hiện tại.
                                                                        // bdsNhanVien.Position = bdsNhanVien.Find("MANV", manv); // đưa con trỏ nhảy đến vị trí manv đã xóa thất bại trước đó.
                    bdsNhanVien.Position = vitri;
                    return;
                }
            }
            else
            {
                undoList.Pop();
                undoList.Pop();
            }
            if (bdsNhanVien.Count == 0) btnXoa.Enabled = false;   // trường hợp ta xóa hết nhân viên hoặc trong Grid không có ai thì ta làm mờ nút xóa đi. Nếu không nó sẽ báo lỗi ở dòng code 102 là khi ta lấy manv trước khi xóa ra thì bdsNV.Position không tìm thấy vị trí nào thì nó báo lỗi.



        }

       
       

        private void frmNV_Load(object sender, EventArgs e)
        {
            
            DS.EnforceConstraints = false; // bỏ kiểm tra khóa ngoại STK.
            // TODO: This line of code loads data into the 'DS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            // TODO: This line of code loads data into the 'DS.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
            
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;    // gán thông tin đăng nhập vào các Adapter tương ứng để fill lấy thông tin đúng với thông tin đăng nhập.
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.FillByCmnd(this.DS.NhanVien);

            macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;  //sao chép dspm đã load ở form đăng nhập.
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "NGANHANG")
            {
                cmbChiNhanh.Enabled = true;
                btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled  = btnChuyenChiNhanh.Enabled = false;
                btnLuu.Enabled = btnTaiLai.Enabled = false;
                // btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
              //  btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = true;
            }
            panelControl3.Enabled = false;
            // string strLenh = "EXEC [SP_MaxMANV] '" + "0" + "'";


            // checkMaNV = Program.ExecSqlDataReader(strLenh);
            //   checkMaNV.Read();
            //  System.Console.WriteLine(checkMaNV.GetString(0));

            gridView1.OptionsBehavior.Editable = false;


        }

       
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaNV.Enabled = true; // Vì khi ta hiệu chỉnh thì không cho phép sửa mã -> nên ta khóa bên Hiệu Chỉnh -> Qua Thêm thì ta phải mở ra lại.
            vitri = bdsNhanVien.Position; //Giữ lại vị trí nhân viên mà chúng ta đang đứng -> dùng trong phục hồi và thêm.
            panelControl3.Enabled = true;
            bdsNhanVien.AddNew();
            txtChiNhanh.Text = macn;
            txtChiNhanh.Enabled= txbTrangThaiXoa.Enabled = txtMaNV.Enabled = false;
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.Text = "Nam";
            txbTrangThaiXoa.Text = "0";
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled= btnChuyenChiNhanh.Enabled = false;
            btnLuu.Enabled = btnTaiLai.Enabled = true;
            gcNhanVien.Enabled = false;
            check_Luu_HieuChinh = 1;

            string strLenh = "EXEC [SP_MaxMANV] '" + "0" + "'";


            checkMaNV = Program.ExecSqlDataReader(strLenh);
            checkMaNV.Read();
            System.Console.WriteLine(checkMaNV.GetString(0));

            maxMaNV = getMaxMaNV(checkMaNV.GetString(0));
            txtMaNV.Text = maxMaNV;
            checkMaNV.Close();
            
            System.Console.WriteLine(FindPosition("NV05")); 

            System.Console.WriteLine(bdsNhanVien.Find("MANV", "NV05"));

            txtCMND.Enabled = true;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Console.WriteLine(txtDiaChi.Text);
            txtHo.Text = CorrectString(txtHo.Text);
            txtTen.Text = CorrectString(txtTen.Text);

            bool ketQua = kiemTraDuLieuDauVao();
            String cauTruyVanHoanTac = "" +
                                "DELETE DBO.NHANVIEN " +
                                "WHERE MANV = '" + txtMaNV.Text.Trim() + "'";
            DataRowView drv = ((DataRowView)bdsNhanVien[bdsNhanVien.Position]);
            String ho = drv["HO"].ToString();
            String ten = drv["TEN"].ToString();
            String cmnd = drv["CMND"].ToString();
            String diaChi = drv["DIACHI"].ToString();
            String phai = drv["PHAI"].ToString();
            String sdt = drv["SODT"].ToString();

            String cauTruyVanHoanTac2 = "UPDATE DBO.NhanVien " +
    "SET " +
    "[HO] = '" + ho + "', " +
    "[TEN] = '" + ten + "', " +
    "[CMND] = '" + cmnd + "', " +
    "[DIACHI] = '" + diaChi + "', " +
    "[PHAI] = '" + phai + "', " +
    "[SODT] = '" + sdt + "', " +
    "[MACN] = '" + macn + "', " +
    "[TrangThaiXoa] = '0' " +
    "WHERE MANV = '" + txtMaNV.Text.Trim() + "'";

            vitri = bdsNhanVien.Position;
            if (ketQua == false)
                return;


            if (check_Luu_HieuChinh == 1)    // Nếu chọn btn thêm thì ta chạy SP kiểm tra có trùng mã nv hay không.
            {
                string strLenh = "EXEC [SP_KiemTraCMNDNhanVien] '" + txtCMND.Text + "'";
                // string strLenh = "EXEC [SP_kiemtraNV] '" + txtMaNV.Text + "'";
                //     string strLenh = "DECLARE	@return_value int" +
                //                   "EXEC @return_value = [dbo].[sp_TimNV]" +
                //                        "  @X ='" + txtMaNV.Text + "'"+
                //               "SELECT  'Return Value' = @return_value";
                try
                {
                    checkMaNV = Program.ExecSqlDataReader(strLenh);
                    checkMaNV.Read();
                    System.Console.WriteLine(checkMaNV.GetBoolean(0));
                    if (checkMaNV.GetBoolean(0))   //đã tồn tại cmnd trùng.
                    {
                       // bdsNhanVien.CancelEdit();
                        MessageBox.Show("Không được trùng CMND.", "", MessageBoxButtons.OK);
                        txtMaNV.Focus();
                        checkMaNV.Close();
                        return;
                    }
                    else
                    {
                     /*   cauTruyVanHoanTac = "" +
                                "DELETE DBO.NHANVIEN " +
                                "WHERE MANV = " + txtMaNV.Text.Trim();  */
                        bdsNhanVien.EndEdit();    // kết thúc quá trình tạo. -> Ghi vào trong bds.
                        bdsNhanVien.ResetCurrentItem();   //Đưa những thông tin đó lên lưới.
                        this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.nhanVienTableAdapter.Update(this.DS.NhanVien); // Update trên adapter có 3 nghĩa: vừa là insert, update, delete. Nó tùy vào tình huống cụ thể để đưa lệnh tương ứng.
                        MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK);
                        checkMaNV.Close();

                        undoList.Push(txtMaNV.Text.Trim());
                        undoList.Push(cauTruyVanHoanTac);
                        // btnPhucHoi.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    checkMaNV.Close();
                    MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                try
                {
                    /*  cauTruyVanHoanTac =
                      "UPDATE DBO.NhanVien " +
                              "SET " +
                              "[HO] = '" + txtHo.Text + "'" +
                              ",[TEN] = '" + txtTen.Text + "'" +
                              ",[CMND] = '" + txtCMND.Text + "'" +
                              ",[DIACHI = '" + txtDiaChi.Text + "'" +
                              ",[PHAI] = '" + cmbGioiTinh.Text + "'" +
                              ",[SODT] = '" + txtSDT.Text + "'" +
                              ",[MACN] = '" + macn + "'" +
                              ",[TrangThaiXoa] = '0'" +
                              "WHERE MANV = '" + txtMaNV.Text.Trim() + "'";  */

             /*       cauTruyVanHoanTac =
    "UPDATE DBO.NhanVien " +
    "SET " +
    "[HO] = '" + txtHo.Text + "', " +
    "[TEN] = '" + txtTen.Text + "', " +
    "[CMND] = '" + txtCMND.Text + "', " +
    "[DIACHI] = '" + txtDiaChi.Text + "', " +
    "[PHAI] = '" + cmbGioiTinh.Text + "', " +
    "[SODT] = '" + txtSDT.Text + "', " +
    "[MACN] = '" + macn + "', " +
    "[TrangThaiXoa] = '0' " +
    "WHERE MANV = '" + txtMaNV.Text.Trim() + "'";
             */

                    bdsNhanVien.EndEdit();    // kết thúc quá trình hiệu chỉnh. -> Ghi vào trong bds.
                    bdsNhanVien.ResetCurrentItem();   //Đưa những thông tin đó lên lưới.
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien); // Update trên adapter có 3 nghĩa: vừa là insert, update, delete. Nó tùy vào tình huống cụ thể để đưa lệnh tương ứng.
                    

                    undoList.Push(txtMaNV.Text.Trim());
                    undoList.Push(cauTruyVanHoanTac2);
                    
                    btnPhucHoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }

            gcNhanVien.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnTaiLai.Enabled  = btnPhucHoi.Enabled = btnChuyenChiNhanh.Enabled = btnThoat.Enabled = true;
            btnLuu.Enabled =  false;

            panelControl3.Enabled = false;

        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String tenNV = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])["TrangThaiXoa"].ToString();
            if(tenNV == "1")
            {
                MessageBox.Show("Không thể sửa nhân viên không hoạt động", "",
                     MessageBoxButtons.OK);
                return;
            }
            vitri = bdsNhanVien.Position;
            txtMaNV.Enabled = false;    //ta không cho phép sửa mã nhân viên.
            panelControl3.Enabled = true;
            // btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled =  btnThoat.Enabled = false;
            //btnLuu.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = true;
            //btnLuu.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnLuu.Enabled = btnTaiLai.Enabled = true;
            gcNhanVien.Enabled = false;
            check_Luu_HieuChinh = 2;

            txtCMND.Enabled = false;
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            panelControl3.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled= true;
            btnLuu.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = true;
           // btnLuu.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = true;
            gcNhanVien.Enabled = true;
            try
            {
                this.nhanVienTableAdapter.FillByCmnd(this.DS.NhanVien);   // tải lại Nhân Viên.
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

        private string getMaxMaNV(string maNV)
        {
            maNV = maNV.Substring(2);
            int maNVInt = int.Parse(maNV);
            maNVInt++;
            string result = "NV" + maNVInt.ToString();
            return result;
        }
        private bool kiemTraDuLieuDauVao()
        {
            /*kiem tra txtMANV
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return false;
            }


            if (Regex.IsMatch(txtMaNV.Text, @"^[a-zA-Z0-9 ]+$") == false)
            {   
                MessageBox.Show("Mã nhân viên chỉ chấp nhận số và chữ cái", "Thông báo", MessageBoxButtons.OK);
                txtMaNV.Text = Regex.Replace(txtMaNV.Text, @"\s+", "");
                txtMaNV.Focus();
                return false;
            }
            kiem tra txtHO*/
            if (txtHo.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ và tên", "Thông báo", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            //"^[0-9A-Za-z ]+$"
            if (Regex.IsMatch(txtHo.Text, @"^[\p{L} ]+$") == false)
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

            if (Regex.IsMatch(txtTen.Text, @"^[\p{L} ]+$") == false)
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

            if (Regex.IsMatch(txtDiaChi.Text, @"^[\p{L}0-9, ]+$") == false)
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

            if (Regex.IsMatch(txtCMND.Text, @"^[0-9 ]+$") == false)
            {
                MessageBox.Show("CMND chỉ nhận số", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return false;
            }

            if(txtCMND.Text.Trim().Length < 9)
            {
                MessageBox.Show("CMND Phải đủ 9 số", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return false;
            }


            /* if (!Regex.IsMatch(txtCMND.Text, @"^\d{9}$"))
             {
                 MessageBox.Show("CMND chỉ nhận 9 chữ số", "Thông báo", MessageBoxButtons.OK);
                 txtCMND.Focus();
                 return false;
             }
            */
            if (Regex.IsMatch(txtSDT.Text, @"^[0-9 ]+$") == false)
            {
                MessageBox.Show("SDT chỉ nhận số", "Thông báo", MessageBoxButtons.OK);
                txtSDT.Focus();
                return false;
            }


            return true;
        }

        private void nhanVienBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void pHAIComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int FindPosition( string valueToSearch)
        {
            int a = 1;
            string columnName = "MANV";
            // Kiểm tra xem GridView/GridControl đã được khởi tạo và có dữ liệu hay không
            if (gridView1 != null && gridView1.RowCount > 0)
            {
                // Lặp qua từng hàng trong GridView/GridControl
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    // Lấy giá trị của ô tại cột được chỉ định
                    object cellValue = gridView1.GetRowCellValue(i, columnName);

                    // So sánh giá trị với thông tin cần tìm
                    if (cellValue != null && cellValue.ToString() == valueToSearch)
                    {
                        // Nếu tìm thấy, in ra vị trí hoặc thực hiện hành động phù hợp
                       // MessageBox.Show($"Giá trị được tìm thấy ở hàng {i + 1}");
                        i++;
                        return i ;
                    }
                }

                // Thông báo nếu không tìm thấy
               // MessageBox.Show("Không tìm thấy giá trị trong bảng.");
            }
            
            return a;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undoList.Count == 0)
            {
                MessageBox.Show("Không còn thao tác nào để khôi phục", "Thông báo", MessageBoxButtons.OK);
                btnPhucHoi.Enabled = false;
                return;
            }
            bdsNhanVien.CancelEdit();
            String cauTruyVanHoanTac = undoList.Pop().ToString();

            if (Program.KetNoi() == 0)
            {
                return;
            }
            System.Console.WriteLine(cauTruyVanHoanTac);

            int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);
            this.nhanVienTableAdapter.FillByCmnd(this.DS.NhanVien);
            string m = undoList.Pop().ToString();
            vitri = bdsNhanVien.Find("MANV",m );
            //bdsNhanVien.Position = vitri + 1; // đưa con trỏ nhảy đến vị trí manv đã xóa thất bại trước đó.
            bdsNhanVien.Position = bdsNhanVien.Find("MANV", m);
            // bdsNhanVien.Position = vitri;



           // this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
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
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;    // gán thông tin đăng nhập vào các Adapter tương ứng để fill lấy thông tin đúng với thông tin đăng nhập.
                this.nhanVienTableAdapter.FillByCmnd(this.DS.NhanVien);
                this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
                this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);
            }
        }

        private void btnChuyenChiNhanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String tenNV = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])["MANV"].ToString();
            if (tenNV == Program.username)
            {
                MessageBox.Show("Không thể tự chuyển chi nhánh, hãy nhờ người khác", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string strLenh = "EXEC [SP_MaxMANV] '" + "0" + "'";


            checkMaNV = Program.ExecSqlDataReader(strLenh);
            checkMaNV.Read();
            System.Console.WriteLine(checkMaNV.GetString(0));

            String MaNVC = getMaxMaNV(checkMaNV.GetString(0));
            
            checkMaNV.Close();
            String cmnd = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])["CMND"].ToString();
            String maCN = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])["MACN"].ToString();
            String ho = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])["HO"].ToString();
            String ten = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])["TEN"].ToString();
            String hoten = ho + " " + ten;
            //frmChuyenChiNhanh CNN = new frmChuyenChiNhanh(tenNV, cmnd,maCN, hoten, MaNVC);
            // frmTaoTK CNN = new frmTaoTK();
            frmCCN CNN = new frmCCN(tenNV, cmnd, maCN, hoten, MaNVC);
            CNN.ShowDialog(this);

            this.nhanVienTableAdapter.FillByCmnd(this.DS.NhanVien);
            CNN.Close();

        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && txtCMND.Text.Length < 9)
            {
                e.Handled = true;
            }
            if ( txtCMND.Text.Trim().Length > 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtSDT.Text.Trim().Length > 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
        }

        
        private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtHo.Text.Trim().Length > 39 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
            */
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

        private void fillByCmndToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.FillByCmnd(this.DS.NhanVien);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

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
    }
}