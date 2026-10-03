/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 * Mo ta: FormProductManagement - Quan ly thong tin san pham va ton kho
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarketWinForms
{
    public partial class FormProductManagement : Form
    {
        private int _selectedProductId = -1;

        public FormProductManagement()
        {
            InitializeComponent();
        }

        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadProductsAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await ApiClientService.Client.GetFromJsonAsync<List<CategoryDto>>("categories");
                if (categories != null)
                {
                    cboCategory.DataSource = categories;
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                var products = await ApiClientService.Client.GetFromJsonAsync<List<ProductDto>>("products");
                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                _selectedProductId = Convert.ToInt32(row.Cells["ProductId"].Value);
                txtBarcode.Text = row.Cells["Barcode"].Value?.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value?.ToString();
                txtPrice.Text = row.Cells["Price"].Value?.ToString();
                txtStockQuantity.Text = row.Cells["StockQuantity"].Value?.ToString();
                cboCategory.SelectedValue = row.Cells["CategoryId"].Value;
            }
        }

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
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Mã vạch bị trùng hoặc có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Mã vạch bị trùng hoặc có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var response = await ApiClientService.Client.DeleteAsync($"products/{_selectedProductId}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProductsAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtStockQuantity.Text, out _))
            {
                MessageBox.Show("Số lượng phải là số nguyên hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

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
    }
}
