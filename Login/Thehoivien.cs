using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{

    public partial class Thehoivien : Form
    {
        string madocgia;
        private SqlConnection connection;
        private string connectionString = "Data Source=DESKTOP-LRS7A72\\SQLEXPRESS;Initial Catalog=qlthuvien2;Integrated Security=True"; // Thay YOUR_CONNECTION_STRING bằng chuỗi kết nối của bạn

        public Thehoivien()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);

            
        }

        public Thehoivien(string madgia)
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            madocgia = madgia;
        }

        private void LoadData()
        {
            // Load dữ liệu từ database và hiển thị trên DataGridView
            string query = "SELECT Thedocgia.Mathedocgia, Docgia.Madocgia,Docgia.Tendocgia, Thedocgia.Ngaycap, Thedocgia.Ngayhethan " +
                           "FROM Thedocgia INNER JOIN Docgia ON Thedocgia.Madocgia = Docgia.Madocgia";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dtgv_Thedocgia.DataSource = table;
        }

        private void Thehoivien_Load(object sender, EventArgs e)
        {
            this.Width = Parent.Width;
            this.Height = Parent.Height;
            LoadData();

            if(madocgia!="")
            {
                txt_Madocgia.Text = madocgia;
                txt_Madocgia.ReadOnly = true;
            }    
        }

        private void btn_Capmoithe_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox và DateTimePicker
                string madocgia = txt_Madocgia.Text;
                DateTime ngaycap = dtp_Ngaycap.Value;
                DateTime ngayhethan = dtp_Ngayhethan.Value;


                // Thực hiện thêm dữ liệu vào bảng Thedocgia
                string insertThedocgiaQuery = "INSERT INTO Thedocgia (Ngaycap, Ngayhethan, Madocgia) " +
                                              "VALUES (@Ngaycap, @Ngayhethan, @Madocgia)";
                using (SqlCommand command = new SqlCommand(insertThedocgiaQuery, connection))
                {
                    command.Parameters.AddWithValue("@Ngaycap", ngaycap);
                    command.Parameters.AddWithValue("@Ngayhethan", ngayhethan);
                    command.Parameters.AddWithValue("@Madocgia", madocgia);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Cấp mới thẻ độc giả thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);

                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cấp mới thẻ không thành công, Lỗi:" + ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            int mathedocgia;

            // Kiểm tra xem người dùng đã nhập Mathedocgia hay chưa
            if (!int.TryParse(txt_Mathedocgia.Text, out mathedocgia))
            {
                MessageBox.Show("Vui lòng nhập một giá trị số nguyên cho Mathedocgia.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện truy vấn tìm kiếm theo Mathedocgia
            string searchQuery = "SELECT Thedocgia.Mathedocgia, Docgia.Tendocgia, Thedocgia.Ngaycap, Thedocgia.Ngayhethan " +
                                 "FROM Thedocgia INNER JOIN Docgia ON Thedocgia.Madocgia = Docgia.Madocgia " +
                                 "WHERE Thedocgia.Mathedocgia = @Mathedocgia";

            using (SqlCommand command = new SqlCommand(searchQuery, connection))
            {
                command.Parameters.AddWithValue("@Mathedocgia", mathedocgia);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dtgv_Thedocgia.DataSource = table;
            }
        }
        private int selectedMathedocgia = -1; // Add this variable to store the selected Mathedocgia

        private void dtgv_Thedocgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_Thedocgia.Rows[e.RowIndex];

                // Store the selected Mathedocgia
                selectedMathedocgia = Convert.ToInt32(row.Cells["Mathedocgia"].Value);

                // Display information in textboxes and DateTimePickers
                txt_Madocgia.Text = row.Cells["Madocgia"].Value.ToString();
                dtp_Ngaycap.Value = Convert.ToDateTime(row.Cells["Ngaycap"].Value);
                dtp_Ngayhethan.Value = Convert.ToDateTime(row.Cells["Ngayhethan"].Value);
            }
        }

        private void btn_Caplaithe_Click(object sender, EventArgs e)
        {
            if (selectedMathedocgia != -1)
            {

                DateTime ngaycap = dtp_Ngaycap.Value;
                DateTime ngayhethan = dtp_Ngayhethan.Value;



                // Thực hiện cập nhật dữ liệu trong bảng Thedocgia
                string updateThedocgiaQuery = "UPDATE Thedocgia SET Ngaycap = @Ngaycap, Ngayhethan = @Ngayhethan WHERE Mathedocgia = @Mathedocgia";
                using (SqlCommand command = new SqlCommand(updateThedocgiaQuery, connection))
                {
                    command.Parameters.AddWithValue("@Ngaycap", ngaycap);
                    command.Parameters.AddWithValue("@Ngayhethan", ngayhethan);
                    command.Parameters.AddWithValue("@Mathedocgia", selectedMathedocgia);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                LoadData();
                ClearInputs();
                MessageBox.Show("Cấp lại thẻ thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thẻ để cấp lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInputs()
        {
            // Clear textboxes and DateTimePickers
            txt_Madocgia.Text = string.Empty;
            dtp_Ngaycap.Value = DateTime.Now;
            dtp_Ngayhethan.Value = DateTime.Now;
            selectedMathedocgia = -1;
        }

        private void btn_Giahanthe_Click(object sender, EventArgs e)
        {
            if (selectedMathedocgia != -1)
            {
                DateTime ngayhethanMoi = dtp_Ngayhethan.Value;

                // Thực hiện cập nhật dữ liệu trong bảng Thedocgia
                string updateThedocgiaQuery = "UPDATE Thedocgia SET Ngayhethan = @NgayhethanMoi WHERE Mathedocgia = @Mathedocgia";
                using (SqlCommand command = new SqlCommand(updateThedocgiaQuery, connection))
                {
                    command.Parameters.AddWithValue("@NgayhethanMoi", ngayhethanMoi);
                    command.Parameters.AddWithValue("@Mathedocgia", selectedMathedocgia);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                LoadData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thẻ để gia hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
