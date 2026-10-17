/*Nguyen Ngoc Minh Thu
 Mssv:2124110080
ngay tao "19/9/2026*/
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniSupermarketWinForms
{
    // Lớp tĩnh quản lý trạng thái phiên đăng nhập của ứng dụng (lưu Token)
    public static class SessionManager
    {
        public static string JwtToken    { get; set; } = string.Empty;
        public static string CurrentRole { get; set; } = string.Empty;
        public static string CurrentUser { get; set; } = string.Empty; // Ho ten nguoi dang nhap
        public static string CurrentUsername { get; set; } = string.Empty;
    }

    // Lớp tĩnh cung cấp các hàm gọi API dùng chung
    public static class ApiClientService
    {
        // Khởi tạo một thể hiện HttpClient dùng chung xuyên suốt ứng dụng
        public static readonly HttpClient Client = new HttpClient
        {
            // Thiết lập địa chỉ gốc của Backend API (Thay thế port nếu backend của bạn chạy cổng khác)
            BaseAddress = new Uri("https://localhost:7006/api/")
        };

        // Phương thức cập nhật Bearer Token sau khi đăng nhập thành công
        public static void AttachToken(string token)
        {
            Client.DefaultRequestHeaders.Authorization = null; // Xóa token cũ
            if (!string.IsNullOrEmpty(token))
            {
                Client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        // Hàm gọi API đăng nhập và lấy Token
        public static async Task<bool> LoginAsync(string username, string password)
        {
            // Đóng gói thông tin đăng nhập vào một object
            var loginObj = new { Username = username, Password = password };
            
            // Gửi request POST tới endpoint auth/login
            var response = await Client.PostAsJsonAsync("auth/login", loginObj);
            
            if (response.IsSuccessStatusCode)
            {
                // Nếu đăng nhập thành công, đọc kết quả JSON trả về
                var jsonString = await response.Content.ReadAsStringAsync();
                using (var doc = JsonDocument.Parse(jsonString))
                {
                    // Trích xuất Token và vai trò từ JSON và lưu vào SessionManager
                    SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                    SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                }
                
                return true; // Đăng nhập thành công
            }
            
            return false; // Đăng nhập thất bại
        }

        // Hàm gọi API lấy dữ liệu tĩnh, có gắn sẵn mã Token để Backend xác thực
        public static async Task<string> GetDataWithTokenAsync(string endpoint)
        {
            // Gắn mã Token vào tiêu đề Authorization của mỗi Request
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            
            // Gọi phương thức GET tới endpoint tương ứng
            var response = await Client.GetAsync(endpoint);
            
            if (response.IsSuccessStatusCode)
            {
                // Nếu gọi thành công, trả về dữ liệu nguyên bản dạng chuỗi
                return await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // Nếu Backend trả về 401 Unauthorized, nghĩa là mã Token đã hết hạn hoặc không hợp lệ
                throw new Exception("Phiên làm việc hết hạn hoặc chưa đăng nhập!");
            }
            
            throw new Exception("Lỗi khi gọi dữ liệu từ Server.");
        }
    }

    // Giao diện chung cho ứng dụng Bách hóa Tổng hợp Hoàng Dung
    public static class UiTheme
    {
        public static readonly System.Drawing.Color Primary = System.Drawing.Color.FromArgb(21, 87, 54);      // Xanh lá đậm (nền sidebar)
        public static readonly System.Drawing.Color PrimaryLight = System.Drawing.Color.FromArgb(34, 139, 84); // Xanh lá sáng
        public static readonly System.Drawing.Color Accent = System.Drawing.Color.FromArgb(234, 138, 20);      // Cam (nút đang chọn)
        public static readonly System.Drawing.Color Background = System.Drawing.Color.FromArgb(246, 248, 246); // Nền vùng làm việc
        public static readonly System.Drawing.Color GridAlt = System.Drawing.Color.FromArgb(240, 247, 242);    // Dòng xen kẽ

        private static readonly System.Collections.Generic.Dictionary<string, string> Headers =
            new System.Collections.Generic.Dictionary<string, string>
        {
            { "ProductId", "Mã SP" }, { "Barcode", "Mã vạch" }, { "ProductName", "Tên sản phẩm" },
            { "Price", "Đơn giá" }, { "StockQuantity", "Tồn kho" }, { "CategoryId", "Mã nhóm" },
            { "CategoryName", "Nhóm hàng" }, { "Description", "Mô tả" },
            { "CustomerId", "Mã KH" }, { "CustomerName", "Tên khách hàng" }, { "PhoneNumber", "Số điện thoại" },
            { "Address", "Địa chỉ" }, { "RewardPoints", "Điểm tích lũy" }, { "MembershipRank", "Hạng thẻ" },
            { "Id", "Mã" }, { "Username", "Tên đăng nhập" }, { "FullName", "Họ và tên" },
            { "Role", "Vai trò" }, { "IsActive", "Hoạt động" }
        };

        // Định dạng chung cho bảng dữ liệu: nền trắng, chỉ đọc, chọn cả dòng, tiêu đề tiếng Việt
        public static void StyleGrid(System.Windows.Forms.DataGridView dgv)
        {
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAlt;
            dgv.DefaultCellStyle.SelectionBackColor = Accent;
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.DataBindingComplete += (s, e) =>
            {
                foreach (System.Windows.Forms.DataGridViewColumn col in dgv.Columns)
                {
                    string key = string.IsNullOrEmpty(col.DataPropertyName) ? col.Name : col.DataPropertyName;
                    if (Headers.TryGetValue(key, out string text)) col.HeaderText = text;
                    if (key == "Price" || key == "UnitPrice" || key == "TotalPrice")
                    {
                        col.DefaultCellStyle.Format = "N0";
                        col.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                    }
                }
            };
        }
    }
}
