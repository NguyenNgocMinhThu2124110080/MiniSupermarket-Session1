
# 🛒 BÁCH HÓA TỔNG HỢP HOÀNG DUNG

## Xây dựng Ứng dụng Quản lý Cửa hàng Tiện lợi với ASP.NET Core và Windows Forms

**Môn học:** Lập trình Ứng dụng .NET Core  
**Mã môn:** 229162  
**Buổi:** 5  
**Nội dung:** ADO.NET nâng cao, Stored Procedure và giao dịch thanh toán POS

---

## 1. Thông tin sinh viên

- **Họ và tên:** Nguyễn Ngọc Minh Thư
- **MSSV:** 2124110080
- **Lớp:** CCQ2411C

---

## 2. Giới thiệu

Buổi 5 tập trung nâng cao kỹ năng truy xuất dữ liệu SQL Server bằng ADO.NET, tối ưu truy vấn và đảm bảo tính toàn vẹn dữ liệu trong nghiệp vụ bán hàng.

Các nội dung chính gồm:

- Sử dụng ADO.NET để kết nối và thao tác SQL Server.
- Tra cứu sản phẩm bằng mã vạch Barcode.
- Tạo Stored Procedure thống kê doanh thu.
- Áp dụng nguyên tắc ACID và `SqlTransaction`.
- Xây dựng API thanh toán POS có cơ chế `Commit` và `Rollback`.

## 3. Công nghệ sử dụng

- C# và .NET
- ASP.NET Core Web API
- Windows Forms (WinForms)
- Microsoft SQL Server
- ADO.NET (`SqlConnection`, `SqlCommand`, `SqlParameter`, `SqlDataReader`)
- Stored Procedure
- Swagger UI

---

## 4. Nội dung thực hiện

### 4.1. ADO.NET cơ bản

Tìm hiểu các thành phần chính:

| Thành phần | Chức năng |
|---|---|
| `SqlConnection` | Kết nối SQL Server |
| `SqlCommand` | Thực thi câu lệnh SQL |
| `SqlParameter` | Truyền tham số an toàn |
| `SqlDataReader` | Đọc dữ liệu từng dòng |
| `DataTable` | Lưu dữ liệu dạng bảng trên RAM |

Phân biệt ba phương thức thực thi:

- `ExecuteScalar()`: Lấy một giá trị đơn.
- `ExecuteNonQuery()`: Thêm, sửa hoặc xóa dữ liệu.
- `ExecuteReader()`: Đọc nhiều dòng dữ liệu.

Sử dụng `SqlParameter` để hạn chế nguy cơ SQL Injection.

### 4.2. Tra cứu sản phẩm bằng Barcode

Xây dựng API tra cứu sản phẩm trực tiếp bằng ADO.NET và `SqlDataReader`.

Endpoint:

```http
GET /api/ado-products/barcode/{barcode}
```

Kết quả trả về thông tin sản phẩm như mã vạch, tên sản phẩm, giá bán và số lượng tồn kho. Nếu không tìm thấy sản phẩm, API trả về `404 Not Found`.

### 4.3. Stored Procedure báo cáo doanh thu

Tạo Stored Procedure `sp_GetRevenueByCashier` trên SQL Server để tổng hợp dữ liệu theo nhân viên thu ngân.

Thông tin thống kê gồm:

- Tên tài khoản thu ngân.
- Tổng số hóa đơn.
- Tổng doanh thu.
- Tổng điểm thưởng đã cấp.

Endpoint:

```http
GET /api/Reports/revenue-by-cashier
```

API sử dụng `CommandType.StoredProcedure` và `SqlDataReader` để lấy dữ liệu báo cáo, sau đó trả về JSON cho client.

### 4.4. Giao dịch dữ liệu và chuẩn ACID

Tìm hiểu bốn đặc tính của giao dịch cơ sở dữ liệu:

- **Atomicity:** Tất cả thao tác thành công hoặc cùng bị hủy.
- **Consistency:** Dữ liệu luôn đảm bảo tính nhất quán.
- **Isolation:** Các giao dịch được cô lập với nhau.
- **Durability:** Dữ liệu được lưu bền vững sau khi xác nhận.

Sử dụng `SqlTransaction` với ba thao tác chính:

- `BeginTransaction()`: Bắt đầu giao dịch.
- `Commit()`: Xác nhận lưu dữ liệu.
- `Rollback()`: Hoàn tác dữ liệu khi có lỗi.

### 4.5. API thanh toán POS

Xây dựng API thanh toán hóa đơn với quy trình:

1. Tạo hóa đơn trong bảng `Orders`.
2. Lưu chi tiết sản phẩm vào `OrderDetails`.
3. Kiểm tra và trừ số lượng tồn kho trong `Products`.
4. Cộng điểm thưởng cho khách hàng trong `Customers`.
5. `Commit` khi toàn bộ thao tác thành công; `Rollback` khi xảy ra lỗi.

Endpoint:

```http
POST /api/checkout
```

API sử dụng `SqlTransaction` để đảm bảo các thao tác thanh toán được thực hiện đồng bộ, tránh tình trạng hóa đơn đã tạo nhưng tồn kho hoặc chi tiết đơn hàng chưa được cập nhật.

---

## 5. Kiểm thử chương trình

Kiểm thử các API bằng Swagger UI và đối chiếu dữ liệu trực tiếp trên SQL Server Management Studio (SSMS).

| Trường hợp | Kết quả mong đợi |
|---|---|
| Tra cứu Barcode hợp lệ | `200 OK` |
| Barcode không tồn tại | `404 Not Found` |
| Lấy báo cáo doanh thu | `200 OK` |
| Thanh toán hợp lệ | `200 OK`, dữ liệu được lưu |
| Mua vượt quá tồn kho | `400 Bad Request`, giao dịch được Rollback |

Khi thanh toán thất bại, cần kiểm tra để đảm bảo hóa đơn, chi tiết đơn hàng, tồn kho và điểm thưởng không bị thay đổi một phần.

---

## 6. Kết quả và kiến thức đạt được

Sau Buổi 5, sinh viên được thực hành:

- Kết nối và truy vấn SQL Server bằng ADO.NET.
- Sử dụng tham số SQL an toàn.
- Tra cứu sản phẩm theo Barcode.
- Xây dựng Stored Procedure và API báo cáo doanh thu.
- Hiểu nguyên tắc ACID và điều khiển giao dịch.
- Xây dựng API thanh toán POS có xử lý lỗi và Rollback.
- Kiểm tra tính toàn vẹn dữ liệu bằng Swagger và SSMS.

---

## 7. Checklist kiểm tra

- [ ] Thực hành `ExecuteScalar()`, `ExecuteNonQuery()` và `ExecuteReader()`.
- [ ] Kiểm thử API tra cứu Barcode.
- [ ] Tạo và gọi Stored Procedure báo cáo doanh thu.
- [ ] Hiểu và áp dụng `BeginTransaction()`, `Commit()` và `Rollback()`.
- [ ] Kiểm thử API thanh toán POS thành công.
- [ ] Kiểm thử trường hợp mua vượt quá tồn kho và xác nhận Rollback.
- [ ] Đối chiếu dữ liệu sau giao dịch trên SQL Server. reamde ok ko
