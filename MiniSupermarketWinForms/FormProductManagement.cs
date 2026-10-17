/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026 - Cap nhat Buoi 6: Phan trang LINQ, tim kiem va loc theo nhom hang
 * Mo ta: FormProductManagement - Quan ly thong tin san pham va ton kho
 */
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarketWinForms
{
    public partial class FormProductManagement : Form
    {
        private int _selectedProductId = -1;
        private int _currentPage = 1;
        private readonly int _pageSize = 10;
        private int _totalPages = 1;
        private bool _isCategoryLoaded = false;

        public FormProductManagement()
        {
            InitializeComponent();
            UiTheme.StyleGrid(dgvProducts);
            dgvProducts.RowTemplate.Height = 28;
            dgvProducts.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewRow r in dgvProducts.Rows)
                {
                    r.Height = 28;
                }
                if (dgvProducts.Columns["ProductName"] != null)
                {
                    dgvProducts.Columns["ProductId"].FillWeight = 8;
                    dgvProducts.Columns["ProductId"].HeaderText = "Mã SP";
                    dgvProducts.Columns["Barcode"].FillWeight = 14;
                    dgvProducts.Columns["Barcode"].HeaderText = "Mã vạch";
                    dgvProducts.Columns["ProductName"].FillWeight = 38;
                    dgvProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                    dgvProducts.Columns["Price"].FillWeight = 12;
                    dgvProducts.Columns["Price"].HeaderText = "Đơn giá";
                    dgvProducts.Columns["StockQuantity"].FillWeight = 10;
                    dgvProducts.Columns["StockQuantity"].HeaderText = "Tồn kho";
                    dgvProducts.Columns["CategoryId"].FillWeight = 8;
                    dgvProducts.Columns["CategoryId"].HeaderText = "Mã nhóm";
                    dgvProducts.Columns["CategoryName"].FillWeight = 20;
                    dgvProducts.Columns["CategoryName"].HeaderText = "Nhóm hàng";
                }
            };
        }

        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadProductsPagedAsync();
        }

        // 1. Tải danh mục vào ComboBox chi tiết và ComboBox lọc
        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await ApiClientService.Client.GetFromJsonAsync<List<CategoryDto>>("categories");
                if (categories != null)
                {
                    // ComboBox trong nhóm Thông tin sản phẩm (dùng để thêm/sửa)
                    cboCategory.DataSource = new List<CategoryDto>(categories);
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryId";

                    // ComboBox lọc nhóm hàng phía trên bảng (Bài tập 6.2)
                    var filterList = new List<CategoryDto>
                    {
                        new CategoryDto { CategoryId = 0, CategoryName = "-- Tất cả nhóm hàng --" }
                    };
                    filterList.AddRange(categories);

                    cboFilterCategory.DataSource = filterList;
                    cboFilterCategory.DisplayMember = "CategoryName";
                    cboFilterCategory.ValueMember = "CategoryId";
                    cboFilterCategory.SelectedIndex = 0;

                    _isCategoryLoaded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Gọi API phân trang và hiển thị dữ liệu lên DataGridView
        private async Task LoadProductsPagedAsync()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                int categoryId = 0;
                if (cboFilterCategory.SelectedValue != null &&
                    int.TryParse(cboFilterCategory.SelectedValue.ToString(), out int cId))
                {
                    categoryId = cId;
                }

                string url = $"products/paged?keyword={Uri.EscapeDataString(search)}&categoryId={categoryId}&pageNumber={_currentPage}&pageSize={_pageSize}";

                var result = await ApiClientService.Client.GetFromJsonAsync<PagedResultDto<ProductDto>>(url);
                if (result != null)
                {
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages == 0 ? 1 : result.TotalPages;

                    dgvProducts.DataSource = result.Items;

                    // Cập nhật nhãn phân trang
                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} SP)";

                    // Bật/tắt nút điều hướng
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Sự kiện chuyển trang
        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadProductsPagedAsync();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadProductsPagedAsync();
            }
        }

        // 4. Sự kiện tìm kiếm theo từ khóa
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1; // Khi tìm kiếm từ khóa mới, luôn quay về trang 1
            await LoadProductsPagedAsync();
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _currentPage = 1;
                await LoadProductsPagedAsync();
            }
        }

        // 5. Sự kiện lọc theo nhóm hàng (Bài tập 6.2)
        private async void cboFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isCategoryLoaded) return;
            _currentPage = 1; // Khi đổi bộ lọc, quay về trang 1
            await LoadProductsPagedAsync();
        }

        // 6. Chọn dòng trên DataGridView để hiển thị lên Form nhập liệu
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].DataBoundItem is ProductDto item)
            {
                _selectedProductId = item.ProductId;
                txtBarcode.Text = item.Barcode;
                txtProductName.Text = item.ProductName;
                txtPrice.Text = item.Price.ToString("0.##");
                txtStockQuantity.Text = item.StockQuantity.ToString();
                cboCategory.SelectedValue = item.CategoryId;
            }
        }

        // 7. Thêm mới sản phẩm qua API
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var newProduct = new
            {
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                StockQuantity = int.Parse(txtStockQuantity.Text.Trim()),
                CategoryId = Convert.ToInt32(cboCategory.SelectedValue)
            };

            try
            {
                var response = await ApiClientService.Client.PostAsJsonAsync("products", newProduct);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsPagedAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Mã vạch bị trùng hoặc có lỗi xảy ra từ máy chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 8. Cập nhật sản phẩm qua API
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            var updatedProduct = new
            {
                ProductId = _selectedProductId,
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                StockQuantity = int.Parse(txtStockQuantity.Text.Trim()),
                CategoryId = Convert.ToInt32(cboCategory.SelectedValue)
            };

            try
            {
                var response = await ApiClientService.Client.PutAsJsonAsync($"products/{_selectedProductId}", updatedProduct);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsPagedAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại (mã vạch trùng hoặc dữ liệu không hợp lệ)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 9. Xóa sản phẩm qua API
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm #{_selectedProductId} ({txtProductName.Text})?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var response = await ApiClientService.Client.DeleteAsync($"products/{_selectedProductId}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProductsPagedAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại (sản phẩm có thể đã tồn tại trong hóa đơn bán hàng)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 10. Làm mới form nhập liệu
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            _selectedProductId = -1;
            txtBarcode.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtStockQuantity.Clear();
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            dgvProducts.ClearSelection();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtStockQuantity.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số không âm hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtStockQuantity.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Số lượng tồn kho phải là số nguyên không âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm ngành hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Các lớp DTO tiếp nhận dữ liệu từ API
        public class ProductDto
        {
            public int ProductId { get; set; }
            public string Barcode { get; set; } = string.Empty;
            public string ProductName { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; } = string.Empty;
        }

        public class CategoryDto
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
        }

        public class PagedResultDto<T>
        {
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
            public List<T> Items { get; set; } = new();
        }
    }
}
