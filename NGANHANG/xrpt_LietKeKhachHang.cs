using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class xrpt_LietKeKhachHang : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_LietKeKhachHang()
        {
            InitializeComponent();
        }
        public xrpt_LietKeKhachHang(String loai, String MaCN)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = MaCN;
            this.sqlDataSource1.Fill();
        }

    }
}
