using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Trasach : Form
    {
        public Trasach()
        {
            InitializeComponent();
        }
        DatabaseDataContext db = new DatabaseDataContext();

        private void Trasach_Load(object sender, EventArgs e)
        {
            this.Width = Parent.Width;
            this.Height = Parent.Height;

            var listPhieumuontrue = db.Phieumuonsaches
            .Where(p => p.Trangthai == true)
            .Select(p => new
            {
                Maphieumuon = p.Maphieumuon,
                Ngaymuon = p.Ngaymuon,
                Ngayhethan = p.Ngayhethan,
                Ngaytra = p.Ngaytra,
                Trangthai = p.Trangthai,
                SoTienPhat = p.Phieuphat.Sotienphat,
                GhiChu = p.Phieuphat.Ghichu,

             })
            .ToList();

            dataGridViewDanhsachphieutra.DataSource = listPhieumuontrue;

            var listPhieumuonfalse = db.Phieumuonsaches
            .Where(p => p.Trangthai == false)
            .Select(p => new
            {
                Maphieumuon = p.Maphieumuon,
                Ngaymuon = p.Ngaymuon,
                Ngayhethan = p.Ngayhethan,
                Ngaytra = p.Ngaytra,
                Trangthai = p.Trangthai,
                SoTienPhat = p.Phieuphat.Sotienphat,
                GhiChu = p.Phieuphat.Ghichu,

            })
            .ToList();

            dataGridViewThongtinphieumuon.DataSource = listPhieumuonfalse;

            txt_Maphieumuon.ReadOnly =true;
            txt_Ngaymuon.ReadOnly=true;
            txt_Ngayhethan.ReadOnly=true;
            txt_Trangthai.ReadOnly=true;

        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Timkiem.Text != "")
                {

                    var searchResults = from phieumuon in db.Phieumuonsaches
                                        join thedocgia in db.Thedocgias on phieumuon.Mathedocgia equals thedocgia.Mathedocgia
                                        join d1g in db.Docgias on thedocgia.Madocgia equals d1g.Madocgia
                                        where (phieumuon.Trangthai == false && (phieumuon.Maphieumuon == Convert.ToInt32(txt_Timkiem.Text) || (phieumuon.Mathedocgia == Convert.ToInt32(txt_Timkiem.Text))))
                                        select new
                                        {
                                            phieumuon.Maphieumuon,
                                            phieumuon.Ngaymuon,
                                            d1g.Tendocgia,
                                            phieumuon.Ngayhethan,
                                            phieumuon.Ngaytra,
                                            phieumuon.Trangthai,
                                        };


                    dataGridViewThongtinphieumuon.DataSource = searchResults.ToList();


                    if (searchResults.ToList().Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy phiếu mượn có key=" + txt_Timkiem.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin !.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Lỗi: "+ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewThongtinphieumuon_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var crr_row = dataGridViewThongtinphieumuon.Rows[e.RowIndex];

            if (crr_row != null)
            {
                if (crr_row.Cells[0].Value != null)
                {
                    txt_Maphieumuon.Text = crr_row.Cells[0].Value.ToString();
                }
                if (crr_row.Cells[1].Value != null)
                {
                    txt_Ngaymuon.Text = crr_row.Cells[1].Value.ToString();
                }
                if (crr_row.Cells[2].Value != null)
                {
                    txt_Ngayhethan.Text = crr_row.Cells[2].Value.ToString();
                }
                
                if (crr_row.Cells[5].Value != null)
                {
                    txt_Trangthai.Text = crr_row.Cells[5].Value.ToString();
                }
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Maphieumuon.Text == "" || txt_Ngaymuon.Text == "" || txt_Ngayhethan.Text == "" || dtpk_Ngaytra.Text == "" || txt_Trangthai.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    int mp = 0;
                    if (txt_Sotienphat.Text != "" || txt_Ghichu.Text != "")
                    {
                        Phieuphat ppm = new Phieuphat();
                        ppm.Sotienphat = Convert.ToInt32(txt_Sotienphat.Text);
                        ppm.Ghichu = txt_Ghichu.Text;
                        db.Phieuphats.InsertOnSubmit(ppm);
                        db.SubmitChanges();

                        var phieuphatvuathem = db.Phieuphats.OrderByDescending(p => p.Maphieuphat).FirstOrDefault();
                        mp = phieuphatvuathem.Maphieuphat;
                    }

                  
                    int maphieumuon = Convert.ToInt32(txt_Maphieumuon.Text);
                    var editphieumuon = db.Phieumuonsaches.Where(o => o.Maphieumuon == maphieumuon);

                    if (editphieumuon.Any())
                    {
                        var s = editphieumuon.SingleOrDefault();
                        s.Ngaytra = Convert.ToDateTime(dtpk_Ngaytra.Value);
                        s.Trangthai = Convert.ToBoolean("True");

                        if(mp!=0)
                        {
                            s.Maphieuphat = mp;
                        }
                        else
                        {
                            s.Maphieuphat = null;
                        }
                      
                        db.SubmitChanges();
                        

                        var listphieumuon = db.Phieumuonsaches;
                        dataGridViewThongtinphieumuon.DataSource = listphieumuon.ToList();
                        LoadForm();

                        var listPhieumuonfalse = db.Phieumuonsaches
            .Where(p => p.Trangthai == false)
            .Select(p => new
            {
                Maphieumuon = p.Maphieumuon,
                Ngaymuon = p.Ngaymuon,
                Ngayhethan = p.Ngayhethan,
                Ngaytra = p.Ngaytra,
                Trangthai = p.Trangthai,
                SoTienPhat = p.Phieuphat.Sotienphat,
                GhiChu = p.Phieuphat.Ghichu,

            })
            .ToList();

                        dataGridViewThongtinphieumuon.DataSource = listPhieumuonfalse;
                    }

                    MessageBox.Show("Xác nhận phiếu đã hoàn thành thành công!");

                    txt_Ghichu.Text = "";
                    txt_Maphieumuon.Text = "";
                    txt_Ngaymuon.Text = "";
                    txt_Ngayhethan.Text = "";
                    txt_Sotienphat.Text = "";
                    txt_Trangthai.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xác nhận phiếu Không Thành Công!" + ex.Message);
            }
        }

        private void LoadForm()
        {

            dataGridViewThongtinphieumuon.DataSource = null;
            
         
            var listPhieumuon = db.Phieumuonsaches
                .Where(p => p.Trangthai == true)
                .Select(p => new
                {
                    Maphieumuon = p.Maphieumuon,
                    Ngaymuon = p.Ngaymuon,
                    Ngayhethan = p.Ngayhethan,
                    Ngaytra = p.Ngaytra,
                    Trangthai = p.Trangthai,
                    SoTienPhat = p.Phieuphat.Sotienphat,
                    GhiChu = p.Phieuphat.Ghichu,

                })
                .ToList();
            dataGridViewDanhsachphieutra.DataSource = listPhieumuon;


            
        }
    }
}
