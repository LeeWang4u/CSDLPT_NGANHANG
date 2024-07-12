
namespace NGANHANG
{
    partial class frmNV
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
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label hOLabel;
            System.Windows.Forms.Label tENLabel;
            System.Windows.Forms.Label cMNDLabel;
            System.Windows.Forms.Label dIACHILabel;
            System.Windows.Forms.Label pHAILabel;
            System.Windows.Forms.Label sODTLabel;
            System.Windows.Forms.Label mACNLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label trangThaiXoaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNV));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnHieuChinh = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaiLai = new DevExpress.XtraBars.BarButtonItem();
            this.btnChuyenChiNhanh = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gcNhanVien = new DevExpress.XtraGrid.GridControl();
            this.bdsNhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new NGANHANG.DS();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPHAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThaiXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nhanVienTableAdapter = new NGANHANG.DSTableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new NGANHANG.DSTableAdapters.TableAdapterManager();
            this.mANVTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.hOTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tENTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cMNDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dIACHITextEdit = new DevExpress.XtraEditors.TextEdit();
            this.pHAIComboBox = new System.Windows.Forms.ComboBox();
            this.sODTTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.mACNComboBox = new System.Windows.Forms.ComboBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txbTrangThaiXoa = new DevExpress.XtraEditors.SpinEdit();
            this.txtChiNhanh = new System.Windows.Forms.ComboBox();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.cmbGioiTinh = new System.Windows.Forms.ComboBox();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtCMND = new DevExpress.XtraEditors.TextEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtHo = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.bdsGD_GUIRUT = new System.Windows.Forms.BindingSource(this.components);
            this.gD_GOIRUTTableAdapter = new NGANHANG.DSTableAdapters.GD_GOIRUTTableAdapter();
            this.bdsGD_CHUYENTIEN = new System.Windows.Forms.BindingSource(this.components);
            this.gD_CHUYENTIENTableAdapter = new NGANHANG.DSTableAdapters.GD_CHUYENTIENTableAdapter();
            this.fillByCmndToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByCmndToolStripButton = new System.Windows.Forms.ToolStripButton();
            mANVLabel = new System.Windows.Forms.Label();
            hOLabel = new System.Windows.Forms.Label();
            tENLabel = new System.Windows.Forms.Label();
            cMNDLabel = new System.Windows.Forms.Label();
            dIACHILabel = new System.Windows.Forms.Label();
            pHAILabel = new System.Windows.Forms.Label();
            sODTLabel = new System.Windows.Forms.Label();
            mACNLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            trangThaiXoaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mANVTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tENTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMNDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dIACHITextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sODTTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbTrangThaiXoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMND.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGD_GUIRUT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGD_CHUYENTIEN)).BeginInit();
            this.fillByCmndToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(33, 408);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(95, 17);
            mANVLabel.TabIndex = 14;
            mANVLabel.Text = "Mã Nhân Viên:";
            // 
            // hOLabel
            // 
            hOLabel.AutoSize = true;
            hOLabel.Location = new System.Drawing.Point(341, 410);
            hOLabel.Name = "hOLabel";
            hOLabel.Size = new System.Drawing.Size(30, 17);
            hOLabel.TabIndex = 15;
            hOLabel.Text = "Họ:";
            // 
            // tENLabel
            // 
            tENLabel.AutoSize = true;
            tENLabel.Location = new System.Drawing.Point(662, 410);
            tENLabel.Name = "tENLabel";
            tENLabel.Size = new System.Drawing.Size(36, 17);
            tENLabel.TabIndex = 16;
            tENLabel.Text = "Tên:";
            // 
            // cMNDLabel
            // 
            cMNDLabel.AutoSize = true;
            cMNDLabel.Location = new System.Drawing.Point(30, 463);
            cMNDLabel.Name = "cMNDLabel";
            cMNDLabel.Size = new System.Drawing.Size(51, 17);
            cMNDLabel.TabIndex = 17;
            cMNDLabel.Text = "CMND:";
            // 
            // dIACHILabel
            // 
            dIACHILabel.AutoSize = true;
            dIACHILabel.Location = new System.Drawing.Point(643, 464);
            dIACHILabel.Name = "dIACHILabel";
            dIACHILabel.Size = new System.Drawing.Size(55, 17);
            dIACHILabel.TabIndex = 18;
            dIACHILabel.Text = "Địa Chỉ:";
            // 
            // pHAILabel
            // 
            pHAILabel.AutoSize = true;
            pHAILabel.Location = new System.Drawing.Point(331, 467);
            pHAILabel.Name = "pHAILabel";
            pHAILabel.Size = new System.Drawing.Size(61, 17);
            pHAILabel.TabIndex = 19;
            pHAILabel.Text = "Giới tính:";
            // 
            // sODTLabel
            // 
            sODTLabel.AutoSize = true;
            sODTLabel.Location = new System.Drawing.Point(30, 514);
            sODTLabel.Name = "sODTLabel";
            sODTLabel.Size = new System.Drawing.Size(97, 17);
            sODTLabel.TabIndex = 20;
            sODTLabel.Text = "Số Điện Thoại:";
            // 
            // mACNLabel
            // 
            mACNLabel.AutoSize = true;
            mACNLabel.Location = new System.Drawing.Point(311, 519);
            mACNLabel.Name = "mACNLabel";
            mACNLabel.Size = new System.Drawing.Size(97, 17);
            mACNLabel.TabIndex = 21;
            mACNLabel.Text = "Mã Chi Nhánh:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 12F);
            label2.Location = new System.Drawing.Point(354, 156);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(140, 24);
            label2.TabIndex = 36;
            label2.Text = "Mã Chi Nhánh:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 12F);
            label3.Location = new System.Drawing.Point(28, 150);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(142, 24);
            label3.TabIndex = 34;
            label3.Text = "Số Điện Thoại:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 12F);
            label4.Location = new System.Drawing.Point(355, 107);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 24);
            label4.TabIndex = 32;
            label4.Text = "Giới tính:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 12F);
            label5.Location = new System.Drawing.Point(684, 95);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(81, 24);
            label5.TabIndex = 30;
            label5.Text = "Địa Chỉ:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 12F);
            label6.Location = new System.Drawing.Point(28, 99);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(71, 24);
            label6.TabIndex = 28;
            label6.Text = "CMND:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 12F);
            label7.Location = new System.Drawing.Point(682, 49);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(51, 24);
            label7.TabIndex = 26;
            label7.Text = "Tên:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 12F);
            label8.Location = new System.Drawing.Point(354, 50);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(42, 24);
            label8.TabIndex = 24;
            label8.Text = "Họ:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 12F);
            label9.Location = new System.Drawing.Point(31, 44);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(140, 24);
            label9.TabIndex = 23;
            label9.Text = "Mã Nhân Viên:";
            // 
            // trangThaiXoaLabel
            // 
            trangThaiXoaLabel.AutoSize = true;
            trangThaiXoaLabel.Font = new System.Drawing.Font("Tahoma", 12F);
            trangThaiXoaLabel.Location = new System.Drawing.Point(684, 162);
            trangThaiXoaLabel.Name = "trangThaiXoaLabel";
            trangThaiXoaLabel.Size = new System.Drawing.Size(154, 24);
            trangThaiXoaLabel.TabIndex = 38;
            trangThaiXoaLabel.Text = "Trang Thai Xoa:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnHieuChinh,
            this.btnLuu,
            this.btnPhucHoi,
            this.btnTaiLai,
            this.btnThoat,
            this.btnChuyenChiNhanh});
            this.barManager1.MaxItemId = 8;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHieuChinh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLuu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPhucHoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTaiLai),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnChuyenChiNhanh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat)});
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnThem.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnThem.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnThem.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnThem.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnThem.ItemAppearance.Normal.Options.UseFont = true;
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnXoa.ItemAppearance.Normal.Options.UseFont = true;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnHieuChinh
            // 
            this.btnHieuChinh.Caption = "Hiệu Chỉnh";
            this.btnHieuChinh.Id = 2;
            this.btnHieuChinh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHieuChinh.ImageOptions.Image")));
            this.btnHieuChinh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHieuChinh.ImageOptions.LargeImage")));
            this.btnHieuChinh.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnHieuChinh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnHieuChinh.Name = "btnHieuChinh";
            this.btnHieuChinh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnHieuChinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHieuChinh_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.LargeImage")));
            this.btnLuu.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnLuu.ItemAppearance.Normal.Options.UseFont = true;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Phục hồi";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.ImageOptions.Image")));
            this.btnPhucHoi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.ImageOptions.LargeImage")));
            this.btnPhucHoi.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnPhucHoi.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Caption = "Tải lại";
            this.btnTaiLai.Id = 5;
            this.btnTaiLai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiLai.ImageOptions.Image")));
            this.btnTaiLai.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaiLai.ImageOptions.LargeImage")));
            this.btnTaiLai.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnTaiLai.ItemAppearance.Normal.Options.UseFont = true;
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnTaiLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaiLai_ItemClick);
            // 
            // btnChuyenChiNhanh
            // 
            this.btnChuyenChiNhanh.Caption = "Chuyển chi nhánh";
            this.btnChuyenChiNhanh.Id = 7;
            this.btnChuyenChiNhanh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChuyenChiNhanh.ImageOptions.Image")));
            this.btnChuyenChiNhanh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChuyenChiNhanh.ImageOptions.LargeImage")));
            this.btnChuyenChiNhanh.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnChuyenChiNhanh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnChuyenChiNhanh.Name = "btnChuyenChiNhanh";
            this.btnChuyenChiNhanh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnChuyenChiNhanh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChuyenChiNhanh_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.LargeImage")));
            this.btnThoat.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnThoat.ItemAppearance.Normal.Options.UseFont = true;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1092, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1018);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1092, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 988);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1092, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 988);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbChiNhanh);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 30);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1092, 67);
            this.panelControl1.TabIndex = 4;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(299, 22);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(248, 30);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(194, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi Nhánh:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.splitterControl1);
            this.panelControl2.Controls.Add(this.gcNhanVien);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 97);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1092, 285);
            this.panelControl2.TabIndex = 5;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(2, 2);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(12, 281);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // gcNhanVien
            // 
            this.gcNhanVien.DataSource = this.bdsNhanVien;
            this.gcNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNhanVien.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcNhanVien.Location = new System.Drawing.Point(2, 2);
            this.gcNhanVien.MainView = this.gridView1;
            this.gcNhanVien.MenuManager = this.barManager1;
            this.gcNhanVien.Name = "gcNhanVien";
            this.gcNhanVien.Size = new System.Drawing.Size(1088, 281);
            this.gcNhanVien.TabIndex = 0;
            this.gcNhanVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bdsNhanVien
            // 
            this.bdsNhanVien.DataMember = "NhanVien";
            this.bdsNhanVien.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMANV,
            this.colHO,
            this.colTEN,
            this.colCMND,
            this.colDIACHI,
            this.colPHAI,
            this.colSODT,
            this.colMACN,
            this.colTrangThaiXoa});
            this.gridView1.GridControl = this.gcNhanVien;
            this.gridView1.Name = "gridView1";
            // 
            // colMANV
            // 
            this.colMANV.Caption = "MANV";
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 0;
            this.colMANV.Width = 94;
            // 
            // colHO
            // 
            this.colHO.Caption = "Họ";
            this.colHO.FieldName = "HO";
            this.colHO.MinWidth = 25;
            this.colHO.Name = "colHO";
            this.colHO.Visible = true;
            this.colHO.VisibleIndex = 1;
            this.colHO.Width = 94;
            // 
            // colTEN
            // 
            this.colTEN.Caption = "Tên";
            this.colTEN.FieldName = "TEN";
            this.colTEN.MinWidth = 25;
            this.colTEN.Name = "colTEN";
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 2;
            this.colTEN.Width = 94;
            // 
            // colCMND
            // 
            this.colCMND.Caption = "CMND";
            this.colCMND.FieldName = "CMND";
            this.colCMND.MinWidth = 25;
            this.colCMND.Name = "colCMND";
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 3;
            this.colCMND.Width = 94;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa Chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 25;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 4;
            this.colDIACHI.Width = 94;
            // 
            // colPHAI
            // 
            this.colPHAI.Caption = "Giới Tính";
            this.colPHAI.FieldName = "PHAI";
            this.colPHAI.MinWidth = 25;
            this.colPHAI.Name = "colPHAI";
            this.colPHAI.Visible = true;
            this.colPHAI.VisibleIndex = 5;
            this.colPHAI.Width = 94;
            // 
            // colSODT
            // 
            this.colSODT.Caption = "Số Điện Thoại";
            this.colSODT.FieldName = "SODT";
            this.colSODT.MinWidth = 25;
            this.colSODT.Name = "colSODT";
            this.colSODT.Visible = true;
            this.colSODT.VisibleIndex = 6;
            this.colSODT.Width = 94;
            // 
            // colMACN
            // 
            this.colMACN.Caption = "Mã Chi Nhánh";
            this.colMACN.FieldName = "MACN";
            this.colMACN.MinWidth = 25;
            this.colMACN.Name = "colMACN";
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 7;
            this.colMACN.Width = 94;
            // 
            // colTrangThaiXoa
            // 
            this.colTrangThaiXoa.FieldName = "TrangThaiXoa";
            this.colTrangThaiXoa.MinWidth = 25;
            this.colTrangThaiXoa.Name = "colTrangThaiXoa";
            this.colTrangThaiXoa.Visible = true;
            this.colTrangThaiXoa.VisibleIndex = 8;
            this.colTrangThaiXoa.Width = 94;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.TaiKhoanTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NGANHANG.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mANVTextEdit
            // 
            this.mANVTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "MANV", true));
            this.mANVTextEdit.Location = new System.Drawing.Point(129, 405);
            this.mANVTextEdit.MenuManager = this.barManager1;
            this.mANVTextEdit.Name = "mANVTextEdit";
            this.mANVTextEdit.Size = new System.Drawing.Size(149, 22);
            this.mANVTextEdit.TabIndex = 15;
            // 
            // hOTextEdit
            // 
            this.hOTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "HO", true));
            this.hOTextEdit.Location = new System.Drawing.Point(414, 407);
            this.hOTextEdit.MenuManager = this.barManager1;
            this.hOTextEdit.Name = "hOTextEdit";
            this.hOTextEdit.Size = new System.Drawing.Size(196, 22);
            this.hOTextEdit.TabIndex = 16;
            // 
            // tENTextEdit
            // 
            this.tENTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "TEN", true));
            this.tENTextEdit.Location = new System.Drawing.Point(706, 407);
            this.tENTextEdit.MenuManager = this.barManager1;
            this.tENTextEdit.Name = "tENTextEdit";
            this.tENTextEdit.Size = new System.Drawing.Size(201, 22);
            this.tENTextEdit.TabIndex = 17;
            // 
            // cMNDTextEdit
            // 
            this.cMNDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "CMND", true));
            this.cMNDTextEdit.Location = new System.Drawing.Point(129, 460);
            this.cMNDTextEdit.MenuManager = this.barManager1;
            this.cMNDTextEdit.Name = "cMNDTextEdit";
            this.cMNDTextEdit.Size = new System.Drawing.Size(149, 22);
            this.cMNDTextEdit.TabIndex = 18;
            // 
            // dIACHITextEdit
            // 
            this.dIACHITextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "DIACHI", true));
            this.dIACHITextEdit.Location = new System.Drawing.Point(706, 461);
            this.dIACHITextEdit.MenuManager = this.barManager1;
            this.dIACHITextEdit.Name = "dIACHITextEdit";
            this.dIACHITextEdit.Size = new System.Drawing.Size(326, 22);
            this.dIACHITextEdit.TabIndex = 19;
            // 
            // pHAIComboBox
            // 
            this.pHAIComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsNhanVien, "PHAI", true));
            this.pHAIComboBox.FormattingEnabled = true;
            this.pHAIComboBox.Location = new System.Drawing.Point(414, 467);
            this.pHAIComboBox.Name = "pHAIComboBox";
            this.pHAIComboBox.Size = new System.Drawing.Size(121, 24);
            this.pHAIComboBox.TabIndex = 20;
            this.pHAIComboBox.SelectedIndexChanged += new System.EventHandler(this.pHAIComboBox_SelectedIndexChanged);
            // 
            // sODTTextEdit
            // 
            this.sODTTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "SODT", true));
            this.sODTTextEdit.Location = new System.Drawing.Point(133, 511);
            this.sODTTextEdit.MenuManager = this.barManager1;
            this.sODTTextEdit.Name = "sODTTextEdit";
            this.sODTTextEdit.Size = new System.Drawing.Size(149, 22);
            this.sODTTextEdit.TabIndex = 21;
            // 
            // mACNComboBox
            // 
            this.mACNComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsNhanVien, "MACN", true));
            this.mACNComboBox.FormattingEnabled = true;
            this.mACNComboBox.Location = new System.Drawing.Point(414, 516);
            this.mACNComboBox.Name = "mACNComboBox";
            this.mACNComboBox.Size = new System.Drawing.Size(196, 24);
            this.mACNComboBox.TabIndex = 22;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(trangThaiXoaLabel);
            this.panelControl3.Controls.Add(this.txbTrangThaiXoa);
            this.panelControl3.Controls.Add(label2);
            this.panelControl3.Controls.Add(this.txtChiNhanh);
            this.panelControl3.Controls.Add(label3);
            this.panelControl3.Controls.Add(this.txtSDT);
            this.panelControl3.Controls.Add(label4);
            this.panelControl3.Controls.Add(this.cmbGioiTinh);
            this.panelControl3.Controls.Add(label5);
            this.panelControl3.Controls.Add(this.txtDiaChi);
            this.panelControl3.Controls.Add(label6);
            this.panelControl3.Controls.Add(this.txtCMND);
            this.panelControl3.Controls.Add(label7);
            this.panelControl3.Controls.Add(this.txtTen);
            this.panelControl3.Controls.Add(label8);
            this.panelControl3.Controls.Add(this.txtHo);
            this.panelControl3.Controls.Add(label9);
            this.panelControl3.Controls.Add(this.txtMaNV);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 382);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1092, 636);
            this.panelControl3.TabIndex = 27;
            this.panelControl3.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl3_Paint);
            // 
            // txbTrangThaiXoa
            // 
            this.txbTrangThaiXoa.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "TrangThaiXoa", true));
            this.txbTrangThaiXoa.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txbTrangThaiXoa.Location = new System.Drawing.Point(844, 159);
            this.txbTrangThaiXoa.MenuManager = this.barManager1;
            this.txbTrangThaiXoa.Name = "txbTrangThaiXoa";
            this.txbTrangThaiXoa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txbTrangThaiXoa.Properties.Appearance.Options.UseFont = true;
            this.txbTrangThaiXoa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txbTrangThaiXoa.Size = new System.Drawing.Size(125, 30);
            this.txbTrangThaiXoa.TabIndex = 39;
            // 
            // txtChiNhanh
            // 
            this.txtChiNhanh.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsNhanVien, "MACN", true));
            this.txtChiNhanh.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtChiNhanh.FormattingEnabled = true;
            this.txtChiNhanh.Location = new System.Drawing.Point(500, 153);
            this.txtChiNhanh.Name = "txtChiNhanh";
            this.txtChiNhanh.Size = new System.Drawing.Size(151, 32);
            this.txtChiNhanh.TabIndex = 38;
            // 
            // txtSDT
            // 
            this.txtSDT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "SODT", true));
            this.txtSDT.Location = new System.Drawing.Point(176, 150);
            this.txtSDT.MenuManager = this.barManager1;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSDT.Properties.Appearance.Options.UseFont = true;
            this.txtSDT.Size = new System.Drawing.Size(149, 30);
            this.txtSDT.TabIndex = 37;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // cmbGioiTinh
            // 
            this.cmbGioiTinh.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsNhanVien, "PHAI", true));
            this.cmbGioiTinh.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbGioiTinh.FormattingEnabled = true;
            this.cmbGioiTinh.Location = new System.Drawing.Point(452, 107);
            this.cmbGioiTinh.Name = "cmbGioiTinh";
            this.cmbGioiTinh.Size = new System.Drawing.Size(121, 32);
            this.cmbGioiTinh.TabIndex = 35;
            this.cmbGioiTinh.Text = "Nam";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "DIACHI", true));
            this.txtDiaChi.Location = new System.Drawing.Point(771, 92);
            this.txtDiaChi.MenuManager = this.barManager1;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Size = new System.Drawing.Size(326, 30);
            this.txtDiaChi.TabIndex = 33;
            // 
            // txtCMND
            // 
            this.txtCMND.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "CMND", true));
            this.txtCMND.Location = new System.Drawing.Point(176, 93);
            this.txtCMND.MenuManager = this.barManager1;
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCMND.Properties.Appearance.Options.UseFont = true;
            this.txtCMND.Size = new System.Drawing.Size(149, 30);
            this.txtCMND.TabIndex = 31;
            this.txtCMND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCMND_KeyPress);
            // 
            // txtTen
            // 
            this.txtTen.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "TEN", true));
            this.txtTen.Location = new System.Drawing.Point(739, 46);
            this.txtTen.MenuManager = this.barManager1;
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTen.Properties.Appearance.Options.UseFont = true;
            this.txtTen.Size = new System.Drawing.Size(201, 30);
            this.txtTen.TabIndex = 29;
            this.txtTen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTen_KeyPress);
            // 
            // txtHo
            // 
            this.txtHo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "HO", true));
            this.txtHo.Location = new System.Drawing.Point(402, 47);
            this.txtHo.MenuManager = this.barManager1;
            this.txtHo.Name = "txtHo";
            this.txtHo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtHo.Properties.Appearance.Options.UseFont = true;
            this.txtHo.Size = new System.Drawing.Size(196, 30);
            this.txtHo.TabIndex = 27;
            this.txtHo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHo_KeyPress);
            // 
            // txtMaNV
            // 
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNhanVien, "MANV", true));
            this.txtMaNV.Location = new System.Drawing.Point(176, 43);
            this.txtMaNV.MenuManager = this.barManager1;
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMaNV.Properties.Appearance.Options.UseFont = true;
            this.txtMaNV.Size = new System.Drawing.Size(149, 30);
            this.txtMaNV.TabIndex = 25;
            // 
            // bdsGD_GUIRUT
            // 
            this.bdsGD_GUIRUT.DataMember = "FK_GD_GOIRUT_NhanVien";
            this.bdsGD_GUIRUT.DataSource = this.bdsNhanVien;
            // 
            // gD_GOIRUTTableAdapter
            // 
            this.gD_GOIRUTTableAdapter.ClearBeforeFill = true;
            // 
            // bdsGD_CHUYENTIEN
            // 
            this.bdsGD_CHUYENTIEN.DataMember = "FK_GD_CHUYENTIEN_NhanVien";
            this.bdsGD_CHUYENTIEN.DataSource = this.bdsNhanVien;
            // 
            // gD_CHUYENTIENTableAdapter
            // 
            this.gD_CHUYENTIENTableAdapter.ClearBeforeFill = true;
            // 
            // fillByCmndToolStrip
            // 
            this.fillByCmndToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fillByCmndToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByCmndToolStripButton});
            this.fillByCmndToolStrip.Location = new System.Drawing.Point(0, 382);
            this.fillByCmndToolStrip.Name = "fillByCmndToolStrip";
            this.fillByCmndToolStrip.Size = new System.Drawing.Size(1092, 27);
            this.fillByCmndToolStrip.TabIndex = 32;
            this.fillByCmndToolStrip.Text = "fillByCmndToolStrip";
            // 
            // fillByCmndToolStripButton
            // 
            this.fillByCmndToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByCmndToolStripButton.Name = "fillByCmndToolStripButton";
            this.fillByCmndToolStripButton.Size = new System.Drawing.Size(87, 24);
            this.fillByCmndToolStripButton.Text = "FillByCmnd";
            this.fillByCmndToolStripButton.Click += new System.EventHandler(this.fillByCmndToolStripButton_Click);
            // 
            // frmNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 1038);
            this.Controls.Add(this.fillByCmndToolStrip);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(mACNLabel);
            this.Controls.Add(this.mACNComboBox);
            this.Controls.Add(sODTLabel);
            this.Controls.Add(this.sODTTextEdit);
            this.Controls.Add(pHAILabel);
            this.Controls.Add(this.pHAIComboBox);
            this.Controls.Add(dIACHILabel);
            this.Controls.Add(this.dIACHITextEdit);
            this.Controls.Add(cMNDLabel);
            this.Controls.Add(this.cMNDTextEdit);
            this.Controls.Add(tENLabel);
            this.Controls.Add(this.tENTextEdit);
            this.Controls.Add(hOLabel);
            this.Controls.Add(this.hOTextEdit);
            this.Controls.Add(mANVLabel);
            this.Controls.Add(this.mANVTextEdit);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmNV";
            this.Text = "Quản lý nhân viên";
            this.Load += new System.EventHandler(this.frmNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mANVTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tENTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMNDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dIACHITextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sODTTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbTrangThaiXoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMND.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGD_GUIRUT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGD_CHUYENTIEN)).EndInit();
            this.fillByCmndToolStrip.ResumeLayout(false);
            this.fillByCmndToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnHieuChinh;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnTaiLai;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.BindingSource bdsNhanVien;
        private DS DS;
        private DSTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colPHAI;
        private DevExpress.XtraGrid.Columns.GridColumn colSODT;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThaiXoa;
        private System.Windows.Forms.ComboBox mACNComboBox;
        private DevExpress.XtraEditors.TextEdit sODTTextEdit;
        private System.Windows.Forms.ComboBox pHAIComboBox;
        private DevExpress.XtraEditors.TextEdit dIACHITextEdit;
        private DevExpress.XtraEditors.TextEdit cMNDTextEdit;
        private DevExpress.XtraEditors.TextEdit tENTextEdit;
        private DevExpress.XtraEditors.TextEdit hOTextEdit;
        private DevExpress.XtraEditors.TextEdit mANVTextEdit;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.ComboBox txtChiNhanh;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private System.Windows.Forms.ComboBox cmbGioiTinh;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.TextEdit txtCMND;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtHo;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraBars.BarButtonItem btnChuyenChiNhanh;
        private System.Windows.Forms.BindingSource bdsGD_GUIRUT;
        private DSTableAdapters.GD_GOIRUTTableAdapter gD_GOIRUTTableAdapter;
        private System.Windows.Forms.BindingSource bdsGD_CHUYENTIEN;
        private DSTableAdapters.GD_CHUYENTIENTableAdapter gD_CHUYENTIENTableAdapter;
        private DevExpress.XtraEditors.SpinEdit txbTrangThaiXoa;
        private System.Windows.Forms.ToolStrip fillByCmndToolStrip;
        private System.Windows.Forms.ToolStripButton fillByCmndToolStripButton;
    }
}