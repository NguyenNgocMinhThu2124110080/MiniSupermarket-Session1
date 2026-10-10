using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Chuỗi kết nối trỏ tới CSDL MiniSupermarketDb
            string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            Console.WriteLine("=== BÀI TẬP 1: ĐẾM TỔNG SỐ LƯỢNG MẶT HÀNG ===");

            // 2. Khởi tạo đối tượng SqlConnection trong khối using để tự động giải phóng
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // 3. Câu lệnh SQL đếm toàn bộ số dòng trong bảng Products
                    string query = "SELECT COUNT(*) FROM Products";

                    // 4. Khởi tạo đối tượng SqlCommand gắn câu lệnh với kết nối
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 5. Bắt buộc phải mở kết nối trước khi thực thi
                        connection.Open();
                        Console.WriteLine("-> Đã kết nối thành công tới SQL Server!");

                        // 6. ExecuteScalar() trả về một đối tượng kiểu object
                        // Cần ép kiểu tường minh sang kiểu int
                        object result = command.ExecuteScalar();
                        int totalCount = Convert.ToInt32(result);

                        // 7. Hiển thị kết quả ra màn hình
                        Console.WriteLine($"-> Tổng số mặt hàng hiện có trong kho siêu thị: {totalCount} sản phẩm.");
                    }
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi nếu sai chuỗi kết nối hoặc sai tên bảng CSDL
                    Console.WriteLine($"[LỖI SQL]: Không thể truy vấn CSDL. Chi tiết: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Xử lý các lỗi ngoại lệ chung
                    Console.WriteLine($"[LỖI HỆ THỐNG]: {ex.Message}");
                }
            } // Kết thúc using, connection.Close() và connection.Dispose() tự động được gọi

            Console.WriteLine("-> Nhấn phím bất kỳ để thoát (hoặc Enter để tiếp tục)...");
            Console.ReadLine();
        }
    }
}
