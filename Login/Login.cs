using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        DatabaseDataContext db = new DatabaseDataContext();
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {

            string taikhoan = txt_taikhoan.Text;
            string matkhau = txt_matkhau.Text;

            if (string.IsNullOrEmpty(taikhoan) || string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui lòng nhập đủ tài khoản mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var tkmk = db.Taikhoans.Where(o => o.Tendangnhap == taikhoan && o.Matkhau == matkhau).ToList();
                if (tkmk.Count>0)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                    Trangchu F1 = new Trangchu(txt_taikhoan.Text);
                    F1.Width = 1300;
                    F1.Height=740;
                    F1.Show();
              
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ck_matkhau_CheckedChanged(object sender, EventArgs e)
        {

            if (ck_matkhau.Checked)
            {
                txt_matkhau.PasswordChar = '\0';
            }
            else
            {
                txt_matkhau.PasswordChar = '*';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_matkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_taikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
