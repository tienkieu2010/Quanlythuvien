using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login
{
    public partial class Trangchu : Form
    {
        string taikhoan;
        DatabaseDataContext db = new DatabaseDataContext();
        public Trangchu()
        {
            InitializeComponent();
        }

        private void btn_muonsach_Click(object sender, EventArgs e)
        {
            Muonsach s = new Muonsach();
            s.TopLevel = false;
            panel_trangchu.Controls.Clear(); 
            panel_trangchu.Controls.Add(s); 
            s.Show();
        }
        public Trangchu(string giatrinhan) : this()
        {
            taikhoan = giatrinhan;
        }

        private void panel_trangchu_Resize(object sender, EventArgs e)
        {
            if (panel_trangchu.Controls.Count != 0) 
            {
                var sub_ctrl = panel_trangchu.Controls[0];
                sub_ctrl.Width = panel_trangchu.Width;
                sub_ctrl.Height = panel_trangchu.Height;
            }
        }

        private void btn_sach_Click(object sender, EventArgs e)
        {
            QLsach s = new QLsach();
            s.TopLevel = false;
            panel_trangchu.Controls.Clear(); 
            panel_trangchu.Controls.Add(s); 
            s.Show();
        }

        private void btn_trasach_Click(object sender, EventArgs e)
        {
            Trasach s = new Trasach();
            s.TopLevel = false;
            panel_trangchu.Controls.Clear(); 
            panel_trangchu.Controls.Add(s);
            s.Show();
        }

        private void Trangchu_Load(object sender, EventArgs e)
        {
            lbl_Welcome.Text = "Welcome," + taikhoan;

            var quyen = db.Taikhoans.Where(o => o.Tendangnhap == taikhoan).First();
            if(quyen.Quyen==1)
            {
                nhanvien_btn.Visible = true;
            }
            else
            {
                nhanvien_btn.Visible = false;
            }

        }

        public void addform(Form m)
        {
            m.TopLevel = false;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(m);
            m.Show();
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void nhanvien_btn_Click(object sender, EventArgs e)
        {
            QLNhanvien s = new QLNhanvien();
            s.TopLevel = false;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(s); 
            s.Show();
        }

        private void btn_dangkithanhvien_Click(object sender, EventArgs e)
        {
            QLdocgia nv = new QLdocgia(this);
            nv.TopLevel = false;
            panel_trangchu.Controls.Clear(); 
            panel_trangchu.Controls.Add(nv); 
            nv.Show();
        }

        private void btn_thedocgia_Click(object sender, EventArgs e)
        {
            Thehoivien nv = new Thehoivien();
            nv.TopLevel = false;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(nv);
            nv.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Thongke nv = new Thongke();
            nv.TopLevel = false;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(nv);
            nv.Show();
        }
    }
}
