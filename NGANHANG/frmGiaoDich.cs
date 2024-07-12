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

namespace NGANHANG
{
    public partial class frmGiaoDich : DevExpress.XtraEditors.XtraForm
    {
        int check = 2;
        string loaiGD = "";
        long soDuGoc;
        long soDuChuyen;
        long soDuGR;
        string stk = "";
        private SqlDataReader reader;

  
        static string[] Ones = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        static string[] Tens = { "", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };
        static string[] Teens = { "mười", "mười một", "mười hai", "mười ba", "mười bốn", "mười lăm", "mười sáu", "mười bảy", "mười tám", "mười chín" };

        

        static string NumberToWords(long number)
        {
            if (number == 0)
                return "Không";
            return ConvertToWords(number);
        }

        static string ConvertToWords(long number)
        {
            if (number < 10)
                return Ones[number];
            if (number < 20)
                return Teens[number - 10];
            if (number < 100)
                return Tens[number / 10] + (number % 10 != 0 ? " " + Ones[number % 10] : "");
            if (number < 1000)
                return Ones[number / 100] + " trăm" + (number % 100 != 0 ? " " + ConvertToWords(number % 100) : "");
            if (number < 1000000)
                return ConvertToWords(number / 1000) + " nghìn" + (number % 1000 != 0 ? " " + ConvertToWords(number % 1000) : "");
            if (number < 1000000000)
                return ConvertToWords(number / 1000000) + " triệu" + (number % 1000000 != 0 ? " " + ConvertToWords(number % 1000000) : "");
            if (number < 100000000000)
                return ConvertToWords(number / 1000000000) + " tỷ" + (number % 1000000000 != 0 ? " " + ConvertToWords(number % 1000000000) : "");

            return "";
        }
    



    public frmGiaoDich()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            reader = Program.ExecSqlDataReader($"EXEC SP_KiemTraSTK '{txtSTKNhan.Text.Trim()}'");
            if (reader == null)
                return;

            reader.Read();
            txtHoTenNhan.Text = "Họ tên: " +(string)reader["HOTEN"] ;

            reader.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKT_Click(object sender, EventArgs e)
        {
            reader = Program.ExecSqlDataReader($"EXEC SP_KiemTraSTK '{txbSTK.Text.Trim()}'");
            if (reader == null)
            {
                panelControl2.Enabled = false;
                panelControl3.Enabled = false;
                return;
            }
                
            string hoTen  ="";
            string soDu = "";
            while (reader.Read())
            {
                hoTen = reader["HOTEN"].ToString();
                soDu = reader["SODU"].ToString();
 }
            reader.Close();
            // int result = int.Parse(soDu.Split(',')[0]);
            // int result = Convert.ToInt32(soDu);
            // Console.WriteLine(result);
            string soDuNguyenString = soDu.Split('.')[0];

            // Chuyển đổi phần số nguyên thành kiểu long
            
            if (long.TryParse(soDuNguyenString, out soDuGoc))
            {
                // Chuyển đổi thành công, sử dụng biến soDuLong kiểu long ở đây
                Console.WriteLine(soDuGoc);
            }
            else
            {
                // Xử lý khi không thể chuyển đổi
                Console.WriteLine("Không thể chuyển đổi chuỗi thành số nguyên");
            }

            // string yourString = reader["SODU"].ToString();
            //  reader.Read();
            // txtHoTen.Text = "Họ tên: " + (string)reader["HOTEN"] + " Số dư: " + yourString;
            txtHoTen.Text = "Họ tên: " + hoTen;
            txtSoDu.Text= " Số dư: " + soDu;

            String result = NumberToWords(soDuGoc);
            txtThanhChuGoc.Text = "Thành Chữ: " + result + " đồng.";

            stk = txbSTK.Text.Trim();

            /*reader = Program.ExecSqlDataReader($"EXEC SP_Num2Text '{soDuLong}'");
            if (reader == null)
                return;

            reader.Read();
            txtThanhChuGoc.Text = "Thành Chữ: " + (string)reader["SOTIEN"] + " đồng.";

            reader.Close();*/
            // txtSoTienChuyen.Text = "Thành tiền: " + soDuLong + " đồng.";
            panelControl2.Enabled = true;
            panelControl3.Enabled = true;
            
        }

        private void frmGiaoDich_Load(object sender, EventArgs e)
        {
            panelControl1.Enabled = true;
            panelControl2.Enabled = false;
            panelControl3.Enabled = false;

            if (Program.mGroup == "NGANHANG")
            {
                btnKT.Enabled = false;
                // btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                btnKT.Enabled = true;
                //  btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = true;
            }

            long test = 123456789;
            Console.WriteLine(NumberToWords(test));

        }

        private void btnGuiTien_Click(object sender, EventArgs e)
        {
            if ( txtSoTien.Text.Trim() == "" )
            {    // hàm Trim để xóa khoảng trắng 2 bên.
                MessageBox.Show("Số tiền và loại giao dịch không được bỏ trống", "", MessageBoxButtons.OK);
                return;
            }
            long number = long.Parse(txtSoTien.Text.Trim().ToString());
            if (number < 100000)
            {
                MessageBox.Show("Số tiền phải lớn hơn 100 000", "", MessageBoxButtons.OK);
                return;
            }

            


            loaiGD = "GT";

            string strLenh = "EXEC SP_GUIRUT '" + stk + "','" + txtSoTien.Text + "','" + loaiGD + "','" + Program.username + "'";
            //Debug.WriteLine(strLenh);
            check = Program.ExecSqlNonQuery(strLenh);

            if (check == 0) MessageBox.Show("Giao dịch thành công!!!", "", MessageBoxButtons.OK);
            loaiGD = "";
            check = 2;

        }

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Trim() == "")
            {    // hàm Trim để xóa khoảng trắng 2 bên.
                MessageBox.Show("Số tiền và loại giao dịch không được bỏ trống", "", MessageBoxButtons.OK);
                return;
            }
            long number = long.Parse(txtSoTien.Text.Trim().ToString());
            if(number < 100000)
            {
                MessageBox.Show("Số tiền phải lớn hơn 100 000", "", MessageBoxButtons.OK);
                return;
            }

            if (soDuGR > soDuGoc)
            {
                MessageBox.Show("Số tiền rút lớn hơn tài khoản gốc", "", MessageBoxButtons.OK);
                return;
            }

            loaiGD = "RT";

            string strLenh = "EXEC SP_GUIRUT '" + stk + "','" + txtSoTien.Text + "','" + loaiGD + "','" + Program.username + "'";
            //Debug.WriteLine(strLenh);
            check = Program.ExecSqlNonQuery(strLenh);

            if (check == 0) MessageBox.Show("Giao dịch thành công!!!", "", MessageBoxButtons.OK);
            loaiGD = "";
            check = 2;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txbSTK.Text.Trim() == "" || txtSoTienChuyen.Text.Trim() == "" || txtSTKNhan.Text.Trim() == "")
            {    // hàm Trim để xóa khoảng trắng 2 bên.
                MessageBox.Show("Số tài khoản, số tiền không được bỏ trống!!", "", MessageBoxButtons.OK);
                return;
            }
            
            if (stk == txtSTKNhan.Text.Trim())
            {
                MessageBox.Show("Số tài khoản chuyển và số tài khoản nhận không được trùng nhau!!", "", MessageBoxButtons.OK);
                return;
            }

            try
            {
                reader = Program.ExecSqlDataReader($"EXEC SP_KiemTraSTK '{txtSTKNhan.Text.Trim()}'");
                    if (reader == null)
                        return;

                reader.Read();
                txtHoTenNhan.Text = "Họ tên: " + (string)reader["HOTEN"];

                reader.Close();
            }
            catch(Exception)
            {
                return;
            }

            if (soDuChuyen > soDuGoc)
            {
                MessageBox.Show("Số tiền rút lớn hơn tài khoản gốc", "", MessageBoxButtons.OK);
                return;
            }

            string strLenh = "EXEC SP_CHUYENTIEN '" + stk + "','" + txtSTKNhan.Text + "','" + txtSoTienChuyen.Text + "','" + Program.username + "'";
            //Debug.WriteLine(strLenh);
            check = Program.ExecSqlNonQuery(strLenh);
            if (check == 0) MessageBox.Show("Giao dịch thành công!!!", "", MessageBoxButtons.OK);
            check = 2;
        }

        private void txbSTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txbSTK.Text.Trim().Length > 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
        }

        private void txtSTKNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtSTKNhan.Text.Trim().Length > 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho thêm ký tự nếu đã đạt tới giới hạn
            }
        }

        private void txtSoTienChuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoTienChuyen_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSoTienChuyen.Text))
            {
                return;
            }
            soDuChuyen = long.Parse(txtSoTienChuyen.Text.Trim().ToString());
            String result = NumberToWords(soDuChuyen);
            txtThanhChuChuyen.Text = "Thành Chữ: " + result + " đồng.";
            /*reader = Program.ExecSqlDataReader($"EXEC SP_Num2Text '{soDuLong}'");
            if (reader == null)
                return;

            reader.Read();
            txtThanhChuChuyen.Text = "Thành Chữ: " + (string)reader["SOTIEN"] + " đồng.";

            reader.Close();*/
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                return;
            }
            long soDuGR = long.Parse(txtSoTien.Text.Trim().ToString());
            String result = NumberToWords(soDuGR);
            txtThanhChuGR.Text = "Thành Chữ: " + result + " đồng.";
            /*
            reader = Program.ExecSqlDataReader($"EXEC SP_Num2Text '{soDuLong}'");
            if (reader == null)
                return;

            reader.Read();
            txtThanhChuGR.Text = "Thành Chữ: " + (string)reader["SOTIEN"] + " đồng.";

            reader.Close();
            */
        }
    }
}