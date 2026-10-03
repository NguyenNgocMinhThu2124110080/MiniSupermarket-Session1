/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay cap nhat: 03/10/2026
 * AuthController - Xac thuc dang nhap va cap JWT Token
 * Cap nhat: Bo sung 15 tai khoan mau phan quyen (Admin / Cashier / Warehouse)
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniSupermarket.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration) {
            _configuration = configuration;
        }

        // Danh sach 15 tai khoan mau phan quyen (username, password, hoTen, role)
        private static readonly List<(string User, string Pass, string HoTen, string Role)> _accounts = new()
        {
            ("admin01",      "123456", "Nguyễn Quản Trị",    "Admin"),
            ("admin02",      "123456", "Trần Giám Đốc",      "Admin"),
            ("cashier01",    "123456", "Lê Thu Ngân",         "Cashier"),
            ("cashier02",    "123456", "Phạm Bán Hàng",       "Cashier"),
            ("cashier03",    "123456", "Hoàng Thu Ngân",      "Cashier"),
            ("cashier04",    "123456", "Vũ Thị Quầy",         "Cashier"),
            ("cashier05",    "123456", "Đỗ Bán Lẻ",           "Cashier"),
            ("ware01",       "123456", "Ngô Quản Kho",        "Warehouse"),
            ("ware02",       "123456", "Bùi Kiểm Kê",         "Warehouse"),
            ("ware03",       "123456", "Dương Thủ Kho",       "Warehouse"),
            ("ware04",       "123456", "Lý Nhập Hàng",        "Warehouse"),
            ("admin_backup", "123456", "Đặng Hỗ Trợ",        "Admin"),
            ("cashier06",    "123456", "Hồ Ca Chiều",         "Cashier"),
            ("ware05",       "123456", "Trương Vận Chuyển",   "Warehouse"),
            ("supervisor",   "123456", "Mai Giám Sát",        "Admin"),
            // Giu lai tai khoan cu de tuong thich
            ("admin",        "123456", "Quản Trị Viên",       "Admin"),
            ("cashier",      "123456", "Thu Ngân",            "Cashier"),
        };

        // POST /api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request) {
            var account = _accounts.FirstOrDefault(
                a => a.User == request.Username && a.Pass == request.Password);

            if (account == default) {
                return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
            }

            var token = GenerateJwtToken(account.User, account.HoTen, account.Role);
            return Ok(new {
                success  = true,
                token    = token,
                role     = account.Role,
                hoTen    = account.HoTen,
                username = account.User
            });
        }

        // Tao JWT Token voi username, hoTen, role
        private string GenerateJwtToken(string username, string hoTen, string role) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(
                _configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!");

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,               username),
                    new Claim("HoTen",                       hoTen),
                    new Claim(ClaimTypes.Role,               role)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequestDto {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
