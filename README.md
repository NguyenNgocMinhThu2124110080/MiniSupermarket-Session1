# 🛒 BÁCH HÓA TỔNG HỢP HOÀNG DUNG

## Xây dựng Ứng dụng Quản lý Cửa hàng Tiện lợi với ASP.NET Core và Windows Forms

> **Môn học:** Lập trình Ứng dụng .NET Core
> **Mã môn:** 229162
> **Buổi:** 4
> **Nội dung:** WinForms Shell, Sidebar, Main Workspace và phân quyền người dùng

---

## 👨‍🎓 1. Thông tin sinh viên

* **Họ và tên:** Nguyễn Ngọc Minh Thư
* **MSSV:** 2124110080
* **Lớp:** ....................................

---

## 🏪 2. Giới thiệu

Đề tài xây dựng hệ thống quản lý **Bách hóa Tổng hợp Hoàng Dung** với:

* **Backend:** ASP.NET Core Web API
* **Frontend:** Windows Forms
* **Database:** Microsoft SQL Server
* **Entity Framework Core**
* **Swagger**
* **RBAC – phân quyền người dùng**

Buổi 4 tập trung xây dựng giao diện quản lý tập trung và phân quyền theo 3 vai trò:

* **Admin**
* **Cashier**
* **Warehouse**

---

## 🎯 3. Mục tiêu Buổi 4

* Xây dựng `FormMainShell` theo mô hình **Single-Form Architecture**.
* Thiết kế **Sidebar** và **Main Workspace**.
* Nhúng Form con bằng `TopLevel = false`, `Dock = Fill`.
* Điều hướng giữa các màn hình nghiệp vụ.
* Hiển thị thông tin người dùng.
* Xây dựng **Role-Based Access Control (RBAC)**.

---

## 🖥️ 4. Kiến trúc giao diện

```text
┌──────────────────────────────────────────────────────┐
│                 FormMainShell                        │
├─────────────────┬────────────────────────────────────┤
│                 │                                    │
│   Sidebar       │       Main Workspace                │
│                 │                                    │
│   Bán hàng      │       Form nghiệp vụ               │
│   Danh mục      │                                    │
│   Sản phẩm      │                                    │
│   Khách hàng    │                                    │
│   Báo cáo       │                                    │
│   Tài khoản     │                                    │
│   Đăng xuất     │                                    │
│                 │                                    │
└─────────────────┴────────────────────────────────────┘
```

Các thành phần chính:

* `panelSidebar`: Thanh điều hướng.
* `panelTopHeader`: Tiêu đề và thông tin người dùng.
* `panelMainContent`: Vùng hiển thị Form nghiệp vụ.

Sidebar có chiều rộng **230px**, vùng nội dung sử dụng `Dock = Fill`.

---

## 🔄 5. Nhúng Form con

Các Form nghiệp vụ được nhúng vào `panelMainContent` thay vì mở thành nhiều cửa sổ riêng.

```csharp
childForm.TopLevel = false;
childForm.FormBorderStyle = FormBorderStyle.None;
childForm.Dock = DockStyle.Fill;
```

Hàm `OpenChildForm(...)` chịu trách nhiệm đóng Form đang mở và hiển thị Form mới.

---

## 👤 6. Phân quyền RBAC

| Vai trò       | Quyền truy cập                                          |
| ------------- | ------------------------------------------------------- |
| **Admin**     | POS, Danh mục, Sản phẩm, Khách hàng, Báo cáo, Tài khoản |
| **Cashier**   | POS, Khách hàng                                         |
| **Warehouse** | Danh mục, Sản phẩm                                      |

Phân quyền được xử lý trong `ApplyRolePermissions()` bằng cách hiển thị hoặc ẩn các nút trên Sidebar.

---

## 🔐 7. Tài khoản mẫu

| Username       | Mật khẩu | Vai trò   |
| -------------- | -------- | --------- |
| `admin01`      | `123456` | Admin     |
| `admin02`      | `123456` | Admin     |
| `cashier01`    | `123456` | Cashier   |
| `cashier02`    | `123456` | Cashier   |
| `cashier03`    | `123456` | Cashier   |
| `cashier04`    | `123456` | Cashier   |
| `cashier05`    | `123456` | Cashier   |
| `cashier06`    | `123456` | Cashier   |
| `ware01`       | `123456` | Warehouse |
| `ware02`       | `123456` | Warehouse |
| `ware03`       | `123456` | Warehouse |
| `ware04`       | `123456` | Warehouse |
| `ware05`       | `123456` | Warehouse |
| `admin_backup` | `123456` | Admin     |
| `supervisor`   | `123456` | Admin     |

---

## 🧩 8. Các Form nghiệp vụ

### FormPOS

Dành cho **Admin và Cashier**.

Chức năng:

* Tìm sản phẩm theo Barcode.
* Thêm sản phẩm vào giỏ hàng.
* Tính tổng tiền và tiền thừa.
* Nhập khách hàng thành viên.
* Thanh toán đơn hàng.

### FormProductManagement

Dành cho **Admin và Warehouse**.

Chức năng:

* Xem và tìm kiếm sản phẩm.
* Lọc theo nhóm hàng.
* Thêm, sửa, xóa sản phẩm.
* Quản lý giá bán và tồn kho.

### FormCustomerManagement

Dành cho **Admin và Cashier**.

Chức năng:

* Quản lý khách hàng.
* Tra cứu khách hàng.
* Quản lý thông tin khách hàng thân thiết.

### FormUserManagement

Dành cho **Admin**.

Chức năng:

* Xem danh sách tài khoản.
* Tạo tài khoản.
* Thiết lập mật khẩu và vai trò.
* Quản lý trạng thái tài khoản.

### FormQuickReport

Dành cho **Admin**.

Hiển thị:

* Tổng số hóa đơn.
* Tổng doanh thu.
* Mặt hàng bán chạy nhất.

---

## 🔗 9. Điều hướng

Các nút trên Sidebar mở Form tương ứng:

```text
Bán hàng       → FormPOS
Danh mục       → FormCategoryManagement
Sản phẩm       → FormProductManagement
Khách hàng     → FormCustomerManagement
Báo cáo        → FormQuickReport
Tài khoản       → FormUserManagement
```

Các Form được mở thông qua:

```csharp
OpenChildForm(...)
```

và hiển thị trong `panelMainContent`.

---

## 🧪 10. Kiểm thử phân quyền

### Cashier

```text
cashier01 / 123456

✓ Bán hàng
✓ Khách hàng
✗ Danh mục
✗ Sản phẩm
✗ Báo cáo
✗ Tài khoản
```

### Warehouse

```text
ware01 / 123456

✓ Danh mục
✓ Sản phẩm
✗ Bán hàng
✗ Khách hàng
✗ Báo cáo
✗ Tài khoản
```

### Admin

```text
admin01 / 123456

✓ Bán hàng
✓ Danh mục
✓ Sản phẩm
✓ Khách hàng
✓ Báo cáo
✓ Tài khoản
```

---

## 📈 11. Kết quả đạt được

Sau Buổi 4, hệ thống đã triển khai:

* `FormMainShell` và giao diện Sidebar.
* Main Workspace để hiển thị Form nghiệp vụ.
* Điều hướng giữa các Form.
* Nhúng Form con bằng `TopLevel = false` và `Dock = Fill`.
* Phân quyền Admin / Cashier / Warehouse.
* Màn hình POS.
* Quản lý sản phẩm.
* Quản lý khách hàng.
* Quản lý tài khoản.
* Form báo cáo doanh thu.

---

## 📚 12. Kiến thức đạt được

* Single-Form Architecture trong WinForms.
* Thiết kế giao diện bằng Panel và các Control.
* Nhúng và điều hướng Form con.
* Quản lý Session người dùng.
* Xây dựng RBAC.
* Phân quyền giao diện theo vai trò.
* Kết nối WinForms với ASP.NET Core Web API.
