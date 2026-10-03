/*
 Ten:Nguyen Ngoc Minh Thu
    Masv:2124110080
    Ngay tao: 26/09/2026
 */
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data {
    // DbContext đại diện cho phiên làm việc với cơ sở dữ liệu SQL Server
    public class SupermarketDbContext : DbContext {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        // Khai báo các bảng dữ liệu ánh xạ từ Model
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Customer> Customers { get; set; }

        // Cấu hình dữ liệu mồi ban đầu (Data Seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

          

            // Nạp sẵn 30 sản phẩm ban đầu vào SQL Server ngay khi tạo bảng
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "SP001", ProductName = "Bánh Oreo", Price = 15000, StockQuantity = 50, CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "SP002", ProductName = "Bánh Chocopie", Price = 45000, StockQuantity = 40, CategoryId = 1 },
                new Product { ProductId = 3, Barcode = "SP003", ProductName = "Kẹo dẻo trái cây", Price = 25000, StockQuantity = 60, CategoryId = 1 },
                new Product { ProductId = 4, Barcode = "SP004", ProductName = "Snack khoai tây", Price = 12000, StockQuantity = 70, CategoryId = 1 },
                new Product { ProductId = 5, Barcode = "SP005", ProductName = "Bánh mì sandwich", Price = 28000, StockQuantity = 35, CategoryId = 1 },
                new Product { ProductId = 6, Barcode = "SP006", ProductName = "Kẹo bạc hà", Price = 18000, StockQuantity = 45, CategoryId = 1 },

                new Product { ProductId = 7, Barcode = "SP007", ProductName = "Coca Cola", Price = 10000, StockQuantity = 100, CategoryId = 2 },
                new Product { ProductId = 8, Barcode = "SP008", ProductName = "Pepsi", Price = 10000, StockQuantity = 100, CategoryId = 2 },
                new Product { ProductId = 9, Barcode = "SP009", ProductName = "Trà đào", Price = 15000, StockQuantity = 80, CategoryId = 2 },
                new Product { ProductId = 10, Barcode = "SP010", ProductName = "Nước suối Aquafina", Price = 7000, StockQuantity = 120, CategoryId = 2 },
                new Product { ProductId = 11, Barcode = "SP011", ProductName = "Sting dâu", Price = 10000, StockQuantity = 90, CategoryId = 2 },
                new Product { ProductId = 12, Barcode = "SP012", ProductName = "Trà xanh 0 độ", Price = 10000, StockQuantity = 85, CategoryId = 2 },

                new Product { ProductId = 13, Barcode = "SP013", ProductName = "Sữa tươi Vinamilk", Price = 8000, StockQuantity = 90, CategoryId = 3 },
                new Product { ProductId = 14, Barcode = "SP014", ProductName = "Sữa chua Vinamilk", Price = 7000, StockQuantity = 100, CategoryId = 3 },
                new Product { ProductId = 15, Barcode = "SP015", ProductName = "Sữa đặc Ông Thọ", Price = 25000, StockQuantity = 50, CategoryId = 3 },
                new Product { ProductId = 16, Barcode = "SP016", ProductName = "Phô mai Con Bò Cười", Price = 35000, StockQuantity = 45, CategoryId = 3 },
                new Product { ProductId = 17, Barcode = "SP017", ProductName = "Sữa Milo", Price = 9000, StockQuantity = 75, CategoryId = 3 },
                new Product { ProductId = 18, Barcode = "SP018", ProductName = "Sữa đậu nành Fami", Price = 7000, StockQuantity = 80, CategoryId = 3 },

                new Product { ProductId = 19, Barcode = "SP019", ProductName = "Mì Hảo Hảo", Price = 5000, StockQuantity = 150, CategoryId = 4 },
                new Product { ProductId = 20, Barcode = "SP020", ProductName = "Mì Omachi", Price = 10000, StockQuantity = 100, CategoryId = 4 },
                new Product { ProductId = 21, Barcode = "SP021", ProductName = "Phở bò ăn liền", Price = 12000, StockQuantity = 80, CategoryId = 4 },
                new Product { ProductId = 22, Barcode = "SP022", ProductName = "Cháo thịt bằm", Price = 10000, StockQuantity = 60, CategoryId = 4 },
                new Product { ProductId = 23, Barcode = "SP023", ProductName = "Miến gà ăn liền", Price = 9000, StockQuantity = 65, CategoryId = 4 },
                new Product { ProductId = 24, Barcode = "SP024", ProductName = "Mì xào bò", Price = 6000, StockQuantity = 110, CategoryId = 4 },

                new Product { ProductId = 25, Barcode = "SP025", ProductName = "Nước mắm Nam Ngư", Price = 32000, StockQuantity = 50, CategoryId = 5 },
                new Product { ProductId = 26, Barcode = "SP026", ProductName = "Dầu ăn Simply", Price = 45000, StockQuantity = 40, CategoryId = 5 },
                new Product { ProductId = 27, Barcode = "SP027", ProductName = "Hạt nêm Knorr", Price = 30000, StockQuantity = 55, CategoryId = 5 },
                new Product { ProductId = 28, Barcode = "SP028", ProductName = "Tiêu xay", Price = 22000, StockQuantity = 35, CategoryId = 5 },
                new Product { ProductId = 29, Barcode = "SP029", ProductName = "Đường trắng", Price = 22000, StockQuantity = 60, CategoryId = 5 },
                new Product { ProductId = 30, Barcode = "SP030", ProductName = "Muối i-ốt", Price = 10000, StockQuantity = 70, CategoryId = 5 }
            );

            // Nạp 20 khách hàng mẫu
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn A", PhoneNumber = "0901122334", Address = "123 Nguyễn Trãi, Phường Bến Thành, Quận 1, TP. Hồ Chí Minh", RewardPoints = 150, MembershipRank = "Vàng" },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị B", PhoneNumber = "0918877665", Address = "45 Lê Văn Sỹ, Phường 13, Quận 3, TP. Hồ Chí Minh", RewardPoints = 50, MembershipRank = "Bạc" },
                new Customer { CustomerId = 3, CustomerName = "Lê Văn C", PhoneNumber = "0983344556", Address = "78 Phan Văn Trị, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh", RewardPoints = 10, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 4, CustomerName = "Phạm Minh D", PhoneNumber = "0905678123", Address = "25 Nguyễn Kiệm, Phường 3, Quận Gò Vấp, TP. Hồ Chí Minh", RewardPoints = 220, MembershipRank = "Vàng" },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Thị E", PhoneNumber = "0934567890", Address = "16 Cách Mạng Tháng 8, Phường 12, Quận 10, TP. Hồ Chí Minh", RewardPoints = 80, MembershipRank = "Bạc" },
                new Customer { CustomerId = 6, CustomerName = "Võ Thành F", PhoneNumber = "0978123456", Address = "89 Lý Thường Kiệt, Phường 8, Quận 10, TP. Hồ Chí Minh", RewardPoints = 35, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 7, CustomerName = "Đặng Ngọc G", PhoneNumber = "0909876543", Address = "32 Điện Biên Phủ, Phường 15, Quận Bình Thạnh, TP. Hồ Chí Minh", RewardPoints = 310, MembershipRank = "Vàng" },
                new Customer { CustomerId = 8, CustomerName = "Bùi Thị H", PhoneNumber = "0912345678", Address = "71 Quang Trung, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh", RewardPoints = 65, MembershipRank = "Bạc" },
                new Customer { CustomerId = 9, CustomerName = "Nguyễn Hoàng I", PhoneNumber = "0987654321", Address = "15 Võ Văn Tần, Phường 6, Quận 3, TP. Hồ Chí Minh", RewardPoints = 125, MembershipRank = "Vàng" },
                new Customer { CustomerId = 10, CustomerName = "Lâm Thị K", PhoneNumber = "0903456789", Address = "48 Nguyễn Văn Cừ, Phường 2, Quận 5, TP. Hồ Chí Minh", RewardPoints = 25, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 11, CustomerName = "Trương Văn L", PhoneNumber = "0931234567", Address = "62 Âu Cơ, Phường 9, Quận Tân Bình, TP. Hồ Chí Minh", RewardPoints = 180, MembershipRank = "Vàng" },
                new Customer { CustomerId = 12, CustomerName = "Phan Thị M", PhoneNumber = "0964567890", Address = "105 Lạc Long Quân, Phường 3, Quận 11, TP. Hồ Chí Minh", RewardPoints = 55, MembershipRank = "Bạc" },
                new Customer { CustomerId = 13, CustomerName = "Nguyễn Đức N", PhoneNumber = "0973456123", Address = "27 Phạm Văn Đồng, Phường 3, TP. Thủ Đức, TP. Hồ Chí Minh", RewardPoints = 15, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 14, CustomerName = "Lê Thị O", PhoneNumber = "0906789123", Address = "39 Kha Vạn Cân, Phường Linh Tây, TP. Thủ Đức, TP. Hồ Chí Minh", RewardPoints = 240, MembershipRank = "Vàng" },
                new Customer { CustomerId = 15, CustomerName = "Phạm Quốc P", PhoneNumber = "0915678901", Address = "88 Nguyễn Oanh, Phường 17, Quận Gò Vấp, TP. Hồ Chí Minh", RewardPoints = 95, MembershipRank = "Bạc" },
                new Customer { CustomerId = 16, CustomerName = "Đỗ Minh Q", PhoneNumber = "0981234567", Address = "12 Trường Chinh, Phường 13, Quận Tân Bình, TP. Hồ Chí Minh", RewardPoints = 45, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 17, CustomerName = "Nguyễn Thị R", PhoneNumber = "0907891234", Address = "54 Nguyễn Thị Minh Khai, Phường Đa Kao, Quận 1, TP. Hồ Chí Minh", RewardPoints = 275, MembershipRank = "Vàng" },
                new Customer { CustomerId = 18, CustomerName = "Huỳnh Văn S", PhoneNumber = "0937894561", Address = "76 Hoàng Văn Thụ, Phường 9, Quận Phú Nhuận, TP. Hồ Chí Minh", RewardPoints = 70, MembershipRank = "Bạc" },
                new Customer { CustomerId = 19, CustomerName = "Mai Thị T", PhoneNumber = "0967891234", Address = "41 Phan Đăng Lưu, Phường 3, Quận Bình Thạnh, TP. Hồ Chí Minh", RewardPoints = 20, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 20, CustomerName = "Đinh Văn U", PhoneNumber = "0976543210", Address = "93 Nguyễn Văn Luông, Phường 12, Quận 6, TP. Hồ Chí Minh", RewardPoints = 160, MembershipRank = "Vàng" }
            );
        }
    }
}
