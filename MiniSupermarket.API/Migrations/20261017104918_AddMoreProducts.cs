using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 21, "893456789021", 1, 18000m, "Bánh Quy Cosy Marie Gói 144g", 90 },
                    { 22, "893456789022", 1, 22000m, "Kẹo Alpenliebe Caramel Gói 120g", 70 },
                    { 23, "893456789023", 2, 19000m, "Nước Ngọt Pepsi Chai 1.5L", 120 },
                    { 24, "893456789024", 2, 18500m, "Bia Tiger Lon 330ml", 240 },
                    { 25, "893456789025", 3, 8000m, "Sữa Tươi TH True Milk 180ml", 150 },
                    { 26, "893456789026", 3, 26000m, "Sữa Đặc Ông Thọ Lon 380g", 110 },
                    { 27, "893456789027", 4, 8500m, "Mì Omachi Sườn Hầm Gói 80g", 260 },
                    { 28, "893456789028", 4, 6500m, "Cháo Gói Cây Thị Thịt Bằm 50g", 100 },
                    { 29, "893456789029", 5, 6000m, "Muối I-ốt Bạc Liêu Gói 500g", 120 },
                    { 30, "893456789030", 5, 26000m, "Đường Cát Trắng Biên Hòa Gói 1kg", 100 },
                    { 31, "893456789031", 6, 24000m, "Bột Mì Đa Dụng Meizan Gói 1kg", 60 },
                    { 32, "893456789032", 6, 28000m, "Đậu Xanh Hạt Gói 500g", 50 },
                    { 33, "893456789033", 6, 17000m, "Bún Khô Gói 500g", 18 },
                    { 34, "893456789034", 7, 125000m, "Nước Giặt OMO Matic Túi 2.4kg", 40 },
                    { 35, "893456789035", 7, 45000m, "Nước Lau Sàn Sunlight Hương Hoa 1L", 50 },
                    { 36, "893456789036", 8, 32000m, "Kem Đánh Răng P/S Bảo Vệ 123 Tuýp 180g", 85 },
                    { 37, "893456789037", 8, 135000m, "Sữa Tắm Lifebuoy Chai 850g", 35 },
                    { 38, "893456789038", 8, 9500m, "Xà Phòng Lux Cục 90g", 130 },
                    { 39, "893456789039", 9, 175000m, "Nồi Inox 3 Đáy Sunhouse 20cm", 20 },
                    { 40, "893456789040", 9, 69000m, "Hộp Đựng Thực Phẩm Lock&Lock 700ml", 30 },
                    { 41, "893456789041", 9, 99000m, "Bộ Dao Thớt Nhà Bếp 3 Món", 25 },
                    { 42, "893456789042", 10, 55000m, "Thùng Nhựa Đựng Đồ Có Nắp 20L", 30 },
                    { 43, "893456789043", 10, 189000m, "Cây Lau Nhà Xoay 360 Độ", 15 },
                    { 44, "893456789044", 10, 22000m, "Rổ Nhựa Tròn Đại", 60 },
                    { 45, "893456789045", 11, 4000m, "Bút Bi Thiên Long TL-027 Xanh", 500 },
                    { 46, "893456789046", 11, 85000m, "Giấy A4 Double A Ream 500 Tờ", 40 },
                    { 47, "893456789047", 11, 9000m, "Hồ Dán Khô UHU Thỏi 8g", 100 },
                    { 48, "893456789048", 12, 35000m, "Bóng Đèn LED Rạng Đông 9W", 75 },
                    { 49, "893456789049", 12, 120000m, "Ổ Cắm Điện Lioa 4 Lỗ 3m", 20 },
                    { 50, "893456789050", 12, 17000m, "Pin AAA Panasonic Vỉ 2 Viên", 12 },
                    { 51, "893456789051", 13, 62000m, "Cà Phê Trung Nguyên Sáng Tạo 1 Hộp 250g", 55 },
                    { 52, "893456789052", 13, 56000m, "Bột Ngũ Cốc Nestlé Milo Hộp 285g", 65 },
                    { 53, "893456789053", 13, 59000m, "Yến Mạch Quaker Hộp 400g", 40 },
                    { 54, "893456789054", 14, 150000m, "Tã Quần Bobby Size L 20 Miếng", 30 },
                    { 55, "893456789055", 14, 32000m, "Khăn Ướt Bobby Gói 80 Tờ", 70 },
                    { 56, "893456789056", 14, 295000m, "Sữa Bột Dielac Alpha Gold 4 Hộp 900g", 18 },
                    { 57, "893456789057", 15, 24000m, "Túi Rác Tự Hủy Cuộn Lớn", 80 },
                    { 58, "893456789058", 15, 38000m, "Màng Bọc Thực Phẩm PE 30cm x 100m", 45 },
                    { 59, "893456789059", 15, 15000m, "Băng Keo Trong Cuộn 48mm x 100 Yard", 90 },
                    { 60, "893456789060", 15, 42000m, "Túi Nilon Xốp Đen Quai Cuộn 1kg", 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 60);
        }
    }
}
