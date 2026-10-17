/*
 * Họ và tên: Nguyễn Ngọc Minh Thư
 * Mã sinh viên: 2124110080
 * Ngày tạo: 26/09/2026 - Ngày cập nhật: 17/10/2026
 * Đề tài: Bách hóa Tổng hợp Hoàng Dung
 */
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Forms;

namespace MiniSupermarketWinForms {
    public partial class FormLogin : Form {
        
        // Khởi tạo HttpClient trỏ đến địa chỉ của Web API Backend (Cập nhật lại port 7006)
        private static readonly HttpClient _client = new HttpClient {
            BaseAddress = new Uri("https://localhost:7006/api/") 
        };

        public FormLogin() {
            InitializeComponent();
            ApplyBranding();
        }

        // Giao diện đăng nhập mang thương hiệu cửa hàng
        private void ApplyBranding() {
            const int bannerHeight = 80;
            foreach (Control c in Controls) c.Top += bannerHeight;

            var lblBrand = new Label {
                Text = "🛒 BÁCH HÓA TỔNG HỢP\r\nHOÀNG DUNG",
                Dock = DockStyle.Top,
                Height = bannerHeight,
                BackColor = UiTheme.Primary,
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            Controls.Add(lblBrand);

            ClientSize = new System.Drawing.Size(ClientSize.Width, ClientSize.Height + bannerHeight + 10);
            BackColor = System.Drawing.Color.White;
            Text = "Đăng nhập - Bách hóa Tổng hợp Hoàng Dung";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = UiTheme.PrimaryLight;
            btnLogin.ForeColor = System.Drawing.Color.White;
            btnLogin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            AcceptButton = btnLogin;
        }

        // Sự kiện khi người dùng bấm nút Đăng nhập
        private async void btnLogin_Click(object sender, EventArgs e) {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // Kiểm tra ràng buộc cơ bản phía Client
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                // Đóng gói dữ liệu gửi lên endpoint POST /api/auth/login
                var loginData = new { Username = username, Password = password };
                var response = await _client.PostAsJsonAsync("auth/login", loginData);

                if (response.IsSuccessStatusCode) {
                    // Đọc chuỗi JSON trả về từ Server khi đăng nhập thành công
                    var jsonString = await response.Content.ReadAsStringAsync();
                    
                    // Sử dụng using block chuẩn thay cho using var vì WinForms .NET 4.7.2 dùng C# 7.3
                    using (var doc = JsonDocument.Parse(jsonString)) {
                        var root = doc.RootElement;
                        // Trích xuất Token và Role lưu vào lớp tĩnh SessionManager dùng chung toàn ứng dụng
                        SessionManager.JwtToken = root.GetProperty("token").GetString() ?? string.Empty;
                        SessionManager.CurrentRole = root.GetProperty("role").GetString() ?? string.Empty;
                        if (root.TryGetProperty("hoTen", out var hoTenElem))
                            SessionManager.CurrentUser = hoTenElem.GetString() ?? string.Empty;
                        if (root.TryGetProperty("username", out var userElem))
                            SessionManager.CurrentUsername = userElem.GetString() ?? string.Empty;

                        // Add the token to the global HttpClient so child forms can make authenticated requests
                        ApiClientService.AttachToken(SessionManager.JwtToken);
                    }

                    MessageBox.Show($"Đăng nhập thành công với quyền: {SessionManager.CurrentRole}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở Form quản lý chính (FormMainShell) và ẩn Form đăng nhập đi
                    FormMainShell mainForm = new FormMainShell();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close(); // Đóng hẳn ứng dụng khi form chính tắt
                } else {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối đến Server: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
