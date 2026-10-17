# 🛒 BÁCH HÓA TỔNG HỢP HOÀNG DUNG

## Xây dựng Ứng dụng Quản lý Cửa hàng Tiện lợi với ASP.NET Core và Windows Forms

**Môn học:** Lập trình Ứng dụng .NET Core  
**Mã môn học:** 229162  
**Buổi thực hành:** Buổi 6  
**Nội dung:** Entity Framework Core nâng cao, phân trang LINQ và tích hợp hệ thống POS Client – Server  

---

## 1. THÔNG TIN SINH VIÊN

- **Họ và tên:** Nguyễn Ngọc Minh Thư
- **Mã số sinh viên:** 2124110080
- **Lớp:** CCQ2411C
- **Đề tài:** Bách hóa Tổng hợp Hoàng Dung
- **Dự án:** MiniSupermarket

---

## 2. GIỚI THIỆU

Buổi 6 tiếp tục phát triển hệ thống quản lý cửa hàng tiện lợi MiniSupermarket, tập trung vào tối ưu truy vấn dữ liệu sản phẩm và kết nối giữa ứng dụng Windows Forms với ASP.NET Core Web API.

Hệ thống sử dụng Entity Framework Core để truy xuất dữ liệu SQL Server, hỗ trợ tìm kiếm, phân trang sản phẩm và hiển thị dữ liệu trực tiếp trên giao diện WinForms.

---

## 3. CÔNG NGHỆ SỬ DỤNG

- **Ngôn ngữ:** C#
- **Backend:** ASP.NET Core Web API
- **Frontend:** Windows Forms (WinForms)
- **Cơ sở dữ liệu:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Truy vấn:** LINQ, Eager Loading
- **Giao tiếp:** HttpClient, JSON
- **Bảo mật:** JWT Bearer Token
- **Kiểm thử API:** Swagger UI
- **IDE:** Visual Studio

---

## 4. NỘI DUNG THỰC HIỆN BUỔI 6

### 4.1. Entity Framework Core nâng cao

Áp dụng các kỹ thuật truy vấn dữ liệu:

- `Include()` để lấy thông tin nhóm hàng liên quan đến sản phẩm.
- `ThenInclude()` để tải các quan hệ lồng nhau khi cần.
- `AsNoTracking()` để tối ưu truy vấn chỉ đọc.
- `CountAsync()` để đếm số sản phẩm.
- `ToListAsync()` để lấy danh sách bất đồng bộ.

Giúp hạn chế truy vấn không cần thiết và cải thiện hiệu suất xử lý dữ liệu.

### 4.2. Xây dựng API tìm kiếm và phân trang sản phẩm

**Endpoint:**

`GET /api/products/paged`

**Tham số:**

| Tham số | Chức năng |
|---|---|
| `keyword` | Tìm theo tên sản phẩm hoặc mã vạch |
| `pageNumber` | Số trang hiện tại |
| `pageSize` | Số sản phẩm trên mỗi trang |

Áp dụng LINQ:

- `Where()` và `Contains()` để tìm kiếm.
- `OrderBy()` để sắp xếp sản phẩm.
- `Skip()` để bỏ qua các sản phẩm thuộc trang trước.
- `Take()` để lấy số lượng sản phẩm cần hiển thị.

**Ví dụ:**

`GET /api/products/paged?pageNumber=1&pageSize=10`

API trả về dữ liệu gồm:

- `CurrentPage`: Trang hiện tại.
- `PageSize`: Số sản phẩm mỗi trang.
- `TotalItems`: Tổng số sản phẩm.
- `TotalPages`: Tổng số trang.
- `Items`: Danh sách sản phẩm của trang hiện tại.

### 4.3. Tạo DTO dữ liệu phân trang

Bổ sung các lớp DTO:

- `ProductItemDto`: Chứa thông tin sản phẩm và tên nhóm hàng (`CategoryName`).
- `PagedResult<T>`: Đóng gói danh sách sản phẩm cùng thông tin phân trang.

Việc sử dụng DTO giúp dữ liệu API trả về rõ ràng, dễ xử lý và phù hợp với giao diện WinForms.

### 4.4. Kết nối WinForms với Web API

Sử dụng lớp `ApiClientService` / `SessionManager` để quản lý `HttpClient` dùng chung.

Các chức năng chính:

- Thiết lập địa chỉ Web API (`https://localhost:7006/api/`).
- Gửi HTTP Request đến Backend.
- Nhận dữ liệu JSON.
- Đính kèm JWT Bearer Token khi cần xác thực.
- Sử dụng `async/await` để tránh treo giao diện.

### 4.5. Hoàn thiện giao diện quản lý sản phẩm

**FormProductManagement** được phát triển với các chức năng:

- Hiển thị danh sách sản phẩm bằng `DataGridView` với layout chuẩn cân đối (chiều cao dòng 30px, tiêu đề 34px).
- Tải danh mục sản phẩm vào `ComboBox`.
- Tìm kiếm sản phẩm theo tên hoặc mã vạch.
- Phân trang danh sách sản phẩm (10 sản phẩm/trang).
- Chuyển trang trước (`<< Trang trước`) và trang sau (`Trang sau >>`).
- Thêm sản phẩm mới.
- Cập nhật thông tin sản phẩm.
- Xóa sản phẩm.
- Đồng bộ dữ liệu với SQL Server thông qua Web API.

### 4.6. Tối ưu hiệu suất hệ thống

Thay vì tải toàn bộ sản phẩm, hệ thống chỉ lấy dữ liệu theo từng trang.

Lợi ích:

- Giảm lượng dữ liệu truyền qua mạng.
- Tiết kiệm bộ nhớ.
- Tăng tốc độ hiển thị.
- Giúp giao diện WinForms hoạt động mượt mà hơn.
- Phù hợp khi cửa hàng có số lượng sản phẩm lớn.

---

## 5. KIỂM THỬ CHỨC NĂNG

| STT | Chức năng | Kết quả mong đợi |
|---|---|---|
| 1 | Gọi API phân trang | Trả về HTTP 200 và dữ liệu phân trang |
| 2 | Hiển thị tên nhóm hàng | Có trường `CategoryName` |
| 3 | Tìm kiếm sản phẩm | Trả về sản phẩm phù hợp từ khóa |
| 4 | Chuyển trang | Hiển thị đúng dữ liệu trang được chọn |
| 5 | Thêm sản phẩm | Lưu sản phẩm vào SQL Server |
| 6 | Cập nhật sản phẩm | Thông tin được thay đổi trong CSDL |
| 7 | Xóa sản phẩm | Xóa sản phẩm và cập nhật danh sách |

**Dữ liệu mẫu:** Sản phẩm thuộc các nhóm ngành hàng trong siêu thị, sử dụng để kiểm tra tìm kiếm và phân trang.

---

## 6. KẾT QUẢ VÀ KIẾN THỨC ĐẠT ĐƯỢC

Thông qua Buổi 6, sinh viên thực hành:

- Sử dụng Entity Framework Core với Eager Loading (`Include`).
- Xây dựng API tìm kiếm và phân trang bằng LINQ (`Skip`, `Take`, `CountAsync`).
- Sử dụng DTO để chuẩn hóa dữ liệu trả về.
- Kết nối WinForms với ASP.NET Core Web API bằng `HttpClient`.
- Xử lý dữ liệu bất đồng bộ bằng `async/await`.
- Tích hợp JWT Bearer Token vào HTTP Request.
- Xây dựng giao diện quản lý sản phẩm có phân trang, layout cân đối, chuyên nghiệp.
- Tối ưu việc truy xuất dữ liệu từ SQL Server.

---

## 7. HƯỚNG DẪN CHẠY DỰ ÁN

1. Mở solution `MiniSupermarket.API.sln` bằng Visual Studio.
2. Kiểm tra chuỗi kết nối SQL Server trong `appsettings.json`.
3. Đảm bảo cơ sở dữ liệu đã được tạo và có dữ liệu mẫu.
4. Khởi chạy project `MiniSupermarket.API`.
5. Kiểm tra API trên Swagger (`/swagger`).
6. Khởi chạy project `MiniSupermarketWinForms`.
7. Đăng nhập và mở màn hình quản lý sản phẩm.
8. Kiểm tra tìm kiếm, phân trang và các thao tác quản lý sản phẩm.

---

## 8. NỘI DUNG MỞ RỘNG (ĐÃ HOÀN THIỆN)

Hệ thống đã triển khai nâng cao vượt yêu cầu cơ bản:

- **Phân trang khách hàng:** `GET /api/customers/paged` kết hợp tìm kiếm và phân trang trên WinForms `FormCustomerManagement`.
- **Phân trang danh mục ngành hàng:** `GET /api/categories/paged` kết hợp tìm kiếm và phân trang trên WinForms `FormCategoryManagement`.
- **Chuẩn hóa giao diện toàn hệ thống:** Đồng bộ tỷ lệ 70/30, chiều cao dòng 30px, tiêu đề 34px không ngắt dòng, thanh phân trang chân bảng và 4 nút tác vụ cân đối cho tất cả các phân hệ quản lý.

---

**Sinh viên thực hiện:** Nguyễn Ngọc Minh Thư  
**MSSV:** 2124110080  
**Lớp:** CCQ2411C  
**Dự án:** Bách hóa Tổng hợp Hoàng Dung – MiniSupermarket  
**Bài thực hành:** Buổi 6 – Entity Framework Core nâng cao, phân trang LINQ và tích hợp POS Client – Server
