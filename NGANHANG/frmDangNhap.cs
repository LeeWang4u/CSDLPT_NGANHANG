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
using System.Diagnostics;
using NGANHANG.Lib;

namespace NGANHANG
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm

    {





        private static SqlConnection conn_publisher = new SqlConnection();
        private static SqlConnection conn_publisher1 = new SqlConnection(Program.connstr_publisher);

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;   //nếu frmMain đã tồn tại thì trả về f, không thì trả về null.
            return null;
        }
        public static int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == System.Data.ConnectionState.Open)
                conn_publisher.Close();   // Khi ta mở sever và tải dữ liệu về thì trong vòng từ 5-10s nó sẽ tự đóng -> trong trường hợp ta kiểm tra mà sever vẫn mở nhưng khi tải dữ liệu về thì nó sẽ tự động đóng gây ra lỗi. 
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;   // gán Tên sever + tên DB từ connstr_publisher vào ConnectionString.
                conn_publisher.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở dữ liệu gốc.\nBạn xem lại Tên sever của publisher và tên CSDL trong chuỗi kết nối.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable(); //trả về một data table.
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher); // Tạo ra một đối tượng thuộc lớp SqlDataAdapter có 2 tham số là chuỗi lệnh và đối tượng SqlConnection.
            da.Fill(dt);    // Muốn tải số liệu từ View,Table từ DataAdapter vào DataTable thì ta dùng Fill -> dt sẽ chứa các danh sách phân mảnh.
            
            conn_publisher.Close();

            Program.bds_dspm = new BindingSource();
            Program.bds_dspm.DataSource = dt;   // ta gán dspm đó cho bds_dspm ở Program.    // Liên kết số liệu bds_dspm với cmd

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Program.data[i, 0] = dt.Rows[i]["TENCN"].ToString();     // TENCN là tên cột chứa Tên chi nhánh
                Program.data[i, 1] = dt.Rows[i]["TENSERVER"].ToString(); // TENSERVER là tên cột chứa Tên server
            }

            cmbChiNhanh.DataSource = Program.bds_dspm;  // gán bds_dspm ở Program cho DataSource ở cmbChiNhanh. //
            cmbChiNhanh.DisplayMember = "TENCN"; cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.ChiNhanh' table. You can move, or remove it, as needed.
            this.chiNhanhTableAdapter.Fill(this.dS.ChiNhanh);
            txbMatKhau.PasswordChar = '*';
            if (KetNoi_CSDLGOC() == 0) return; // nếu hàm KetNoi_CSDLGOC() == 0 -> đăng nhập thất bại
            LayDSPM("SELECT * FROM Get_Subscribes");  // Lấy ra danh sách các phân mảnh từ Get_Subscribles.
            cmbChiNhanh.SelectedIndex = 1; cmbChiNhanh.SelectedIndex = 0;
           
         
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmbChiNhanh.SelectedValue.ToString();   // Lấy Value Member gán vào severname của Program.
                // Trong Value Member thuộc tính chứa giá trị trên đó -> SelectedValue
                // Trong Display Member thuộc tính chứa giá trị trên đó -> Text
            }
            catch (Exception) { }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String khachHang = "";
            if (cbKhachHang.Checked)
            {
                khachHang = "KHACHHANG";
            }
            else
            {
                khachHang = "HELLO";
            }
                Form frm = this.CheckExists(typeof(frmMain));
                if (txbTaiKhoan.Text.Trim() == "" || txbMatKhau.Text.Trim() == "")
                {    // hàm Trim để xóa khoảng trắng 2 bên.
                    MessageBox.Show("Login name và mật mā không được trống", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mlogin = txbTaiKhoan.Text; Program.password = txbMatKhau.Text;
                if (Program.KetNoi() == 0) return;

                /*Debug.WriteLine(Program.mlogin);
                Debug.WriteLine(Program.password);*/
                string strLenh = "EXEC SP_Lay_Thong_Tin_Tu_Login '" + Program.mlogin + "', '" + khachHang + "'";
            //Debug.WriteLine(strLenh);
            Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null || !Program.myReader.HasRows)
                {
                    MessageBox.Show("Bạn không có quyền truy cập!", "", MessageBoxButtons.OK);
                    return;   //nếu bằng null có nghĩa là không lấy được thông tin nhân viên -> kết thúc.  
                }
                Program.myReader.Read();    // Khi thực thi xong SP_Lay_Thong... thì nó chỉ trả ra 1 hàng nên ta chỉ cần Read() 1 lần. Nếu nhiều hàng thì ta phải tạo ra một vòng lặp và lặp cho đến khi Read()==null để lấy ra.

                Program.username = Program.myReader.GetString(0); // Lay user name      //GetString(0) là cột đầu tiên chứa MANV.
                Debug.WriteLine("");

                if (Convert.IsDBNull(Program.username) )
                {
                    Console.WriteLine(Program.username);
                    MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                    return;
                }

                // Setup DbConnection
                DbConnection.SetDefaultConnectionString($"Data Source={Program.servername};Initial Catalog={Program.database};User ID={Program.mlogin};password={Program.password}");

                Program.mChinhanh = cmbChiNhanh.SelectedIndex;  //Nếu đăng nhập thành công thì ta sẽ giữ lại thông tin vừa đăng nhập như chi nhánh nào.
                Program.mloginDN = Program.mlogin;              //tài khoản đăng nhập thành công.   -> sẽ còn dùng cho những form sau này.
                Program.passwordDN = Program.password;          //mật khẩu đăng nhập thành công.
                System.Console.WriteLine(Program.myReader.GetString(2));
                Program.mHoten = Program.myReader.GetString(1); //GetString(1) chứa HOTEN
                Program.mGroup = Program.myReader.GetString(2); //GetString(2) chứa NHOM
                Program.myReader.Close();
                Program.conn.Close();
                // MessageBox.Show("Siuuuuuu");
                Program.frmChinh.MaNV.Text = "Mã NV = " + Program.username;
                Program.frmChinh.HoTen.Text = "Họ tên = " + Program.mHoten;
                Program.frmChinh.Nhom.Text = "Nhóm = " + Program.mGroup;
                //this.Visible = false;
                this.Hide();
                // Program.frmChinh.HienThiMenu();
                // this.Close();
                frmMain form = new frmMain();
                form.ShowDialog();
                //    Program.frmChinh.ShowDialog();
                Close();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbKhachHang_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chiNhanhBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.chiNhanhBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }
    }
}