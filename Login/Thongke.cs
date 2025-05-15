using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Login
{
    public partial class Thongke : Form
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public Thongke()
        {
            InitializeComponent();
        }

        private void btn_Thongke_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpk_Tungay.Value;
            DateTime denNgay = dtpk_Denngay.Value;
            if (cbx_Thongke.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (denNgay > tuNgay)
            {
                switch (cbx_Thongke.SelectedIndex)
                {
              
                    case 0: // Thống kê sách đã mượn
                        if (dtgv_Thongke.Visible == true || chart_Doanhthu.Visible == true)
                        {
                            dtgv_Thongke.Visible = false;
                            chart_Doanhthu.Visible = false;
                        }

                        var sachDaMuon = from pms in db.Phieumuonsaches
                                         join pmss in db.Phieumuonsach_saches on pms.Maphieumuon equals pmss.Maphieumuon
                                         join s in db.Saches on pmss.Masach equals s.Masach
                                         where pms.Ngaymuon >= tuNgay && pms.Ngaymuon <= denNgay
                                         select new { s.Masach, s.Tensach };
                        dtgv_Thongke.DataSource = sachDaMuon.Distinct().ToList();
                        dtgv_Thongke.Visible = true;
                        break;
                    case 1: // Thống kê sách được mượn nhiều nhất
                        if (dtgv_Thongke.Visible == true || chart_Doanhthu.Visible == true)
                        {
                            dtgv_Thongke.Visible = false;
                            chart_Doanhthu.Visible = false;
                        }
                        var sachMuonNhieuNhat = from pms in db.Phieumuonsaches
                                                join pmss in db.Phieumuonsach_saches on pms.Maphieumuon equals pmss.Maphieumuon
                                                join s in db.Saches on pmss.Masach equals s.Masach
                                                where pms.Ngaymuon >= tuNgay && pms.Ngaymuon <= denNgay
                                                group s by new { s.Masach, s.Tensach } into g
                                                orderby g.Count() descending
                                                select new { g.Key.Masach, g.Key.Tensach, SoLanMuon = g.Count() };
                        dtgv_Thongke.DataSource = sachMuonNhieuNhat.Take(3).ToList();
                        dtgv_Thongke.Visible = true;
                        break;
                    case 2: // Thống kê sách được mượn ít nhất
                        if (dtgv_Thongke.Visible == true || chart_Doanhthu.Visible == true)
                        {
                            dtgv_Thongke.Visible = false;
                            chart_Doanhthu.Visible = false;
                        }
                        var sachMuonItNhat = from s in db.Saches
                                             join pmss in db.Phieumuonsach_saches on s.Masach equals pmss.Masach into pmssGroup
                                             from pmss in pmssGroup.DefaultIfEmpty()
                                             group pmss by new { s.Masach, s.Tensach } into g
                                             orderby g.Count(x => x != null) ascending
                                             select new { g.Key.Masach, g.Key.Tensach, SoLanMuon = g.Count(x => x != null) };
                        dtgv_Thongke.DataSource = sachMuonItNhat.Take(3).ToList();
                        dtgv_Thongke.Visible = true;
                        break;


                    case 3: // Thống kê sách trễ hạn
                        if (dtgv_Thongke.Visible == true || chart_Doanhthu.Visible == true)
                        {
                            dtgv_Thongke.Visible = false;
                            chart_Doanhthu.Visible = false;
                        }
                        var sachTreHan = from s in db.Saches
                                         join pmss in db.Phieumuonsach_saches on s.Masach equals pmss.Masach
                                         join pms in db.Phieumuonsaches on pmss.Maphieumuon equals pms.Maphieumuon
                                         join tdg in db.Thedocgias on pms.Mathedocgia equals tdg.Mathedocgia
                                         join dg in db.Docgias on tdg.Madocgia equals dg.Madocgia
                                         where pms.Ngaytra > pms.Ngayhethan
                                         orderby pms.Ngaytra descending
                                         select new { s.Masach, s.Tensach, pms.Ngayhethan, pms.Ngaytra, pms.Maphieumuon, dg.Tendocgia };
                        //dtgv_Thongke.DataSource = sachTreHan.Take(3).ToList();
                        dtgv_Thongke.DataSource = sachTreHan.ToList();

                        dtgv_Thongke.Visible = true;
                        break;

                    case 4: // Thống kê người mượn nhiều nhất
                        if (dtgv_Thongke.Visible == true || chart_Doanhthu.Visible == true)
                        {
                            dtgv_Thongke.Visible = false;
                            chart_Doanhthu.Visible = false;
                        }
                        var nguoiMuonNhieuNhat = from pms in db.Phieumuonsaches
                                                 join tdg in db.Thedocgias on pms.Mathedocgia equals tdg.Mathedocgia
                                                 join dg in db.Docgias on tdg.Madocgia equals dg.Madocgia
                                                 where pms.Ngaymuon >= tuNgay && pms.Ngaymuon <= denNgay
                                                 group dg by new { dg.Madocgia, dg.Tendocgia } into g
                                                 orderby g.Count() descending
                                                 select new { g.Key.Madocgia, g.Key.Tendocgia, SoLanMuon = g.Count() };
                        dtgv_Thongke.DataSource = nguoiMuonNhieuNhat.Take(3).ToList();
                        dtgv_Thongke.Visible = true;
                        break;
                    case 5: // Thống kê doanh thu
                        if (dtgv_Thongke.Visible == true || chart_Doanhthu.Visible == true)
                        {
                            dtgv_Thongke.Visible = false;
                            chart_Doanhthu.Visible = false;
                        }
                        var doanhThu = from pms in db.Phieumuonsaches
                                       join pmss in db.Phieumuonsach_saches on pms.Maphieumuon equals pmss.Maphieumuon
                                       join s in db.Saches on pmss.Masach equals s.Masach
                                       where pms.Ngaytra >= tuNgay && pms.Ngaytra <= denNgay && pms.Trangthai == true
                                       group new { pms, s } by pms.Ngaytra into g
                                       let tienPhat = (from pp in db.Phieuphats
                                                       join pm in db.Phieumuonsaches on pp.Maphieuphat equals pm.Maphieuphat
                                                       where pm.Ngaytra == g.Key
                                                       select pp.Sotienphat).Sum() ?? 0
                                       select new
                                       {
                                           Ngay = g.Key,
                                           TienThueSach = g.Sum(x => x.s.Giathue),
                                           TienPhat = tienPhat,
                                           TongDoanhThu = g.Sum(x => x.s.Giathue) + tienPhat
                                       };

                        // Tạo mảng ngayCoDoanhThu và doanhThuValues
                        List<DateTime> ngayCoDoanhThu = new List<DateTime>();
                        List<decimal> doanhThuValues = new List<decimal>();
                        foreach (var item in doanhThu)
                        {
                            if (item.Ngay.HasValue)
                            {
                                ngayCoDoanhThu.Add(item.Ngay.Value);
                            }
                            doanhThuValues.Add(Convert.ToDecimal(item.TongDoanhThu));
                        }


                        chart_Doanhthu.Series.Clear();
                        var series = new Series("Doanh thu");
                        series.ChartType = SeriesChartType.Column; // Sử dụng biểu đồ cột
                        series.IsValueShownAsLabel = true; // Hiển thị giá trị của mỗi điểm dữ liệu


                        // Sử dụng chỉ số mảng làm trục X
                        for (int i = 0; i < ngayCoDoanhThu.Count; i++)
                        {
                            // Thêm chỉ số của mảng ngayCoDoanhThu làm trục X, và giá trị doanh thu tương ứng
                            series.Points.AddXY(i, doanhThuValues[i]);
                            // Đặt nhãn cho mỗi điểm dữ liệu trên trục X
                            series.Points[i].AxisLabel = ngayCoDoanhThu[i].ToString("dd/MM/yyyy");
                        }


                        chart_Doanhthu.ChartAreas[0].AxisX.Interval = 1; // Đặt khoảng cách giữa các điểm dữ liệu là 1 (hiển thị tất cả)

                        chart_Doanhthu.Series.Add(series);
                        chart_Doanhthu.Visible = true;
                        break;
                }
            
            }
            else
            {
                MessageBox.Show("Lỗi: Ngày kết thúc phải sau ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        
    }

        private void dtgv_Thongke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpk_Denngay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpk_Tungay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbx_Thongke_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Thongke_Load(object sender, EventArgs e)
        {
            this.Width = Parent.Width;
            this.Height = Parent.Height;
        }
    }
}
