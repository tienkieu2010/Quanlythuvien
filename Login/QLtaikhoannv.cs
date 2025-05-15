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
    public partial class QLtaikhoannv : Form
    {
        int manvm=0;
        public QLtaikhoannv()
        {
            InitializeComponent();
        }

        public QLtaikhoannv(int manv)
        {
            InitializeComponent();
            manvm = manv;
        }

        DatabaseDataContext db = new DatabaseDataContext();

        private void QLtaikhoannv_Load(object sender, EventArgs e)
        {
            dtgv_tk.DataSource = db.Taikhoans
            .Select(p => new
            {
                Tendangnhap = p.Tendangnhap,
                Matkhau = p.Matkhau,
                Quyen = p.Quyen,
                Manhanvien = p.Manhanvien
            })
            .ToList();

            if(manvm!=0)
            {
                txt_Manhanvien.Text = manvm.ToString();
                txt_Manhanvien.ReadOnly = true;
            }    

        }

        private void Themtk_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Manhanvien.Text == "" || txt_Tendangnhap.Text == "" || txt_Matkhau.Text == "" || cbb_Quyen.SelectedItem == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    Taikhoan newtk = new Taikhoan();
                    newtk.Tendangnhap = txt_Tendangnhap.Text;
                    newtk.Manhanvien = Convert.ToInt32(txt_Manhanvien.Text);
                    newtk.Matkhau = txt_Matkhau.Text;
                    newtk.Quyen = Convert.ToInt32(cbb_Quyen.Text);

                    db.Taikhoans.InsertOnSubmit(newtk);
                    db.SubmitChanges();
                    QLtaikhoannv_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm tài khoản k thành công, Lỗi: " + ex.Message);
            }
        }

        private void Suatk_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Manhanvien.Text == "" || txt_Tendangnhap.Text == "" || txt_Matkhau.Text == "" || cbb_Quyen.SelectedItem != "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    Taikhoan capnhattk = new Taikhoan();
                   
                    capnhattk.Manhanvien = Convert.ToInt32(txt_Manhanvien.Text);
                    capnhattk.Matkhau = txt_Matkhau.Text;
                    capnhattk.Quyen = Convert.ToInt32(cbb_Quyen.Text);

                    db.SubmitChanges();
                    QLtaikhoannv_Load(sender, e);
                    MessageBox.Show("Cập nhật tài khoản thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật tài khoản k thành công, Lỗi: " + ex.Message);
            }
        }

        private void Xoatk_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Tendangnhap.Text != "")
                {
                    var tk = db.Taikhoans.Where(o => o.Tendangnhap == txt_Tendangnhap.Text).FirstOrDefault();
                    db.Taikhoans.DeleteOnSubmit(tk);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa tài khoản k thành công, Lỗi: " + ex.Message);
            }
        }

        private void dtgv_tk_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var crr_row = dtgv_tk.Rows[e.RowIndex];

            if (crr_row != null)
            {

                if (crr_row.Cells[0].Value != null)
                {
                    txt_Tendangnhap.Text = crr_row.Cells[0].Value.ToString();
                }
                if (crr_row.Cells[1].Value != null)
                {
                    txt_Matkhau.Text = crr_row.Cells[1].Value.ToString();
                }
                if (crr_row.Cells[2].Value != null)
                {
                    cbb_Quyen.Text = crr_row.Cells[2].Value.ToString();
                }
                if (crr_row.Cells[3].Value != null)
                {
                    txt_Manhanvien.Text = crr_row.Cells[3].Value.ToString();
                }
            }
        }
    }
}
