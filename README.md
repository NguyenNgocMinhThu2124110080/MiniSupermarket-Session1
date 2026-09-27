# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)
> **Buổi thực hành:** Buổi 3 - Tích hợp SQL Server, Entity Framework Core Code-First và Quản lý khách hàng

---

## 👨‍🎓 1. Thông tin sinh viên

* **Họ và tên:** Nguyễn Ngọc Minh Thư
* **MSSV:** 2124110080
* **Lớp:** CCQ2411C

---

## 🏗️ 2. Mô hình hệ thống

Dự án gồm 2 phần chính:

* **`MiniSupermarket.API` (Backend):** ASP.NET Core Web API xử lý dữ liệu và cung cấp API.
* **`MiniSupermarket.WinForms` (Frontend):** Windows Forms sử dụng `HttpClient` để gọi API và hiển thị dữ liệu.

---

## 🛠️ 3. Công nghệ sử dụng

* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API
* **Frontend:** Windows Forms
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core
* **Kiểm thử:** Swagger UI
* **Truy vấn:** LINQ, async/await

---

## 📌 4. Buổi 3 đã đạt được gì?

Trong Buổi 3, hệ thống được nâng cấp từ lưu dữ liệu **In-Memory** sang lưu dữ liệu bằng **SQL Server**.

Các nội dung đã thực hiện:

* Cài đặt các gói Entity Framework Core.
* Tạo và cấu hình Entity `Category`, `Product`.
* Tạo `SupermarketDbContext`.
* Kết nối ASP.NET Core Web API với SQL Server.
* Tạo Database bằng **EF Core Code-First**.
* Sử dụng **EF Core Migrations**.
* Thực hiện CRUD nhóm hàng trên SQL Server.
* Sử dụng LINQ và `async/await`.
* Kiểm tra API bằng Swagger.
* Kết nối và kiểm tra dữ liệu từ WinForms.
* Đảm bảo dữ liệu vẫn còn sau khi tắt và chạy lại ứng dụng.

---

## 👥 5. Bài tập mở rộng – Quản lý khách hàng

Buổi 3 có thêm bài tập mở rộng xây dựng phân hệ **Customers – Quản lý khách hàng**.

Các nội dung thực hiện:

* Tạo Model `Customer`.
* Thêm `Customers` vào `SupermarketDbContext`.
* Thêm dữ liệu khách hàng mẫu bằng Data Seeding.
* Tạo Migration cho bảng `Customers`.
* Xây dựng `CustomersController`.
* Thực hiện CRUD khách hàng.
* Tìm kiếm khách hàng theo tên hoặc số điện thoại.
* Xây dựng giao diện `FormCustomerManagement` trên WinForms.
* Kết nối WinForms với API Customers.

### Các chức năng quản lý khách hàng

```text
GET    /api/customers
GET    /api/customers/{id}
GET    /api/customers/search?keyword=...
POST   /api/customers
PUT    /api/customers/{id}
DELETE /api/customers/{id}
```

---

## 🔄 6. Buổi 3 khác Buổi 2

| Buổi 2                      | Buổi 3                            |
| --------------------------- | --------------------------------- |
| Lưu dữ liệu In-Memory       | Lưu dữ liệu bằng SQL Server       |
| Dữ liệu tạm thời            | Dữ liệu được lưu lâu dài          |
| Chưa sử dụng EF Core        | Sử dụng Entity Framework Core     |
| Chưa có Database thực tế    | Có Database `MiniSupermarketDb`   |
| CRUD trên dữ liệu trong RAM | CRUD trực tiếp trên SQL Server    |
| Chưa có phân hệ Customers   | Có thêm bài tập quản lý Customers |

---

## 🗄️ 7. Cơ sở dữ liệu

Tên Database:

```text
MiniSupermarketDb
```

Các bảng được sử dụng:

```text
Categories
Products
Customers
```

Dữ liệu được lưu trực tiếp trên SQL Server nên vẫn tồn tại sau khi tắt và khởi động lại API.

---

## 🚀 8. Hướng dẫn chạy dự án

### Bước 1: Chạy Backend

1. Mở Solution bằng **Visual Studio 2022**.
2. Chọn `MiniSupermarket.API` làm Startup Project.
3. Nhấn **F5** để chạy Web API.
4. Mở Swagger UI để kiểm tra các API.

### Bước 2: Chạy WinForms

1. Đảm bảo Web API đang chạy.
2. Kiểm tra địa chỉ API trong project WinForms.
3. Chạy `MiniSupermarket.WinForms`.
4. Kiểm tra các chức năng quản lý nhóm hàng và khách hàng.

---

## 📚 9. Kiến thức đạt được

* Kết nối ASP.NET Core Web API với SQL Server.
* Sử dụng Entity Framework Core Code-First.
* Sử dụng EF Core Migrations.
* Sử dụng DbContext và DbSet.
* Sử dụng LINQ.
* Sử dụng `async/await`.
* Thực hiện CRUD với SQL Server.
* Xây dựng quan hệ giữa các Entity.
* Seed dữ liệu ban đầu.
* Xây dựng API quản lý khách hàng.
* Kết nối Backend với WinForms.
