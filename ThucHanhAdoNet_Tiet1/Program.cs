using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bài tập 1
            RunBaiTap1();
            
            Console.WriteLine("\n------------------------------------------------\n");

            // Bài tập 2
            RunBaiTap2();
            
            Console.WriteLine("\n-> Nhấn Enter để thoát...");
            Console.ReadLine();
        }

        static void RunBaiTap1()
        {
            string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            Console.WriteLine("=== BÀI TẬP 1: ĐẾM TỔNG SỐ LƯỢNG MẶT HÀNG ===");

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Products";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        Console.WriteLine("-> Đã kết nối thành công tới SQL Server!");

                        object result = command.ExecuteScalar();
                        int totalCount = Convert.ToInt32(result);

                        Console.WriteLine($"-> Tổng số mặt hàng hiện có trong kho siêu thị: {totalCount} sản phẩm.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"[LỖI SQL]: {ex.Message}");
                }
            }
        }

        static void RunBaiTap2()
        {
            string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            Console.WriteLine("=== BÀI TẬP 2: CẬP NHẬT TỒN KHO AN TOÀN VỚI SQLPARAMETER ===");

            // Giả lập thông tin do nhân viên nhập từ bàn phím
            int maSanPhamCanSua = 1;      // Mã sản phẩm Snack O'Star (hoặc SP ID = 1)
            int soLuongTonKhoMoi = 250;    // Số lượng kiểm kê mới nhập kho

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // 1. Viết câu lệnh UPDATE có chứa 2 tham số @Stock và @Id (Tuyệt đối không cộng chuỗi)
                    string updateSql = @"UPDATE Products 
                                         SET StockQuantity = @Stock 
                                         WHERE ProductId = @Id";

                    using (SqlCommand command = new SqlCommand(updateSql, connection))
                    {
                        // 2. Gán giá trị an toàn vào tham số thông qua AddWithValue
                        command.Parameters.AddWithValue("@Stock", soLuongTonKhoMoi);
                        command.Parameters.AddWithValue("@Id", maSanPhamCanSua);

                        // 3. Mở kết nối
                        connection.Open();

                        // 4. Thực thi ExecuteNonQuery() để nhận về số dòng bị thay đổi trong CSDL
                        int rowsAffected = command.ExecuteNonQuery();

                        // 5. Kiểm tra kết quả thực thi
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"-> THÀNH CÔNG: Đã cập nhật tồn kho cho Sản phẩm ID = {maSanPhamCanSua} thành {soLuongTonKhoMoi} đơn vị.");
                            Console.WriteLine($"-> Số dòng dữ liệu bị ảnh hưởng: {rowsAffected} dòng.");
                        }
                        else
                        {
                            Console.WriteLine($"-> CẢNH BÁO: Không tìm thấy sản phẩm có ID = {maSanPhamCanSua} để cập nhật.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"[LỖI SQL]: {ex.Message}");
                }
            }
        }
    }
}
