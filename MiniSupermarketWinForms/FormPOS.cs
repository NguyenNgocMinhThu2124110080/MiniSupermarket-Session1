/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 * Mo ta: FormPOS - Man hinh Ban hang quay POS, xu ly quet ma vach va thanh toan
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarketWinForms {
    public partial class FormPOS : Form {
        private readonly List<CartItemDto> _cart = new();

        public FormPOS() {
            InitializeComponent();
            SetupCartGrid();
        }

        private void SetupCartGrid() {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 80 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn Giá", Width = 110 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 70 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "Thành Tiền", Width = 120 });
        }

        // Bắt sự kiện quét mã Barcode
        private async void txtBarcode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtBarcode.Text)) {
                string barcode = txtBarcode.Text.Trim();
                txtBarcode.Clear();
                await AddProductToCartByBarcodeAsync(barcode);
            }
        }

        private async Task AddProductToCartByBarcodeAsync(string barcode) {
            try {
                // Gọi API tra cứu sản phẩm theo Barcode
                var product = await MiniSupermarketWinForms.ApiClientService.Client.GetFromJsonAsync<ProductDto>($"products/search?barcode={barcode}"); // Da fix endpoint
                if (product == null) {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (existingItem != null) {
                    existingItem.Quantity++;
                } else {
                    _cart.Add(new CartItemDto {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }

                UpdateCartDisplay();
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartDisplay() {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;

            decimal total = _cart.Sum(x => x.TotalPrice);
            lblTotalAmount.Text = $"{total:N0} đ";
            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e) {
            CalculateChange();
        }

        private void CalculateChange() {
            decimal total = _cart.Sum(x => x.TotalPrice);
            if (decimal.TryParse(txtCashReceived.Text, out decimal cashReceived)) {
                decimal change = cashReceived - total;
                lblChange.Text = change >= 0 ? $"{change:N0} đ" : "Chưa đủ tiền!";
                lblChange.ForeColor = change >= 0 ? Color.Black : Color.Red;
            } else {
                lblChange.Text = "0 đ";
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e) {
            if (_cart.Count == 0) {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var orderRequest = new {
                CashierUsername = MiniSupermarketWinForms.SessionManager.CurrentUsername,
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                Items = _cart.Select(i => new { i.ProductId, i.Quantity, i.UnitPrice }).ToList()
            };

            // Fake call for now since orders endpoint isn't built yet
            // var response = await ApiClientService.Client.PostAsJsonAsync("orders/checkout", orderRequest);
            bool success = true;
            if (success) {
                MessageBox.Show("Thanh toán thành công và đã in hóa đơn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _cart.Clear();
                UpdateCartDisplay();
                txtCashReceived.Clear();
                txtCustomerPhone.Clear();
                lblCustomerName.Text = "Khách vãng lai";
            } else {
                MessageBox.Show("Thanh toán thất bại từ máy chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CartItemDto {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }

    public class ProductDto {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
