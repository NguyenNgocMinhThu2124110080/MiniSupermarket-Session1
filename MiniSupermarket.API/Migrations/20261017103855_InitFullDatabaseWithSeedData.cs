using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class InitFullDatabaseWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CashierUsername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RewardPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "Snack khoai tây, bánh quy bơ, kẹo trái cây");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Description",
                value: "Nước ngọt lon, nước khoáng thiên nhiên, trà xanh đóng chai");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Sữa tươi tiệt trùng, sữa đặc, sữa chua ăn, phô mai lát");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Description",
                value: "Mì ăn liền, hủ tiếu, phở khô, cháo gói dinh dưỡng");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm cá cơm, hạt nêm, dầu ăn nguyên chất, muối i-ốt");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 6, "Gạo, Bột & Đồ khô", "Gạo thơm, bột mì, bột năng, đường, đậu, nấm, miến, bún khô" },
                    { 7, "Hóa phẩm tẩy rửa", "Nước giặt xả, nước lau sàn nhà, nước rửa chén, bột tẩy" },
                    { 8, "Chăm sóc cá nhân", "Dầu gội đầu, sữa tắm dưỡng ẩm, kem đánh răng, xà phòng" },
                    { 9, "Đồ dùng nhà bếp", "Chảo, nồi, dao, thớt, hộp đựng thực phẩm, chén đũa" },
                    { 10, "Đồ nhựa & Gia dụng", "Thùng nhựa, rổ, chậu, móc áo, chổi, cây lau nhà" },
                    { 11, "Văn phòng phẩm & Học sinh", "Vở học sinh, bút bi, bút chì, kéo, hồ dán, giấy A4" },
                    { 12, "Đồ điện & Pin", "Pin tiểu, bóng đèn LED, ổ cắm điện, dây sạc" },
                    { 13, "Cà phê & Ngũ cốc", "Cà phê hòa tan 3in1, bột yến mạch, bột ngũ cốc dinh dưỡng" },
                    { 14, "Mẹ & Bé", "Tã bỉm, khăn ướt, sữa bột, bình sữa, dầu tắm gội trẻ em" },
                    { 15, "Túi bao bì & Vật tư đóng gói", "Túi nilon, túi rác, màng bọc thực phẩm, giấy gói, băng keo" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "123 Lê Lợi, Quận 1, TPHCM", "Trần Văn Hoàng", "Bạc", "0903123456", 120 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "45 Điện Biên Phủ, Quận Bình Thạnh, TPHCM", "Nguyễn Thị Kim Loan", "Vàng", "0918234567", 350 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Address", "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "88 Nam Kỳ Khởi Nghĩa, Quận 3, TPHCM", "Lê Minh Trí", "0977345678", 45 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 4, "102 Quang Trung, Quận Gò Vấp, TPHCM", "Phạm Hồng Nhung", "Bạch Kim", "0988456789", 520 },
                    { 5, "15 Phan Xích Long, Quận Phú Nhuận, TPHCM", "Võ Thành Nam", "Chuẩn", "0909567890", 80 },
                    { 6, "234 Hoàng Văn Thụ, Quận Tân Bình, TPHCM", "Đỗ Thị Mỹ Duyên", "Bạc", "0933678901", 210 },
                    { 7, "312 Ba Tháng Hai, Quận 10, TPHCM", "Hoàng Quốc Bảo", "Chuẩn", "0944789012", 15 },
                    { 8, "56 Nguyễn Thị Thập, Quận 7, TPHCM", "Bùi Lan Hương", "Vàng", "0966890123", 410 },
                    { 9, "79 Kinh Dương Vương, Quận Bình Tân, TPHCM", "Đặng Tuấn Kiệt", "Chuẩn", "0922901234", 95 },
                    { 10, "18 Hoàng Diệu, Quận 4, TPHCM", "Ngô Thanh Vân", "Bạch Kim", "0971012345", 650 },
                    { 11, "405 Lê Văn Khương, Quận 12, TPHCM", "Trương Đình Trọng", "Chuẩn", "0982123456", 30 },
                    { 12, "123 Long Thuận, TP. Thủ Đức, TPHCM", "Lý Mỹ Lệ", "Bạc", "0904234567", 180 },
                    { 13, "67 Lũy Bán Bích, Quận Tân Phú, TPHCM", "Vũ Đức Thịnh", "Bạc", "0915345678", 290 },
                    { 14, "142 Phạm Thế Hiển, Quận 8, TPHCM", "Phan Bích Thủy", "Vàng", "0936456789", 480 },
                    { 15, "89 An Dương Vương, Quận 5, TPHCM", "Dương Gia Huy", "Chuẩn", "0977567890", 0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CashierUsername", "CreatedDate", "CustomerId", "FinalAmount", "OrderCode", "RewardPoints", "TotalItems" },
                values: new object[,]
                {
                    { 1, "cashier01", new DateTime(2026, 10, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 57000m, "HD20261001-001", 5, 3 },
                    { 2, "cashier01", new DateTime(2026, 10, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 2, 145000m, "HD20261001-002", 14, 2 },
                    { 3, "cashier02", new DateTime(2026, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 45000m, "HD20261001-003", 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "893456789001", 1, 12500m, "Snack Khoai Tây O'Star Gói 60g", 150 },
                    { 2, "893456789002", 1, 135000m, "Bánh Quy Bơ Danisa Hộp Thiếc 454g", 40 },
                    { 3, "893456789003", 1, 15000m, "Kẹo Dẻo Chupa Chups Hương Trái Cây 90g", 120 },
                    { 4, "893456789004", 1, 54000m, "Bánh Chocopie Orion Hộp 12 Cái", 60 },
                    { 5, "893456789005", 2, 10000m, "Nước Ngọt Coca Cola Lon 320ml", 320 },
                    { 6, "893456789006", 2, 6000m, "Nước Khoáng Thiên Nhiên Lavie Chai 500ml", 200 },
                    { 7, "893456789007", 2, 11000m, "Trà Xanh Không Độ Chai 455ml", 180 },
                    { 8, "893456789008", 2, 14500m, "Nước Tăng Lực Red Bull Lon 250ml", 150 },
                    { 9, "893456789009", 3, 34500m, "Sữa Tươi Tiệt Trùng Vinamilk Có Đường 1L", 85 },
                    { 13, "893456789013", 4, 4500m, "Mì Tôm Hảo Hảo Chua Cay Gói 75g", 500 },
                    { 16, "893456789016", 5, 125000m, "Dầu Ăn Simply Nguyên Chất Can 2L", 45 },
                    { 17, "893456789017", 5, 30000m, "Nước Mắm Nam Ngư Đệ Nhị Chai 900ml", 90 },
                    { 18, "893456789018", 5, 36000m, "Hạt Nêm Knorr Từ Thịt Thăn Gói 400g", 75 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FullName", "IsActive", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Nguyễn Quản Trị", true, "admin@123", "Admin", "admin" },
                    { 2, "Trần Cửa Hàng Trưởng", true, "manager@123", "Admin", "manager01" },
                    { 3, "Lê Thu Ngân 1", true, "cashier@123", "Cashier", "cashier01" },
                    { 4, "Phạm Thu Ngân 2", true, "cashier@123", "Cashier", "cashier02" },
                    { 5, "Hoàng Thu Ngân 3", true, "cashier@123", "Cashier", "cashier03" },
                    { 6, "Vũ Thu Ngân 4", true, "cashier@123", "Cashier", "cashier04" },
                    { 7, "Đỗ Thu Ngân 5", true, "cashier@123", "Cashier", "cashier05" },
                    { 8, "Ngô Thu Ngân 6", true, "cashier@123", "Cashier", "cashier06" },
                    { 9, "Bùi Thu Ngân 7", true, "cashier@123", "Cashier", "cashier07" },
                    { 10, "Đặng Thủ Kho 1", true, "wh@123", "Warehouse", "warehouse01" },
                    { 11, "Trương Thủ Kho 2", true, "wh@123", "Warehouse", "warehouse02" },
                    { 12, "Lý Kiểm Kê", true, "wh@123", "Warehouse", "warehouse03" },
                    { 13, "Mai Thu Ngân 8", true, "cashier@123", "Cashier", "cashier08" },
                    { 14, "Dương Thu Ngân 9", true, "cashier@123", "Cashier", "cashier09" },
                    { 15, "Hồ Nhân Viên Nghỉ Việc", false, "lock@123", "Cashier", "staff_lock" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "LineTotal", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 10000m, 1, 5, 1, 10000m },
                    { 2, 12500m, 1, 1, 1, 12500m },
                    { 3, 34500m, 1, 9, 1, 34500m },
                    { 4, 135000m, 2, 2, 1, 135000m },
                    { 5, 10000m, 2, 5, 1, 10000m },
                    { 6, 45000m, 3, 13, 10, 4500m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CashierUsername", "CreatedDate", "CustomerId", "FinalAmount", "OrderCode", "RewardPoints", "TotalItems" },
                values: new object[,]
                {
                    { 4, "cashier02", new DateTime(2026, 10, 2, 8, 45, 0, 0, DateTimeKind.Unspecified), 4, 138000m, "HD20261002-001", 13, 4 },
                    { 5, "cashier03", new DateTime(2026, 10, 2, 11, 20, 0, 0, DateTimeKind.Unspecified), 5, 69000m, "HD20261002-002", 6, 2 },
                    { 6, "cashier03", new DateTime(2026, 10, 3, 14, 10, 0, 0, DateTimeKind.Unspecified), 6, 53500m, "HD20261003-001", 5, 1 },
                    { 7, "cashier04", new DateTime(2026, 10, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), 7, 30000m, "HD20261003-002", 3, 5 },
                    { 8, "cashier04", new DateTime(2026, 10, 4, 9, 5, 0, 0, DateTimeKind.Unspecified), 8, 155000m, "HD20261004-001", 15, 2 },
                    { 9, "cashier05", new DateTime(2026, 10, 4, 13, 30, 0, 0, DateTimeKind.Unspecified), 9, 55500m, "HD20261004-002", 5, 4 },
                    { 10, "cashier05", new DateTime(2026, 10, 5, 10, 50, 0, 0, DateTimeKind.Unspecified), 10, 180000m, "HD20261005-001", 18, 4 },
                    { 11, "cashier06", new DateTime(2026, 10, 5, 17, 15, 0, 0, DateTimeKind.Unspecified), 11, 36000m, "HD20261005-002", 3, 8 },
                    { 12, "cashier06", new DateTime(2026, 10, 6, 8, 20, 0, 0, DateTimeKind.Unspecified), 12, 108000m, "HD20261006-001", 10, 2 },
                    { 13, "cashier07", new DateTime(2026, 10, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), 13, 78000m, "HD20261006-002", 7, 3 },
                    { 14, "cashier07", new DateTime(2026, 10, 7, 12, 10, 0, 0, DateTimeKind.Unspecified), 14, 125000m, "HD20261007-001", 12, 1 },
                    { 15, "cashier01", new DateTime(2026, 10, 7, 18, 45, 0, 0, DateTimeKind.Unspecified), 15, 40000m, "HD20261007-002", 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 10, "893456789010", 11, 12000m, "Vở Campus Kẻ Ngang 200 Trang", 400 },
                    { 11, "893456789011", 12, 18000m, "Pin AA Panasonic Vỉ 2 Viên", 15 },
                    { 12, "893456789012", 8, 165000m, "Dầu Gội Clear Bạc Hà Chai 630g", 55 },
                    { 14, "893456789014", 9, 89000m, "Chảo Chống Dính Sunhouse 24cm", 25 },
                    { 15, "893456789015", 13, 48000m, "Cà Phê Hòa Tan G7 3in1 Hộp 21 Gói", 70 },
                    { 19, "893456789019", 6, 135000m, "Gạo Thơm ST25 Túi 5kg", 60 },
                    { 20, "893456789020", 7, 29000m, "Nước Rửa Chén Sunlight Chanh Chai 750g", 80 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "LineTotal", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 7, 138000m, 4, 9, 4, 34500m },
                    { 8, 69000m, 5, 9, 2, 34500m },
                    { 9, 14500m, 9, 8, 1, 14500m },
                    { 10, 53500m, 6, 4, 1, 53500m },
                    { 11, 30000m, 7, 6, 5, 6000m },
                    { 12, 125000m, 8, 16, 1, 125000m },
                    { 13, 30000m, 8, 17, 1, 30000m },
                    { 14, 30000m, 9, 3, 2, 15000m },
                    { 15, 11000m, 9, 7, 1, 11000m },
                    { 16, 108000m, 10, 4, 2, 54000m },
                    { 17, 72000m, 10, 18, 2, 36000m },
                    { 18, 125000m, 14, 16, 1, 125000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCode",
                table: "Orders",
                column: "OrderCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Products_Barcode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "Snack, bánh quy, kẹo dẻo");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Description",
                value: "Nước ngọt, nước khoáng, trà");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Sữa tươi, sữa chua, phô mai");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Description",
                value: "Mì ăn liền, phở khô, cháo gói");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm, hạt nêm, dầu thực vật");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "TP. Hồ Chí Minh", "Nguyễn Văn A", "Vàng", "0901122334", 150 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "TP. Hồ Chí Minh", "Trần Thị B", "Bạc", "0918877665", 50 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Address", "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "TP. Hồ Chí Minh", "Lê Văn C", "0983344556", 10 });
        }
    }
}
