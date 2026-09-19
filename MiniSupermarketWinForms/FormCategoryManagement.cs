using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarketWinForms
{
    public partial class FormCategoryManagement : Form
    {
        public FormCategoryManagement()
        {
            InitializeComponent();
        }

        // Bổ sung phương thức cấu hình HttpClient có gắn kèm Token bảo mật
        private HttpClient GetAuthenticatedClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7006/api/")
            };

            // Đính kèm Token vào Header theo chuẩn Bearer Authentication
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        // Khi Form mở lên
        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // =========================================================
        // LOAD DANH SÁCH
        // GET /api/categories
        // =========================================================
        private async Task LoadDataAsync()
        {
            try
            {
                using (var client = GetAuthenticatedClient()) // Sử dụng client đã gắn token
                {
                    var categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories");
                    dgvCategories.DataSource = categories;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi quyền truy cập hoặc mất kết nối: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CLICK VÀO DÒNG TRÊN DATAGRIDVIEW
        // =========================================================
        private void dgvCategories_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

            txtId.Text = row.Cells["CategoryId"].Value?.ToString() ?? "";
            txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
        }

        // =========================================================
        // NÚT TẢI LẠI
        // =========================================================
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
        }

        // =========================================================
        // THÊM MỚI
        // POST /api/categories
        // =========================================================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newCategory = new
                {
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.PostAsJsonAsync("categories", newCategory);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Thêm nhóm hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        string message = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Thêm thất bại!\n\n" + message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CẬP NHẬT
        // PUT /api/categories/{id}
        // =========================================================
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên nhóm hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var updateCategory = new
                {
                    CategoryId = id,
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.PutAsJsonAsync($"categories/{id}", updateCategory);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        string message = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Cập nhật thất bại!\n\n" + message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XÓA
        // DELETE /api/categories/{id}
        // =========================================================
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa nhóm hàng ID = {id}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.DeleteAsync($"categories/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        string message = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Xóa thất bại!\n\n" + message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // TÌM KIẾM
        // GET /api/categories/search?keyword=...
        // =========================================================
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                string url = $"categories/search?keyword={Uri.EscapeDataString(keyword)}";

                using (var client = GetAuthenticatedClient())
                {
                    var result = await client.GetFromJsonAsync<List<CategoryDto>>(url);
                    dgvCategories.DataSource = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tìm kiếm!\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XÓA TRẮNG FORM
        // =========================================================
        private void ClearInputs()
        {
            txtId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
        }
    }

    // DTO nhận dữ liệu từ API
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; }
    }
}
