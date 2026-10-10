using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    public static class Bai1
    {
        public static void Run()
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
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}

