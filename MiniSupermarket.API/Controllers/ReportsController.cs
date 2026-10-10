/*
 * Ho ten sinh vien: Nguyen Ngoc Minh Thu
 * Ma sinh vien: 2124110080
 * Ngay tao: 10/10/2026
 * Mo ta: Controller ADO.NET thuc thi Stored Procedure xuat bao cao ca ban, kem bai tap 3.1 va 3.2
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiniSupermarket.API.Models;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Dependency Injection lay chuoi ket noi tu appsettings.json
        public ReportsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // GET: api/reports/revenue-by-cashier
        // Chuc nang: Goi Stored Procedure sp_GetRevenueByCashier qua SqlDataReader
        // =========================================================================
        [HttpGet("revenue-by-cashier")]
        public IActionResult GetRevenueByCashier()
        {
            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 1. Khoi tao SqlConnection trong khoi using dam bao tu dong dong ket noi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 2. Gan CommandText la CHINH XAC ten Stored Procedure tren SQL Server
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByCashier", connection))
                {
                    // 3. DIEM KHOA HOC QUAN TRONG: Thiet lap CommandType la StoredProcedure
                    // Neu thieu dong nay, SQL Server se hieu nham day la chuoi SQL thuong va bao loi cu phap!
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        // 4. Mo ket noi vat ly toi SQL Server
                        connection.Open();

                        // 5. Thuc thi bang ExecuteReader(): Nhan ve luong du lieu forward-only
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 6. Vong lap doc tung dong ket qua cua Stored Procedure
                            while (reader.Read())
                            {
                                // Anh xa tung cot du lieu tu reader vao doi tuong DTO
                                var item = new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value 
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"]) 
                                        : 0
                                };

                                reportList.Add(item);
                            }
                        } // reader tu dong Close() tai day
                    }
                    catch (SqlException ex)
                    {
                        // Bat loi neu quen tao Stored Procedure tren CSDL hoac sai chuoi ket noi
                        return StatusCode(500, new 
                        { 
                            success = false,
                            message = "Lỗi thực thi Stored Procedure trên SQL Server: " + ex.Message 
                        });
                    }
                }
            } // connection tu dong Close() va Dispose() tai day

            // 7. Tra ve ma 200 OK kem danh sach bao cao da tong hop
            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.1: Stored Procedure Báo cáo Doanh thu theo Khoảng ngày (Có tham số)
        // =========================================================================
        [HttpGet("revenue-by-date")]
        public IActionResult GetRevenueByDateRange([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var reportList = new List<object>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByDateRange", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reportList.Add(new
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new { success = false, message = ex.Message });
                    }
                }
            }
            return Ok(new { data = reportList });
        }

        // =========================================================================
        // BÀI TẬP 3.2: Stored Procedure Top 5 Sản phẩm Bán chạy nhất
        // =========================================================================
        [HttpGet("top-5-products")]
        public IActionResult GetTop5SellingProducts()
        {
            var resultList = new List<object>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetTop5SellingProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                resultList.Add(new
                                {
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    TotalSold = Convert.ToInt32(reader["TotalSold"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new { success = false, message = ex.Message });
                    }
                }
            }
            return Ok(new { data = resultList });
        }
    }
}
