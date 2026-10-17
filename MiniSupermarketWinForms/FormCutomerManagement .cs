/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay cap nhat: 27/09/2026
 * FormCustomerManagement - Giao dien quan ly khach hang than thiet
 * Goi API /api/customers su dung HttpClient + JWT Token
 */
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace MiniSupermarketWinForms
{
    public partial class FormCustomerManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 10;
        private int _totalPages = 1;
        private int _totalItems = 0;

        public FormCustomerManagement()
        {
            InitializeComponent();
            UiTheme.StyleGrid(dgvCustomers);
            dgvCustomers.RowTemplate.Height = 28;
            dgvCustomers.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewRow r in dgvCustomers.Rows)
                {
                    r.Height = 28;
                }
            };
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

        // Khi Form mo len -> tu dong tai danh sach
        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // =========================================================
        // LOAD DANH SACH KHACH HANG
        // GET /api/customers
        // =========================================================
        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                string url = $"customers/paged?pageNumber={_currentPage}&pageSize={_pageSize}";
                if (!string.IsNullOrEmpty(keyword))
                {
                    url += $"&keyword={Uri.EscapeDataString(keyword)}";
                }

                using (var client = GetAuthenticatedClient())
                {
                    var result = await client.GetFromJsonAsync<PagedCustomerResult>(url);
                    dgvCustomers.Rows.Clear();
                    if (result != null)
                    {
                        _currentPage = result.CurrentPage;
                        _totalPages = result.TotalPages > 0 ? result.TotalPages : 1;
                        _totalItems = result.TotalItems;

                        foreach (var c in result.Items)
                        {
                            dgvCustomers.Rows.Add(
                                c.CustomerId,
                                c.CustomerName,
                                c.PhoneNumber,
                                c.Address,
                                c.RewardPoints,
                                c.MembershipRank
                            );
                        }
                        foreach (DataGridViewRow r in dgvCustomers.Rows)
                        {
                            r.Height = 28;
                        }
                    }
                    else
                    {
                        _totalPages = 1;
                        _totalItems = 0;
                    }

                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {_totalItems} KH)";
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadDataAsync();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadDataAsync();
            }
        }

        // =========================================================
        // NUT TAI LAI
        // =========================================================
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            _currentPage = 1;
            await LoadDataAsync();
        }

        // =========================================================
        // CLICK VAO DONG TREN DATAGRIDVIEW -> dien vao o nhap lieu
        // =========================================================
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerId.Text      = row.Cells["CustomerId"].Value?.ToString();
                txtCustomerName.Text    = row.Cells["CustomerName"].Value?.ToString();
                txtPhoneNumber.Text     = row.Cells["PhoneNumber"].Value?.ToString();
                txtAddress.Text         = row.Cells["Address"].Value?.ToString();
                txtRewardPoints.Text    = row.Cells["RewardPoints"].Value?.ToString();
                txtMembershipRank.Text  = row.Cells["MembershipRank"].Value?.ToString();
            }
        }

        // =========================================================
        // THEM MOI KHACH HANG
        // POST /api/customers
        // =========================================================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên và Số điện thoại!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newCustomer = new
                {
                    CustomerName    = txtCustomerName.Text.Trim(),
                    PhoneNumber     = txtPhoneNumber.Text.Trim(),
                    Address         = txtAddress.Text.Trim(),
                    RewardPoints    = int.TryParse(txtRewardPoints.Text, out int rp) ? rp : 0,
                    MembershipRank  = string.IsNullOrWhiteSpace(txtMembershipRank.Text)
                                        ? "Chuẩn" : txtMembershipRank.Text.Trim()
                };

                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.PostAsJsonAsync("customers", newCustomer);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
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
        // CAP NHAT KHACH HANG
        // PUT /api/customers/{id}
        // =========================================================
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Tên và Số điện thoại không được để trống!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var updateCustomer = new
                {
                    CustomerId      = id,
                    CustomerName    = txtCustomerName.Text.Trim(),
                    PhoneNumber     = txtPhoneNumber.Text.Trim(),
                    Address         = txtAddress.Text.Trim(),
                    RewardPoints    = int.TryParse(txtRewardPoints.Text, out int rp) ? rp : 0,
                    MembershipRank  = string.IsNullOrWhiteSpace(txtMembershipRank.Text)
                                        ? "Chuẩn" : txtMembershipRank.Text.Trim()
                };

                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.PutAsJsonAsync($"customers/{id}", updateCustomer);
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
        // XOA KHACH HANG
        // DELETE /api/customers/{id}
        // =========================================================
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng ID = {id}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var client = GetAuthenticatedClient())
                {
                    var response = await client.DeleteAsync($"customers/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo",
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
        // TIM KIEM KHACH HANG theo ten hoac so dien thoai
        // GET /api/customers/search?keyword=...
        // =========================================================
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadDataAsync();
        }

                private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        // =========================================================
        // XOA TRANG CAC O NHAP LIEU
        // =========================================================
        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtRewardPoints.Clear();
            txtMembershipRank.Clear();
        }
    }

    // DTO nhan du lieu tu API /api/customers
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int RewardPoints { get; set; }
        public string MembershipRank { get; set; } = string.Empty;
    }

    // DTO nhan du lieu phan trang tu API /api/customers/paged
    public class PagedCustomerResult
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<CustomerDto> Items { get; set; } = new List<CustomerDto>();
    }

}
