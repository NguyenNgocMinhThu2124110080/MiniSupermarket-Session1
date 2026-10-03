/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 * FormProductManagement - Giao dien quan ly san pham sieu thi
 * Goi API /api/products su dung HttpClient + JWT Token
 * Tinh nang: Load, Them, Cap nhat, Xoa, Tim kiem, Loc theo danh muc
 */
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace MiniSupermarketWinForms
{
    public partial class FormProductManagement : Form
    {
        public FormProductManagement()
        {
            InitializeComponent();
        }

        // Tao HttpClient co dinh kem JWT Token tu SessionManager
        private HttpClient GetAuthenticatedClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7006/api/")
            };
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        // Khi Form mo len -> tu dong tai du lieu
        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadDataAsync();
        }

        // =========================================================
        // LOAD DANH SACH DANH MUC VAO COMBOBOX
        // GET /api/categories
        // =========================================================
        private async System.Threading.Tasks.Task LoadCategoriesAsync()
        {
            try
            {
                using (var client = GetAuthenticatedClient())
                {
                    var categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories");
                    cboCategory.Items.Clear();
                    cboCategory.Items.Add(new ComboItem(0, "-- Tất cả danh mục --"));

                    cboFilterCategory.Items.Clear();
                    cboFilterCategory.Items.Add(new ComboItem(0, "-- Tất cả danh mục --"));

                    if (categories != null)
                    {
                        foreach (var cat in categories)
                        {
                            var item = new ComboItem(cat.CategoryId, cat.CategoryName);
                            cboCategory.Items.Add(item);
                            cboFilterCategory.Items.Add(item);
                        }
                    }

                    cboCategory.SelectedIndex = 0;
                    cboFilterCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD DANH SACH SAN PHAM
        // GET /api/products
        // =========================================================
        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            try
            {
                using (var client = GetAuthenticatedClient())
                {
                    var products = await client.GetFromJsonAsync<List<ProductDto>>("products");
                    FillGrid(products);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Do du lieu vao DataGridView
        private void FillGrid(List<ProductDto> products)
        {
            dgvProducts.Rows.Clear();
            if (products == null) return;
            foreach (var p in products)
            {
                dgvProducts.Rows.Add(
                    p.ProductId,
                    p.Barcode,
                    p.ProductName,
                    p.Price.ToString("N0") + " đ",
                    p.StockQuantity,
                    p.CategoryId,
                    p.Category?.CategoryName ?? ""
                );
            }
        }

        // =========================================================
        // NUT TAI LAI
        // =========================================================
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            cboFilterCategory.SelectedIndex = 0;
            txtSearch.Clear();
        }

        // =========================================================
        // CLICK VAO DONG TREN DATAGRIDVIEW -> dien vao o nhap lieu
        // =========================================================
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
            txtProductId.Text    = row.Cells["ProductId"].Value?.ToString() ?? "";
            txtBarcode.Text      = row.Cells["Barcode"].Value?.ToString() ?? "";
            txtProductName.Text  = row.Cells["ProductName"].Value?.ToString() ?? "";

            // Lay gia goc (bo dinh dang "N0 đ")
            string priceRaw = row.Cells["Price"].Value?.ToString() ?? "0";
            priceRaw = priceRaw.Replace(" đ", "").Replace(".", "").Replace(",", "");
            txtPrice.Text = priceRaw;

            txtStockQuantity.Text = row.Cells["StockQuantity"].Value?.ToString() ?? "";

            // Chon dung danh muc trong ComboBox
            if (int.TryParse(row.Cells["CategoryId"].Value?.ToString(), out int catId))
            {
                for (int i = 0; i < cboCategory.Items.Count; i++)
                {
                    if (cboCategory.Items[i] is ComboItem item && item.Id == catId)
                    {
                        cboCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        // =========================================================
        // THEM MOI SAN PHAM
        // POST /api/products
        // =========================================================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var selectedCat = cboCategory.SelectedItem as ComboItem;
                var newProduct = new
                {
                    Barcode       = txtBarcode.Text.Trim(),
                    ProductName   = txtProductName.Text.Trim(),
                    Price         = decimal.TryParse(txtPrice.Text, out decimal pr) ? pr : 0,
                    StockQuantity = int.TryParse(txtStockQuantity.Text, out int sq) ? sq : 0,
                    CategoryId    = selectedCat?.Id ?? 0
                };

                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.PostAsJsonAsync("products", newProduct);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        string msg = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Thêm thất bại!\n\n" + msg, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CAP NHAT SAN PHAM
        // PUT /api/products/{id}
        // =========================================================
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            try
            {
                var selectedCat = cboCategory.SelectedItem as ComboItem;
                var updateProduct = new
                {
                    ProductId     = id,
                    Barcode       = txtBarcode.Text.Trim(),
                    ProductName   = txtProductName.Text.Trim(),
                    Price         = decimal.TryParse(txtPrice.Text, out decimal pr) ? pr : 0,
                    StockQuantity = int.TryParse(txtStockQuantity.Text, out int sq) ? sq : 0,
                    CategoryId    = selectedCat?.Id ?? 0
                };

                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.PutAsJsonAsync($"products/{id}", updateProduct);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        string msg = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Cập nhật thất bại!\n\n" + msg, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XOA SAN PHAM
        // DELETE /api/products/{id}
        // =========================================================
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm ID = {id}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.DeleteAsync($"products/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        string msg = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Xóa thất bại!\n\n" + msg, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // TIM KIEM SAN PHAM theo ten hoac ma vach
        // GET /api/products/search?keyword=...
        // =========================================================
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                string url = $"products/search?keyword={Uri.EscapeDataString(keyword)}";
                using (var client = GetAuthenticatedClient())
                {
                    var result = await client.GetFromJsonAsync<List<ProductDto>>(url);
                    FillGrid(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tìm kiếm!\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOC THEO DANH MUC
        // GET /api/products/by-category/{categoryId}
        // =========================================================
        private async void cboFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cboFilterCategory.SelectedItem as ComboItem;
            if (selected == null || selected.Id == 0)
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                string url = $"products/by-category/{selected.Id}";
                using (var client = GetAuthenticatedClient())
                {
                    var result = await client.GetFromJsonAsync<List<ProductDto>>(url);
                    FillGrid(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lọc danh mục!\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // KIEM TRA DU LIEU NHAP
        // =========================================================
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã vạch!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Giá bán phải là số hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtStockQuantity.Text, out _))
            {
                MessageBox.Show("Số lượng tồn kho phải là số nguyên!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var selectedCat = cboCategory.SelectedItem as ComboItem;
            if (selectedCat == null || selectedCat.Id == 0)
            {
                MessageBox.Show("Vui lòng chọn Danh mục!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // =========================================================
        // XOA TRANG CAC O NHAP LIEU
        // =========================================================
        private void ClearInputs()
        {
            txtProductId.Clear();
            txtBarcode.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtStockQuantity.Clear();
            cboCategory.SelectedIndex = 0;
        }
    }

    // DTO nhan du lieu tu API /api/products
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }  // bo ? vi .NET Framework
    }

    // Helper class cho ComboBox hien thi ten nhung luu Id
    public class ComboItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ComboItem(int id, string name) { Id = id; Name = name; }
        public override string ToString() => Name;
    }
}
