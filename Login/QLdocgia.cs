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
    public partial class QLdocgia : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=DESKTOP-LRS7A72\\SQLEXPRESS;Initial Catalog=qlthuvien2;Integrated Security=True"; // Thay YOUR_CONNECTION_STRING bằng chuỗi kết nối của bạn

        private Trangchu formtc;
        public QLdocgia(Trangchu formtc)
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            this.formtc=formtc;
        }

       
        private void QLHoivien_Load(object sender, EventArgs e)
        {
            
        }

        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(txt_Tendocgia.Text))
            {
                MessageBox.Show("Tên độc giả đang trống.Vui lòng nhập Tên độc giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Namsinh.Text))
            {
                MessageBox.Show("Năm sinh đang bỏ trống.Vui lòng nhập năm sinh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txt_Namsinh.Text, out int namsinh) || namsinh <= 0)
            {
                MessageBox.Show("Năm sinh không hợp lệ.Vui lòng nhập số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Sodienthoai.Text))
            {
                MessageBox.Show("Số điện thoại đang trống.Vui lòng nhập số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txt_Sodienthoai.Text, out int sodienthoai) || sodienthoai <= 0)
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Gioitinh.Text))
            {
                MessageBox.Show("Giới tính đang trống.Vui lòng nhập giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào trước khi thêm
                if (IsValidInput())
                {
                    string query = "INSERT INTO Docgia (Tendocgia, Namsinh, Sodienthoai, Gioitinh) " +
                                   "VALUES (@Tendocgia, @Namsinh, @Sodienthoai, @Gioitinh)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Tendocgia", txt_Tendocgia.Text);
                        command.Parameters.AddWithValue("@Namsinh", Convert.ToInt32(txt_Namsinh.Text));
                        command.Parameters.AddWithValue("@Sodienthoai", Convert.ToInt32(txt_Sodienthoai.Text));
                        command.Parameters.AddWithValue("@Gioitinh", txt_Gioitinh.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    LoadData();
                    MessageBox.Show("Thêm độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm độc giả không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadData()
        {
            string query = "SELECT * FROM Docgia";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dtgv_Docgia.DataSource = table;
        }

        private void QLdocgia_Load(object sender, EventArgs e)
        {
            this.Width = Parent.Width;
            this.Height = Parent.Height;

            LoadData();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Madocgia.Text))
                {
                    MessageBox.Show("Vui lòng chọn độc giả cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra dữ liệu đầu vào trước khi sửa
                if (IsValidInput())
                {
                    string query = "UPDATE Docgia SET Tendocgia = @Tendocgia, Namsinh = @Namsinh, " +
                                   "Sodienthoai = @Sodienthoai, Gioitinh = @Gioitinh WHERE Madocgia = @Madocgia";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Madocgia", Convert.ToInt32(txt_Madocgia.Text));
                        command.Parameters.AddWithValue("@Tendocgia", txt_Tendocgia.Text);
                        command.Parameters.AddWithValue("@Namsinh", Convert.ToInt32(txt_Namsinh.Text));
                        command.Parameters.AddWithValue("@Sodienthoai", Convert.ToInt32(txt_Sodienthoai.Text));
                        command.Parameters.AddWithValue("@Gioitinh", txt_Gioitinh.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    LoadData();

                    MessageBox.Show("Cập nhật thông tin độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin độc giả không thành công, Lỗi:"+ex.Message , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Madocgia.Text))
            {
                // Start a transaction to ensure both deletes are executed atomically
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Delete records from Thedocgia table
                    string deleteThedocgiaQuery = "DELETE FROM Thedocgia WHERE Madocgia = @Madocgia";
                    using (SqlCommand commandThedocgia = new SqlCommand(deleteThedocgiaQuery, connection, transaction))
                    {
                        commandThedocgia.Parameters.AddWithValue("@Madocgia", Convert.ToInt32(txt_Madocgia.Text));
                        commandThedocgia.ExecuteNonQuery();
                    }

                    // Delete record from Docgia table
                    string deleteDocgiaQuery = "DELETE FROM Docgia WHERE Madocgia = @Madocgia";
                    using (SqlCommand commandDocgia = new SqlCommand(deleteDocgiaQuery, connection, transaction))
                    {
                        commandDocgia.Parameters.AddWithValue("@Madocgia", Convert.ToInt32(txt_Madocgia.Text));
                        commandDocgia.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();

                    MessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if an exception occurs
                    if (transaction != null)
                        transaction.Rollback();

                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }

                LoadData();
            }
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_Madocgia.Text))
                {
                    string query = "SELECT * FROM Docgia WHERE Madocgia = @Madocgia";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Madocgia", Convert.ToInt32(txt_Madocgia.Text));

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dtgv_Docgia.DataSource = table;

                    }
                    MessageBox.Show("Tìm kiếm độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgv_Docgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            txt_Madocgia.Text = "";
            txt_Namsinh.Text = "";
            txt_Sodienthoai.Text = "";
            txt_Tendocgia.Text = "";
            txt_Gioitinh.Text = "";
        }

        private void btn_capmoithe_Click(object sender, EventArgs e)
        {
            if(txt_Madocgia.Text!="")
            {
                Thehoivien newthv = new Thehoivien(txt_Madocgia.Text);
               formtc.addform(newthv);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 độc giả bạn muốn cấp thẻ!");
            }
        }

        private void dtgv_Docgia_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã chọn một dòng hợp lệ
            {
                DataGridViewRow selectedRow = dtgv_Docgia.Rows[e.RowIndex];

                // Hiển thị thông tin của dòng được chọn vào các TextBox tương ứng
                txt_Madocgia.Text = selectedRow.Cells["Madocgia"].Value.ToString();
                txt_Tendocgia.Text = selectedRow.Cells["Tendocgia"].Value.ToString();
                txt_Namsinh.Text = selectedRow.Cells["Namsinh"].Value.ToString();
                txt_Sodienthoai.Text = selectedRow.Cells["Sodienthoai"].Value.ToString();
                txt_Gioitinh.Text = selectedRow.Cells["Gioitinh"].Value.ToString();
            }
        }
    }
}
