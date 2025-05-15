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
    public partial class Muonsach : Form
    {
        public Muonsach()
        {
            InitializeComponent();
        }
        DatabaseDataContext db = new DatabaseDataContext();
        DatabaseDataContext dbPhieuMuon = new DatabaseDataContext();
        DatabaseDataContext dbSachMuon = new DatabaseDataContext();

        private void Muonsach_Load(object sender, EventArgs e)
        {
            Width = Parent.Width;
            Height = Parent.Height;

            var query = from docgia in db.Docgias
                        join thedocgia in db.Thedocgias on docgia.Madocgia equals thedocgia.Madocgia
                        select new
                        {
                            thedocgia.Mathedocgia,
                            docgia.Tendocgia,
                            thedocgia.Ngaycap,
                            thedocgia.Ngayhethan
                        };

            // Gán kết quả cho DataSource của DataGridView
            //dtg_thedocgia.DataSource = query.ToList();

            var queryPM = from phieumuonsach in dbPhieuMuon.Phieumuonsaches
                          where phieumuonsach.Trangthai==false
                          select new
                          {
                              phieumuonsach.Maphieumuon,
                              phieumuonsach.Mathedocgia,
                              phieumuonsach.Ngaymuon,
                              phieumuonsach.Ngayhethan,
                              phieumuonsach.Ngaytra,
                              phieumuonsach.Trangthai
                          } ;
            dtg_phieumuon.DataSource = queryPM.ToList();

            var querySM = from sachmuon in dbSachMuon.Saches
                          select new
                          {
                              sachmuon.Masach,
                              sachmuon.Tensach,
                              sachmuon.Soluongconlai
                          };
            //dgv_sach.DataSource = querySM.ToList();

            checklb_sach.Items.Clear();
            checklb_sach.DisplayMember = "Tensach";
            checklb_sach.ValueMember = "Masach";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_timkiemsach_TextChanged(object sender, EventArgs e)
        {
            if (txt_timkiemsach.Text == "")
            {
                dgv_sach.DataSource = "";
            }
            else
            {
                string serachText = txt_timkiemsach.Text.ToLower();

                var querySM = from sachmuon in dbSachMuon.Saches
                              where sachmuon.Tensach.ToString().Contains(serachText)
                              select new
                              {
                                  sachmuon.Masach,
                                  sachmuon.Tensach,
                                  sachmuon.Soluongconlai
                              };
                dgv_sach.DataSource = querySM.ToList();
            }
        }

        private void txt_thedocgia_TextChanged(object sender, EventArgs e)
        {
            string searchText = txt_thedocgia.Text.ToLower();

            var query = from docgia in db.Docgias
                        join thedocgia in db.Thedocgias on docgia.Madocgia equals thedocgia.Madocgia
                        where (docgia.Tendocgia.ToLower().Contains(searchText) || thedocgia.Mathedocgia.ToString().Contains(searchText))
                        select new
                        {
                            thedocgia.Mathedocgia,
                            docgia.Tendocgia,
                            thedocgia.Ngaycap,
                            thedocgia.Ngayhethan
                        };

            dtg_thedocgia.DataSource = query.ToList();
        }

        private void txt_kiemtraphieumuon_TextChanged(object sender, EventArgs e)
        {
            string searchText = txt_kiemtraphieumuon.Text.ToLower();

            var queryPM = from phieumuonsach in dbPhieuMuon.Phieumuonsaches
                          where (phieumuonsach.Mathedocgia.ToString().Contains(searchText)) && phieumuonsach.Trangthai==false
                          select new
                          {
                              phieumuonsach.Maphieumuon,
                              phieumuonsach.Mathedocgia,
                              phieumuonsach.Ngaymuon,
                              phieumuonsach.Ngayhethan,
                              phieumuonsach.Ngaytra,
                              phieumuonsach.Trangthai
                          };
            dtg_phieumuon.DataSource = queryPM.ToList();
        }

        private void dgv_sach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_sach.Rows.Count)
            {
                // Lấy giá trị từ cột "TenSach"
                object tenSachValue = dgv_sach.Rows[e.RowIndex].Cells["Tensach"].Value;
                object maSachValue = dgv_sach.Rows[e.RowIndex].Cells["Masach"].Value;

                if (tenSachValue != null && tenSachValue != DBNull.Value) // Kiểm tra nếu giá trị không phải là null
                {
                    string tenSach = tenSachValue.ToString();
                    string maSach = maSachValue.ToString();
                    Sach news = new Sach();
                    news.Masach = Convert.ToInt32(maSach);
                    news.Tensach = tenSach;
                    // Kiểm tra xem giá trị đã tồn tại trong CheckListBox chưa
                    bool containsItem = false;

                    foreach (Sach existingItem in checklb_sach.Items)
                    {
                        if (existingItem.Masach == news.Masach && existingItem.Tensach == news.Tensach)
                        {
                            containsItem = true;
                            break;
                        }
                    }

                    if (!containsItem)
                    {
                        // Thêm thông tin vào CheckListBox nếu chưa tồn tại

                        checklb_sach.Items.Add(news);

                    }
                    else
                    {
                        MessageBox.Show("Cuốn sách này đã có trong list sách mượn");
                    }

                    // Hiển thị CheckListBox khi có dữ liệu được chọn
                    checklb_sach.Visible = true;
                }
                else
                {
                    // Ẩn CheckListBox khi không có dữ liệu được chọn
                    checklb_sach.Visible = false;

                }
            }
            // dgv_sach.CellClick += dgv_sach_CellContentClick;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            for (int i = checklb_sach.CheckedItems.Count - 1; i >= 0; i--)
            {
                checklb_sach.Items.Remove(checklb_sach.CheckedItems[i]);
            }
        }

        private void dtg_thedocgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var crr_row = dtg_thedocgia.Rows[e.RowIndex];

            if (crr_row != null)
            {
                if (crr_row.Cells[0].Value != null)
                {
                    txt_Mathe.Text = crr_row.Cells[0].Value.ToString();
                }
            }
        }

        private void btn_lapphieumuon_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Mathe.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn thẻ độc giả!");
                }
                else
                {
                    Phieumuonsach pmm = new Phieumuonsach();
                    pmm.Mathedocgia = Convert.ToInt16(txt_Mathe.Text);
                    pmm.Ngaymuon = dtp_Ngaymuon.Value;
                    pmm.Ngayhethan = dtp_Ngayhethan.Value;
                    pmm.Trangthai = false;
                    pmm.Ngaytra = null;

                    db.Phieumuonsaches.InsertOnSubmit(pmm);
                    db.SubmitChanges();

                    var sachvuathem = db.Phieumuonsaches.OrderByDescending(p => p.Maphieumuon).FirstOrDefault();
                    int masachvuathem = sachvuathem.Maphieumuon;

                    foreach (var sach in checklb_sach.Items)
                    {
                        Sach sach1 = (Sach)sach;

                        Phieumuonsach_sach pms_s = new Phieumuonsach_sach();
                        pms_s.Maphieumuon = masachvuathem;
                        pms_s.Masach = sach1.Masach;
                        db.Phieumuonsach_saches.InsertOnSubmit(pms_s); db.SubmitChanges();
                    }

                    MessageBox.Show("Thêm phiếu mượn mới thành công");

                    var queryPM = from phieumuonsach in dbPhieuMuon.Phieumuonsaches
                                  where phieumuonsach.Trangthai == false
                                  select new
                                  {
                                      phieumuonsach.Maphieumuon,
                                      phieumuonsach.Mathedocgia,
                                      phieumuonsach.Ngaymuon,
                                      phieumuonsach.Ngayhethan,
                                      phieumuonsach.Ngaytra,
                                      phieumuonsach.Trangthai
                                  };
                    dtg_phieumuon.DataSource = queryPM.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void dtg_phieumuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var crr_row = dtg_phieumuon.Rows[e.RowIndex];

            if (crr_row != null)
            {
                int maphieumuon = Convert.ToInt32(crr_row.Cells[0].Value.ToString());
                if (crr_row.Cells[1].Value != null)
                {
                    txt_Mathe.Text = crr_row.Cells[1].Value.ToString();

                }
                if (crr_row.Cells[2].Value != null)
                {
                    dtp_Ngaymuon.Value= Convert.ToDateTime(crr_row.Cells[2].Value);

                }
                if (crr_row.Cells[3].Value != null)
                {
                    dtp_Ngayhethan.Value = Convert.ToDateTime(crr_row.Cells[3].Value);

                }
                checklb_sach.Items.Clear();

                var pms_sclick = db.Phieumuonsach_saches.Where(o => o.Maphieumuon==maphieumuon).ToList();
                foreach(var pms in pms_sclick)
                {
                    int Masach = Convert.ToInt32(pms.Masach);

                    var sach = db.Saches.Where(o => o.Masach == Masach).FirstOrDefault();
                    Sach sc = new Sach();
                    sc.Tensach = sach.Tensach; sc.Masach = sach.Masach;

                    checklb_sach.Items.Add(sc);
                }    




            }

            
        }
    }
}

