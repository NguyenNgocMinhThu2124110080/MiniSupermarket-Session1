/*Nguyen Ngoc Minh Thu
 Mssv:2124110080
ngay sua them "19/9/2026*/
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
