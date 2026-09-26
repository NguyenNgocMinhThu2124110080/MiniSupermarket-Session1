/*Nguyen Ngoc Minh Thu
 Mssv:2124110080
ngay cap nhat: 26/09/2026
khai bao cac dich vu xac thuc va phan quyen cho API
*/
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniSupermarket.API.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình dịch vụ xác thực JWT Bearer
// Lấy mã bí mật từ appsettings.json, hoặc dùng một mã mặc định
var jwtSecret = builder.Configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!";
builder.Services.AddAuthentication(options => {
    // Thiết lập scheme xác thực mặc định là JwtBearer
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        // Có kiểm tra khóa ký token không? (Bắt buộc là true)
        ValidateIssuerSigningKey = true,
        // Cung cấp khóa ký lấy từ secret key
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
        // Không kiểm tra Issuer (người phát hành) trong bài thực hành này
        ValidateIssuer = false,
        // Không kiểm tra Audience (đối tượng sử dụng) trong bài thực hành này
        ValidateAudience = false
    };
});

// Thêm các Controller
builder.Services.AddControllers();
// Khởi tạo các endpoint API cho Swagger
builder.Services.AddEndpointsApiExplorer();
// Đăng ký dịch vụ Swagger để tạo tài liệu API
builder.Services.AddSwaggerGen();

// Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Đăng ký DbContext sử dụng SQL Server qua cơ chế Dependency Injection (DI)
builder.Services.AddDbContext<SupermarketDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Sử dụng Swagger khi đang trong quá trình phát triển (Development)
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Bắt buộc gọi UseAuthentication trước UseAuthorization để hệ thống có thể xác thực người dùng trước khi cấp quyền
app.UseAuthentication(); // <-- Thêm dòng này để kích hoạt Authentication (Xác thực JWT)
app.UseAuthorization();  // Kích hoạt Authorization (Phân quyền)

app.MapControllers();
app.Run();
