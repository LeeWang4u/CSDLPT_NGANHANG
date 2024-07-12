using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class xrpt_LietKeTaiKhoan : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_LietKeTaiKhoan()
        {
            InitializeComponent();
        }
        public xrpt_LietKeTaiKhoan(DateTime dateFrom, DateTime dateTo, String loai, String MaCN)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = dateFrom;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = dateTo;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = MaCN;
            this.sqlDataSource1.Fill();
        }
    }
}
