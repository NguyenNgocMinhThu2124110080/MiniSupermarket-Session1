using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    public static class Bai2
    {
        public static void Run()
        {
            string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            Console.WriteLine("=== BÀI TẬP 2: CẬP NHẬT TỒN KHO AN TOÀN VỚI SQLPARAMETER ===");
            int maSanPhamCanSua = 1;
            int soLuongTonKhoMoi = 250;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    string updateSql = @"UPDATE Products 
                                         SET StockQuantity = @Stock 
                                         WHERE ProductId = @Id";
                    using (SqlCommand command = new SqlCommand(updateSql, connection))
                    {
                        command.Parameters.AddWithValue("@Stock", soLuongTonKhoMoi);
                        command.Parameters.AddWithValue("@Id", maSanPhamCanSua);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
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
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}

