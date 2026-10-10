/*
 * Ho ten sinh vien: Nguyen Ngoc Minh Thu
 * Ma sinh vien: 2124110080
 * Mo ta: Chuong trinh kiem chung co che Rollback cua SqlTransaction
 */
using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhTransaction_Tiet4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=MiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;";

            Console.WriteLine("=== THỬ NGHIỆM ĐIỀU KHIỂN SQLTRANSACTION ===");

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                // 1. Khởi tạo Transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    Console.WriteLine("-> Bắt đầu phiên giao dịch...");

                    // 2. Thao tác 1: Trừ 5 đơn vị tồn kho của Sản phẩm ID = 1 (Hợp lệ)
                    string sqlStep1 = "UPDATE Products SET StockQuantity = StockQuantity - @Qty WHERE ProductId = @Id";
                    using (SqlCommand cmd1 = new SqlCommand(sqlStep1, connection, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@Qty", 5);
                        cmd1.Parameters.AddWithValue("@Id", 1);
                        int r1 = cmd1.ExecuteNonQuery();
                        Console.WriteLine($"-> Bước 1: Đã trừ tồn kho SP 1 (Số dòng tác động: {r1}).");
                    }

                    // 3. Thao tác 2: Cố tình gây lỗi cú pháp SQL hoặc cập nhật sản phẩm không hợp lệ
                    Console.WriteLine("-> Bước 2: Chuẩn bị thực thi thao tác lỗi giả lập...");
                    
                    // Giả lập tình huống kiểm tra logic bị lỗi: Ném ngoại lệ thủ công
                    bool isInventoryShortage = true; // Giả lập mặt hàng thứ 2 bị hết kho
                    if (isInventoryShortage)
                    {
                        throw new InvalidOperationException("Mặt hàng thứ hai đã hết tồn kho thực tế!");
                    }

                    // 4. Nếu không có lỗi thì mới Commit
                    transaction.Commit();
                    Console.WriteLine("-> GIAO DỊCH COMMIT THÀNH CÔNG!");
                }
                catch (Exception ex)
                {
                    // 5. Khi bắt được lỗi -> Lập tức Rollback
                    Console.WriteLine($"\n[PHÁT SINH LỖI]: {ex.Message}");
                    transaction.Rollback();
                    Console.WriteLine("-> [HỆ THỐNG]: Đã kích hoạt transaction.Rollback()!");
                    Console.WriteLine("-> Toàn bộ thay đổi của Bước 1 đã được hoàn trả, tồn kho SP 1 không bị trừ!");
                }
            }

            Console.WriteLine("\n-> Nhấn phím bất kỳ để kết thúc Tiết 4...");
            Console.ReadKey();
        }
    }
}
