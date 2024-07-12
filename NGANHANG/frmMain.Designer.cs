
namespace NGANHANG
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTKNV = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnGuiRutTien = new DevExpress.XtraBars.BarButtonItem();
            this.btnChuyenTien = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoTK = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoLoginKH = new DevExpress.XtraBars.BarButtonItem();
            this.ribHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.btnDangXuat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribQuanLy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribNghiepVu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MaNV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.Nhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.btnDangNhap,
            this.btnTaoTKNV,
            this.btnKhachHang,
            this.btnNhanVien,
            this.btnGuiRutTien,
            this.btnChuyenTien,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btnMoTK,
            this.btnTaoLoginKH});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribHeThong,
            this.ribQuanLy,
            this.ribNghiepVu,
            this.ribBaoCao});
            this.ribbonControl1.Size = new System.Drawing.Size(1278, 209);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Đăng Xuất";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Caption = "Đăng nhập";
            this.btnDangNhap.Id = 2;
            this.btnDangNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDangNhap.ImageOptions.SvgImage")));
            this.btnDangNhap.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDangNhap.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnDangNhap.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDangNhap.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDangNhap.ItemInMenuAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDangNhap.ItemInMenuAppearance.Disabled.Options.UseFont = true;
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangNhap_ItemClick);
            // 
            // btnTaoTKNV
            // 
            this.btnTaoTKNV.Caption = "Tạo Tài Khoản";
            this.btnTaoTKNV.Id = 3;
            this.btnTaoTKNV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoTKNV.ImageOptions.SvgImage")));
            this.btnTaoTKNV.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTaoTKNV.ItemAppearance.Normal.Options.UseFont = true;
            this.btnTaoTKNV.Name = "btnTaoTKNV";
            this.btnTaoTKNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTKNV_ItemClick);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Caption = "Khách Hàng";
            this.btnKhachHang.Id = 4;
            this.btnKhachHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.Image")));
            this.btnKhachHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.LargeImage")));
            this.btnKhachHang.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnKhachHang.ItemAppearance.Normal.Options.UseFont = true;
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhachHang_ItemClick);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Caption = "Nhân Viên";
            this.btnNhanVien.Id = 5;
            this.btnNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.ImageOptions.Image")));
            this.btnNhanVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.ImageOptions.LargeImage")));
            this.btnNhanVien.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnNhanVien.ItemAppearance.Normal.Options.UseFont = true;
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhanVien_ItemClick);
            // 
            // btnGuiRutTien
            // 
            this.btnGuiRutTien.Caption = "Gửi Rút Chuyển tiền";
            this.btnGuiRutTien.Id = 6;
            this.btnGuiRutTien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuiRutTien.ImageOptions.Image")));
            this.btnGuiRutTien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGuiRutTien.ImageOptions.LargeImage")));
            this.btnGuiRutTien.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnGuiRutTien.ItemAppearance.Normal.Options.UseFont = true;
            this.btnGuiRutTien.Name = "btnGuiRutTien";
            this.btnGuiRutTien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuiRutTien_ItemClick);
            // 
            // btnChuyenTien
            // 
            this.btnChuyenTien.Caption = "Chuyển tiền";
            this.btnChuyenTien.Id = 7;
            this.btnChuyenTien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChuyenTien.ImageOptions.Image")));
            this.btnChuyenTien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChuyenTien.ImageOptions.LargeImage")));
            this.btnChuyenTien.Name = "btnChuyenTien";
            this.btnChuyenTien.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sao kê giao dịch";
            this.barButtonItem2.Id = 8;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barButtonItem2.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Liệt kê tài khoản";
            this.barButtonItem3.Id = 9;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Liệt kê khách hàng";
            this.barButtonItem4.Id = 10;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // btnMoTK
            // 
            this.btnMoTK.Caption = "Mở Tài Khoản ";
            this.btnMoTK.Id = 11;
            this.btnMoTK.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMoTK.ImageOptions.SvgImage")));
            this.btnMoTK.Name = "btnMoTK";
            this.btnMoTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoTK_ItemClick);
            // 
            // btnTaoLoginKH
            // 
            this.btnTaoLoginKH.Caption = "Tạo Login Khách Hàng";
            this.btnTaoLoginKH.Id = 12;
            this.btnTaoLoginKH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoLoginKH.ImageOptions.SvgImage")));
            this.btnTaoLoginKH.Name = "btnTaoLoginKH";
            this.btnTaoLoginKH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoLoginKH_ItemClick);
            // 
            // ribHeThong
            // 
            this.ribHeThong.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ribHeThong.Appearance.Options.UseFont = true;
            this.ribHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.btnDangXuat,
            this.ribbonPageGroup1});
            this.ribHeThong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribHeThong.ImageOptions.Image")));
            this.ribHeThong.Name = "ribHeThong";
            this.ribHeThong.Text = "Hệ Thống";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDangXuat.ImageOptions.SvgImage")));
            this.btnDangXuat.ItemLinks.Add(this.barButtonItem1);
            this.btnDangXuat.Name = "btnDangXuat";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTaoTKNV);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribQuanLy
            // 
            this.ribQuanLy.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ribQuanLy.Appearance.Options.UseFont = true;
            this.ribQuanLy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup6});
            this.ribQuanLy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribQuanLy.ImageOptions.Image")));
            this.ribQuanLy.Name = "ribQuanLy";
            this.ribQuanLy.Text = "Quản Lý";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKhachHang);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnNhanVien);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribNghiepVu
            // 
            this.ribNghiepVu.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ribNghiepVu.Appearance.Options.UseFont = true;
            this.ribNghiepVu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9});
            this.ribNghiepVu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribNghiepVu.ImageOptions.Image")));
            this.ribNghiepVu.Name = "ribNghiepVu";
            this.ribNghiepVu.Text = "Nghiệp Vụ";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnGuiRutTien);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnMoTK);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btnTaoLoginKH);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            // 
            // ribBaoCao
            // 
            this.ribBaoCao.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ribBaoCao.Appearance.Options.UseFont = true;
            this.ribBaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup7});
            this.ribBaoCao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribBaoCao.ImageOptions.Image")));
            this.ribBaoCao.Name = "ribBaoCao";
            this.ribBaoCao.Text = "Báo Cáo";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaNV,
            this.HoTen,
            this.Nhom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1278, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MaNV
            // 
            this.MaNV.Name = "MaNV";
            this.MaNV.Size = new System.Drawing.Size(105, 20);
            this.MaNV.Text = "Mã Nhân Viên:";
            // 
            // HoTen
            // 
            this.HoTen.Name = "HoTen";
            this.HoTen.Size = new System.Drawing.Size(57, 20);
            this.HoTen.Text = "Họ tên:";
            // 
            // Nhom
            // 
            this.Nhom.Name = "Nhom";
            this.Nhom.Size = new System.Drawing.Size(57, 20);
            this.Nhom.Text = "Nhóm: ";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 559);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup btnDangXuat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel MaNV;
        public System.Windows.Forms.ToolStripStatusLabel HoTen;
        public System.Windows.Forms.ToolStripStatusLabel Nhom;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribQuanLy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribNghiepVu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnDangNhap;
        private DevExpress.XtraBars.BarButtonItem btnTaoTKNV;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnKhachHang;
        private DevExpress.XtraBars.BarButtonItem btnNhanVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnGuiRutTien;
        private DevExpress.XtraBars.BarButtonItem btnChuyenTien;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnMoTK;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btnTaoLoginKH;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
    }
}

