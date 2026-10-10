using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    public static class Bai3
    {
        public static void Run()
        {
            string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            Console.WriteLine("=== BÀI TẬP 3: DUYỆT DANH SÁCH BẰNG SQLDATAREADER ===");
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                     FROM Products 
                                     ORDER BY ProductId ASC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                            Console.WriteLine(string.Format("{0,-6} | {1,-14} | {2,-35} | {3,12} | {4,8}", 
                                "MÃ SP", "MÃ VẠCH", "TÊN SẢN PHẨM", "ĐƠN GIÁ", "TỒN KHO"));
                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                            int stt = 0;
                            while (reader.Read())
                            {
                                stt++;
                                int id = Convert.ToInt32(reader["ProductId"]);
                                string barcode = reader["Barcode"].ToString() ?? "";
                                string name = reader["ProductName"].ToString() ?? "";
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int stock = Convert.ToInt32(reader["StockQuantity"]);
                                Console.WriteLine(string.Format("{0,-6} | {1,-14} | {2,-35} | {3,12:N0} đ | {4,8}", 
                                    id, barcode, name, price, stock));
                            }
                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                            Console.WriteLine($"-> Tổng cộng đã đọc thành công: {stt} mặt hàng từ SQL Server.");
                        }
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

