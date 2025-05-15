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
    public partial class QLNhanvien : Form
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public QLNhanvien()
        {
            InitializeComponent();
        }

        private void QLNhanvien_Load(object sender, EventArgs e)
        {
            this.Width =Parent.Width;
            this.Height =Parent.Height;
            var listNhanvien = db.Nhanviens;
            dtgv_Nhanvien.DataSource = listNhanvien.ToList();
        }

        private void ReloadData()
        {
            var listNhanvien = db.Nhanviens;
            dtgv_Nhanvien.DataSource = listNhanvien.ToList();
        }
        private void ClearTxtBox()
        {
            txt_Manhanvien.Clear();
            txt_Tennhanvien.Clear();
            txt_Sdtnhanvien.Clear();
            txt_Email.Clear();

        }

        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Tennhanvien.Text == "" || txt_Sdtnhanvien.Text == "" || txt_Email.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int sdtnhanvien;
                if (!int.TryParse(txt_Sdtnhanvien.Text, out sdtnhanvien))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Nhanvien newNhanvien = new Nhanvien
                {
                    Tennhanvien = txt_Tennhanvien.Text,
                    Sdtnhanvien = sdtnhanvien,
                    Email = txt_Email.Text
                };

                db.Nhanviens.InsertOnSubmit(newNhanvien);
                db.SubmitChanges();

                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTxtBox();
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_SuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Manhanvien.Text == "" || txt_Tennhanvien.Text == "" || txt_Sdtnhanvien.Text == "" || txt_Email.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int manhanvien = Convert.ToInt32(txt_Manhanvien.Text);
                var editNhanvien = db.Nhanviens.Where(o => o.Manhanvien == manhanvien);
                int sdtnhanvien;
                if (!int.TryParse(txt_Sdtnhanvien.Text, out sdtnhanvien))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (editNhanvien.Any())
                {
                    var nv = editNhanvien.Single();
                    nv.Tennhanvien = txt_Tennhanvien.Text;
                    nv.Sdtnhanvien = sdtnhanvien;
                    nv.Email = txt_Email.Text;

                    db.SubmitChanges();

                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTxtBox();
                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Manhanvien.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int manhanvien = Convert.ToInt32(txt_Manhanvien.Text);
                var deleteNhanvien = db.Nhanviens.Where(o => o.Manhanvien == manhanvien);

                if (deleteNhanvien.Any())
                {
                    var nv = deleteNhanvien.Single();

                    db.Nhanviens.DeleteOnSubmit(nv);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTxtBox();
                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btn_DatlaiNV_Click(object sender, EventArgs e)
        {
            // Xóa nội dung trong các textbox
            ClearTxtBox();
        }

        private void dtgv_Nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_Nhanvien.Rows[e.RowIndex];

                txt_Manhanvien.Text = row.Cells["Manhanvien"].Value.ToString();
                txt_Tennhanvien.Text = row.Cells["Tennhanvien"].Value.ToString();
                txt_Sdtnhanvien.Text = row.Cells["Sdtnhanvien"].Value.ToString();
                txt_Email.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btn_captk_Click(object sender, EventArgs e)
        {
            if(txt_Manhanvien.Text!="")
            {
                QLtaikhoannv tk = new QLtaikhoannv(Convert.ToInt32(txt_Manhanvien.Text));
                tk.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên bạn muốn cấp mới tài khoản");
            }
        }

        private void btn_qltknv_Click(object sender, EventArgs e)
        {
            QLtaikhoannv tk = new QLtaikhoannv();
            tk.Show();
        }
    }
}
