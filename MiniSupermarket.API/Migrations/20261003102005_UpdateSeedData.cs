using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Address",
                value: "123 Nguyễn Trãi, Phường Bến Thành, Quận 1, TP. Hồ Chí Minh");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Address",
                value: "45 Lê Văn Sỹ, Phường 13, Quận 3, TP. Hồ Chí Minh");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Address",
                value: "78 Phan Văn Trị, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 4, "25 Nguyễn Kiệm, Phường 3, Quận Gò Vấp, TP. Hồ Chí Minh", "Phạm Minh D", "Vàng", "0905678123", 220 },
                    { 5, "16 Cách Mạng Tháng 8, Phường 12, Quận 10, TP. Hồ Chí Minh", "Hoàng Thị E", "Bạc", "0934567890", 80 },
                    { 6, "89 Lý Thường Kiệt, Phường 8, Quận 10, TP. Hồ Chí Minh", "Võ Thành F", "Chuẩn", "0978123456", 35 },
                    { 7, "32 Điện Biên Phủ, Phường 15, Quận Bình Thạnh, TP. Hồ Chí Minh", "Đặng Ngọc G", "Vàng", "0909876543", 310 },
                    { 8, "71 Quang Trung, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh", "Bùi Thị H", "Bạc", "0912345678", 65 },
                    { 9, "15 Võ Văn Tần, Phường 6, Quận 3, TP. Hồ Chí Minh", "Nguyễn Hoàng I", "Vàng", "0987654321", 125 },
                    { 10, "48 Nguyễn Văn Cừ, Phường 2, Quận 5, TP. Hồ Chí Minh", "Lâm Thị K", "Chuẩn", "0903456789", 25 },
                    { 11, "62 Âu Cơ, Phường 9, Quận Tân Bình, TP. Hồ Chí Minh", "Trương Văn L", "Vàng", "0931234567", 180 },
                    { 12, "105 Lạc Long Quân, Phường 3, Quận 11, TP. Hồ Chí Minh", "Phan Thị M", "Bạc", "0964567890", 55 },
                    { 13, "27 Phạm Văn Đồng, Phường 3, TP. Thủ Đức, TP. Hồ Chí Minh", "Nguyễn Đức N", "Chuẩn", "0973456123", 15 },
                    { 14, "39 Kha Vạn Cân, Phường Linh Tây, TP. Thủ Đức, TP. Hồ Chí Minh", "Lê Thị O", "Vàng", "0906789123", 240 },
                    { 15, "88 Nguyễn Oanh, Phường 17, Quận Gò Vấp, TP. Hồ Chí Minh", "Phạm Quốc P", "Bạc", "0915678901", 95 },
                    { 16, "12 Trường Chinh, Phường 13, Quận Tân Bình, TP. Hồ Chí Minh", "Đỗ Minh Q", "Chuẩn", "0981234567", 45 },
                    { 17, "54 Nguyễn Thị Minh Khai, Phường Đa Kao, Quận 1, TP. Hồ Chí Minh", "Nguyễn Thị R", "Vàng", "0907891234", 275 },
                    { 18, "76 Hoàng Văn Thụ, Phường 9, Quận Phú Nhuận, TP. Hồ Chí Minh", "Huỳnh Văn S", "Bạc", "0937894561", 70 },
                    { 19, "41 Phan Đăng Lưu, Phường 3, Quận Bình Thạnh, TP. Hồ Chí Minh", "Mai Thị T", "Chuẩn", "0967891234", 20 },
                    { 20, "93 Nguyễn Văn Luông, Phường 12, Quận 6, TP. Hồ Chí Minh", "Đinh Văn U", "Vàng", "0976543210", 160 }
                });

            // Đảm bảo Categories đã tồn tại trước khi insert Products (tránh lỗi FK)
            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT [Categories] ON;
                IF NOT EXISTS (SELECT 1 FROM [Categories] WHERE [CategoryId] = 1)
                    INSERT INTO [Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1, N'Bánh kẹo & Đồ ăn vặt', N'Snack, bánh quy, kẹo dẻo');
                IF NOT EXISTS (SELECT 1 FROM [Categories] WHERE [CategoryId] = 2)
                    INSERT INTO [Categories] ([CategoryId], [CategoryName], [Description]) VALUES (2, N'Nước giải khát & Trà', N'Nước ngọt, nước khoáng, trà');
                IF NOT EXISTS (SELECT 1 FROM [Categories] WHERE [CategoryId] = 3)
                    INSERT INTO [Categories] ([CategoryId], [CategoryName], [Description]) VALUES (3, N'Sữa & Sản phẩm từ sữa', N'Sữa tươi, sữa chua, phô mai');
                IF NOT EXISTS (SELECT 1 FROM [Categories] WHERE [CategoryId] = 4)
                    INSERT INTO [Categories] ([CategoryId], [CategoryName], [Description]) VALUES (4, N'Mì gói & Thực phẩm ăn liền', N'Mì ăn liền, phở khô, cháo gói');
                IF NOT EXISTS (SELECT 1 FROM [Categories] WHERE [CategoryId] = 5)
                    INSERT INTO [Categories] ([CategoryId], [CategoryName], [Description]) VALUES (5, N'Gia vị & Dầu ăn', N'Nước mắm, hạt nêm, dầu thực vật');
                SET IDENTITY_INSERT [Categories] OFF;
            ");

            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT [Products] ON;
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 1) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (1,N'SP001',1,15000,N'Bánh Oreo',50);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 2) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (2,N'SP002',1,45000,N'Bánh Chocopie',40);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 3) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (3,N'SP003',1,25000,N'Kẹo dẻo trái cây',60);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 4) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (4,N'SP004',1,12000,N'Snack khoai tây',70);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 5) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (5,N'SP005',1,28000,N'Bánh mì sandwich',35);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 6) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (6,N'SP006',1,18000,N'Kẹo bạc hà',45);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 7) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (7,N'SP007',2,10000,N'Coca Cola',100);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 8) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (8,N'SP008',2,10000,N'Pepsi',100);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 9) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (9,N'SP009',2,15000,N'Trà đào',80);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 10) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (10,N'SP010',2,7000,N'Nước suối Aquafina',120);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 11) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (11,N'SP011',2,10000,N'Sting dâu',90);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 12) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (12,N'SP012',2,10000,N'Trà xanh 0 độ',85);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 13) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (13,N'SP013',3,8000,N'Sữa tươi Vinamilk',90);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 14) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (14,N'SP014',3,7000,N'Sữa chua Vinamilk',100);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 15) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (15,N'SP015',3,25000,N'Sữa đặc Ông Thọ',50);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 16) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (16,N'SP016',3,35000,N'Phô mai Con Bò Cười',45);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 17) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (17,N'SP017',3,9000,N'Sữa Milo',75);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 18) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (18,N'SP018',3,7000,N'Sữa đậu nành Fami',80);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 19) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (19,N'SP019',4,5000,N'Mì Hảo Hảo',150);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 20) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (20,N'SP020',4,10000,N'Mì Omachi',100);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 21) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (21,N'SP021',4,12000,N'Phở bò ăn liền',80);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 22) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (22,N'SP022',4,10000,N'Cháo thịt bằm',60);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 23) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (23,N'SP023',4,9000,N'Miến gà ăn liền',65);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 24) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (24,N'SP024',4,6000,N'Mì xào bò',110);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 25) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (25,N'SP025',5,32000,N'Nước mắm Nam Ngư',50);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 26) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (26,N'SP026',5,45000,N'Dầu ăn Simply',40);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 27) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (27,N'SP027',5,30000,N'Hạt nêm Knorr',55);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 28) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (28,N'SP028',5,22000,N'Tiêu xay',35);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 29) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (29,N'SP029',5,22000,N'Đường trắng',60);
                IF NOT EXISTS (SELECT 1 FROM [Products] WHERE [ProductId] = 30) INSERT INTO [Products] ([ProductId],[Barcode],[CategoryId],[Price],[ProductName],[StockQuantity]) VALUES (30,N'SP030',5,10000,N'Muối i-ốt',70);
                SET IDENTITY_INSERT [Products] OFF;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 20);

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

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Address",
                value: "TP. Hồ Chí Minh");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Address",
                value: "TP. Hồ Chí Minh");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Address",
                value: "TP. Hồ Chí Minh");
        }
    }
}
