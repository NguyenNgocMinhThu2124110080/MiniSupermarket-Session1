/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 * Mo ta: FormUserManagement - Quan ly tai khoan nhan vien, chi danh cho Admin
 */
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarketWinForms {
    public partial class FormUserManagement : Form {
        public FormUserManagement() {
            InitializeComponent();
            cboRole.Items.AddRange(new string[] { "Admin", "Cashier", "Warehouse" });
            cboRole.SelectedIndex = 1;
        }

        private async void FormUserManagement_Load(object sender, EventArgs e) {
            await LoadUsersAsync();
        }

        private Task LoadUsersAsync() {
            try {
                // Fake API call for now since we don't have a Users endpoint yet
                // var users = await ApiClientService.Client.GetFromJsonAsync<List<UserDto>>("users");
                var users = new List<UserDto>
                {
                    new UserDto { Id = 1, Username = "admin01", FullName = "Nguyễn Quản Trị", Role = "Admin", IsActive = true },
                    new UserDto { Id = 2, Username = "cashier01", FullName = "Lê Thu Ngân", Role = "Cashier", IsActive = true },
                    new UserDto { Id = 3, Username = "ware01", FullName = "Ngô Quản Kho", Role = "Warehouse", IsActive = true }
                };
                dgvUsers.DataSource = users;
            } catch (Exception ex) {
                MessageBox.Show("Lỗi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Task.CompletedTask;
        }

        private async void btnAddUser_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)) {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Cashier"
            };

            // Fake request
            // var res = await ApiClientService.Client.PostAsJsonAsync("users", newUser);
            bool success = true;
            if (success) {
                MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUsersAsync();
                txtUsername.Clear();
                txtPassword.Clear();
                txtFullName.Clear();
            } else {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class UserDto {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
