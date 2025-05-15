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
    public partial class QLsach : Form
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public QLsach()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void QLsach_Load(object sender, EventArgs e)
        {
            this.Width = Parent.Width;
            this.Height = Parent.Height;

            var listsach = db.Saches;
            dtgv_Sach.DataSource = listsach.ToList();


            var listtheloai = db.Theloaisaches;
            cklb_Theloai.Items.Clear();
            cklb_Theloai.DataSource = listtheloai.ToList();
            cklb_Theloai.DisplayMember = "Tentheloai";
            cklb_Theloai.ValueMember = "Matheloai";

        }

        private void Themsach_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Tensach.Text == "" || txt_Nhaxuatban.Text==""|| txt_Namxuatban.Text==""||txt_Soluong.Text==""|| txt_Giathue.Text==""||cklb_Theloai.CheckedItems.Count==0 || txt_Soluongconlai.Text=="")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báp",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    Sach newsach = new Sach();
                    newsach.Tensach = txt_Tensach.Text;
                    newsach.Nhaxuatban = txt_Nhaxuatban.Text;
                    newsach.Namxuatban = Convert.ToInt32(txt_Namxuatban.Text);
                    newsach.Soluong = Convert.ToInt32(txt_Soluong.Text);
                    newsach.Giathue = Convert.ToInt32(txt_Giathue.Text);
                    newsach.Soluongconlai = Convert.ToInt32(txt_Soluongconlai.Text);
                    db.Saches.InsertOnSubmit(newsach);
                    db.SubmitChanges();

                    var maxmasach = db.Saches.OrderByDescending(o => o.Masach).First();

                
                    foreach(var tl in cklb_Theloai.CheckedItems)
                    {
                        var Theloai = (Theloaisach)tl;
                        Sach_Theloaisach newsach_tl = new Sach_Theloaisach();
                        newsach_tl.Masach = maxmasach.Masach;
                        newsach_tl.Matheloai = Theloai.Matheloai;
                        db.Sach_Theloaisaches.InsertOnSubmit(newsach_tl);
                        db.SubmitChanges();
                    }

                    MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var listsach = db.Saches;
                    dtgv_Sach.DataSource = listsach.ToList();
                    clear();

                   
                }
            } 
            catch(Exception ex)
            {
                if (db.GetChangeSet().Inserts.Count > 0)
                {
                    foreach (Sach item in db.GetChangeSet().Inserts)
                    {
                        db.Saches.DeleteOnSubmit(item);
                    }
                }
                MessageBox.Show("Thêm Sách Không Thành Công, Lỗi: "+ex.Message);
            }
        }

        private void clear()
        {
            txt_Tensach.Text = "";
            txt_Nhaxuatban.Text = "";
            txt_Namxuatban.Text = "";
            txt_Giathue.Text = "";
            txt_Soluong.Text = "";
            txt_Soluongconlai.Text = "";
            for (int i = 0; i < cklb_Theloai.Items.Count; i++)
            {
                cklb_Theloai.SetItemChecked(i, false);
            }
        }

        private void btn_Suasach_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Masach.Text == "" || txt_Tensach.Text == "" || txt_Nhaxuatban.Text == "" || txt_Namxuatban.Text == "" || txt_Soluong.Text == "" || txt_Giathue.Text == "" || txt_Soluongconlai.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    int masach = Convert.ToInt32(txt_Masach.Text);
                    var editsach = db.Saches.Where(o => o.Masach == masach);

                    if (editsach.Any())
                    {
                        var s = editsach.SingleOrDefault();
                        //gán dữ liệu cho đối tượng sv mới tạo ra

                        s.Tensach = txt_Tensach.Text;
                        s.Nhaxuatban = txt_Nhaxuatban.Text;
                        s.Namxuatban = Convert.ToInt32(txt_Namxuatban.Text);
                        s.Soluong = Convert.ToInt32(txt_Soluong.Text);
                        s.Giathue = Convert.ToInt32(txt_Giathue.Text);
                        s.Soluongconlai = Convert.ToInt32(txt_Soluongconlai.Text);
                        //thực thi lệnh
                        db.SubmitChanges();
                        MessageBox.Show("Cập nhật sách thành công", "Thông báp", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var listsach = db.Saches;
                        dtgv_Sach.DataSource = listsach.ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật sách Không Thành Công, Lỗi: " + ex.Message);
            }
        }

        private void dtgv_Sach_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var crr_row = dtgv_Sach.Rows[e.RowIndex];

            if (crr_row != null)
            {
                string Masach = "";
                string Tensach = "";
                string NhaXB = "";
                string Namxuatban = "";
                string Giathue = "";
                string Soluong = "";
                string Soluongconlai = "";

                if (crr_row.Cells[0].Value != null)
                {
                    Masach = crr_row.Cells[0].Value.ToString();
                }
                if (crr_row.Cells[1].Value != null)
                {
                    Tensach = crr_row.Cells[1].Value.ToString();
                }
                if (crr_row.Cells[2].Value != null)
                {
                    NhaXB = crr_row.Cells[2].Value.ToString();
                }
                if (crr_row.Cells[3].Value != null)
                {
                     Giathue = crr_row.Cells[3].Value.ToString();
                }
                if (crr_row.Cells[4].Value != null)
                {
                    Namxuatban = crr_row.Cells[4].Value.ToString();
                }

                if (crr_row.Cells[5].Value != null)
                {
                    Soluong = crr_row.Cells[5].Value.ToString();
                }
                if (crr_row.Cells[6].Value != null)
                {
                    Soluongconlai = crr_row.Cells[5].Value.ToString();
                }


                txt_Tensach.Text = Tensach;
                txt_Nhaxuatban.Text = NhaXB;
                txt_Namxuatban.Text = Namxuatban;
                txt_Giathue.Text = Giathue;
                txt_Soluong.Text = Soluong;
                txt_Soluongconlai.Text=Soluongconlai;
                txt_Masach.Text = Masach;
            }
        }

        private void btn_Xoasach_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Masach.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn bản ghi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    int masach = Convert.ToInt32(txt_Masach.Text);


                    var deletes_tl = db.Sach_Theloaisaches.Where(o => o.Masach == masach);
                    db.Sach_Theloaisaches.DeleteAllOnSubmit(deletes_tl);
                    db.SubmitChanges();

                    var deletesach = db.Saches.Where(o => o.Masach == masach);

                         
                    if (deletesach.Any())
                    {
                        var s = deletesach.SingleOrDefault();
                        //tạo lệnh xóa
                        db.Saches.DeleteOnSubmit(s);
                        //thực thi lệnh
                        db.SubmitChanges();
                        MessageBox.Show("Xóa sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var listsach = db.Saches;
                        dtgv_Sach.DataSource = listsach.ToList();

                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sách Không Thành Công, Lỗi: " + ex.Message);
            }
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_Timkiem.Text=="")
                {
                    MessageBox.Show("Vui lòng nhập thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string key = txt_Timkiem.Text;
                    bool containsLetter = key.Any(char.IsLetter);

                    if (containsLetter)
                    {
                        var tk = db.Saches.Where(o=>o.Tensach.Contains(key) || o.Nhaxuatban.Contains(key));
                        dtgv_Sach.DataSource = tk.ToList();
                    }

                    else
                    {
                        var tk = db.Saches.Where(o => o.Masach == Convert.ToInt32(key) || o.Namxuatban == Convert.ToInt32(key));
                        dtgv_Sach.DataSource = tk.ToList();
                    }




                    
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Tìm kiếm thất bại, Lỗi" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            clear();
            var listsach = db.Saches;
            dtgv_Sach.DataSource = listsach.ToList();
        }
    }
}
