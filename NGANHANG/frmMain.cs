using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
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

        public void HienThiMenu()
        {
            MaNV.Text = "Mã NV: " + Program.username;
            HoTen.Text = "; Họ tên: " + Program.mHoten;
            Nhom.Text = "; Nhóm: " + Program.mGroup;

        }

            private void frmMain_Load(object sender, EventArgs e)
        {
            MaNV.Text = "Mã NV: " + Program.username;
            HoTen.Text = "; Họ tên: " + Program.mHoten;
            Nhom.Text = "; Nhóm: " + Program.mGroup;

        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( Program.mGroup == "KHACHHANG")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = this.CheckExists(typeof(frmNV));
            if (frm != null) frm.Activate();
            else
            {
                frmNV f = new frmNV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnGuiRutTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "NGANHANG"  || Program.mGroup == "KHACHHANG")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = this.CheckExists(typeof(frmGiaoDich));
            if (frm != null) frm.Activate();
            else
            {
                frmGiaoDich f = new frmGiaoDich();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTaoTKNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "KHACHHANG")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = this.CheckExists(typeof(frmTaoTKNV));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoTKNV f = new frmTaoTKNV();
                f.MdiParent = this;
                f.Show();
            }
        }

        // btn dangxuat
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.Hide();

            try
            {
                Program.servername = "";
                Program.username = "";
                Program.mlogin = "";
                Program.password = "";
                Program.mloginDN = "";
                Program.passwordDN = "";
                MaNV.Text = "MANV "; HoTen.Text = "HOTEN "; Nhom.Text = "NHOM";
                if (Program.conn.State == ConnectionState.Open) Program.conn.Close();   //Nếu đang mở kết nối thì ta đóng lại.

                Form[] childArray = this.MdiChildren;   //Đóng hết tất cả form con đang mở.
                foreach (Form childForm in childArray)
                {
                    childForm.Close();
                }

                Form f = this.CheckExists(typeof(frmDangNhap));
                if (f != null)
                {
                    f.Activate();
                }
                else
                {
                    // if (this.Visible)
                    // {
                    // Nếu đang hiển thị, ẩn form hiện tại
                    //   
                    // }

          
                    this.Visible = false;
                    frmDangNhap form = new frmDangNhap();
                    //form.MdiParent = this;
                    // Program.frmChinh.Close();
                     form.ShowDialog();
                   
                    this.Close();
                }
                //rib_BaoCao.Visible = rib_DanhMuc.Visible = rib_NghiepVu.Visible = false;
               
              //  MessageBox.Show("Đăng xuất thành công.", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            return;
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "KHACHHANG")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = this.CheckExists(typeof(frmKH));
            if (frm != null) frm.Activate();
            else
            {
                frmKH f = new frmKH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "KHACHHANG")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = this.CheckExists(typeof(frmMoTK));
            if (frm != null) frm.Activate();
            else
            {
                frmMoTK f = new frmMoTK();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTaoLoginKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "KHACHHANG")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = this.CheckExists(typeof(frmTaoLoginKH));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoLoginKH f = new frmTaoLoginKH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Frpt_SaoKeTaiKhoanNganHang));
            if (frm != null) frm.Activate();
            else
            {
                Frpt_SaoKeTaiKhoanNganHang f = new Frpt_SaoKeTaiKhoanNganHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "KHACHHANG")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = this.CheckExists(typeof(Frpt_LietKeTaiKhoan));
            if (frm != null) frm.Activate();
            else
            {
                Frpt_LietKeTaiKhoan f = new Frpt_LietKeTaiKhoan();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "KHACHHANG")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = this.CheckExists(typeof(Frpt_LietKeKhachHang));
            if (frm != null) frm.Activate();
            else
            {
                Frpt_LietKeKhachHang f = new Frpt_LietKeKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
