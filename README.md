🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)
Buổi thực hành: Buổi 3 - Tích hợp SQL Server và Entity Framework Core Code-First

👨‍🎓 1. Thông tin sinh viên
Họ và tên: Nguyễn Ngọc Minh Thư
MSSV: 2124110080
Lớp: CCQ2411C
🏗️ 2. Mô hình hệ thống

Dự án gồm 2 phần chính:

MiniSupermarket.API (Backend): ASP.NET Core Web API xử lý dữ liệu và cung cấp API.
MiniSupermarket.WinForms (Frontend): Windows Forms sử dụng HttpClient để gọi API và hiển thị dữ liệu.
🛠️ 3. Công nghệ sử dụng
Ngôn ngữ: C# (.NET 8.0)
Backend: ASP.NET Core Web API
Frontend: Windows Forms
Database: Microsoft SQL Server
ORM: Entity Framework Core
Kiểm thử: Swagger UI
Truy vấn: LINQ, async/await
📌 4. Buổi 3 đã đạt được gì?

Trong Buổi 3, hệ thống được nâng cấp từ lưu dữ liệu In-Memory sang lưu dữ liệu bằng SQL Server.

Các nội dung đã thực hiện:

Cài đặt các gói Entity Framework Core.
Tạo Entity Category và Product.
Tạo SupermarketDbContext.
Kết nối ASP.NET Core Web API với SQL Server.
Tạo cơ sở dữ liệu bằng EF Core Code-First.
Sử dụng Migration với Add-Migration và Update-Database.
Thêm dữ liệu mẫu bằng Data Seeding.
Thực hiện CRUD nhóm hàng trên SQL Server.
Sử dụng LINQ và async/await.
Kiểm tra API bằng Swagger.
Kết nối và kiểm tra dữ liệu từ WinForms.
🔄 5. Buổi 3 khác Buổi 2 như thế nào?
Buổi 2	Buổi 3
Dữ liệu lưu tạm trên RAM (In-Memory)	Dữ liệu lưu trong SQL Server
Dữ liệu có thể mất khi tắt API	Dữ liệu được lưu lâu dài
Chưa sử dụng EF Core	Sử dụng Entity Framework Core
Chưa có Database thực tế	Có Database MiniSupermarketDb
Xử lý dữ liệu trong code	Truy vấn dữ liệu bằng EF Core và LINQ
CRUD trên dữ liệu tạm	CRUD trực tiếp với SQL Server
🚀 6. Hướng dẫn chạy dự án
Bước 1: Chạy Backend
Mở Solution bằng Visual Studio 2022.
Chọn project MiniSupermarket.API làm Startup Project.
Nhấn F5 để chạy Web API.
Mở Swagger UI để kiểm tra các API.
Bước 2: Chạy WinForms
Đảm bảo Web API đang chạy.
Kiểm tra địa chỉ API trong project WinForms.
Chạy project MiniSupermarket.WinForms.
Kiểm tra các chức năng thêm, sửa, xóa, tìm kiếm và hiển thị nhóm hàng.
🗄️ 7. Cơ sở dữ liệu

Tên Database:

MiniSupermarketDb

Các bảng chính:

Categories
Products

Dữ liệu được lưu trữ trong SQL Server nên vẫn tồn tại sau khi tắt và chạy lại chương trình.