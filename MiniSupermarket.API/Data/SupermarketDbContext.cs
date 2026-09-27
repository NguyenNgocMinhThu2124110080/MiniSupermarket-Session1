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

            // Nạp sẵn 5 danh mục ban đầu vào SQL Server ngay khi tạo bảng
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Bánh kẹo & Đồ ăn vặt", Description = "Snack, bánh quy, kẹo dẻo" },
                new Category { CategoryId = 2, CategoryName = "Nước giải khát & Trà", Description = "Nước ngọt, nước khoáng, trà" },
                new Category { CategoryId = 3, CategoryName = "Sữa & Sản phẩm từ sữa", Description = "Sữa tươi, sữa chua, phô mai" },
                new Category { CategoryId = 4, CategoryName = "Mì gói & Thực phẩm ăn liền", Description = "Mì ăn liền, phở khô, cháo gói" },
                new Category { CategoryId = 5, CategoryName = "Gia vị & Dầu ăn", Description = "Nước mắm, hạt nêm, dầu thực vật" }
            );

            //  Nạp 3 khách hàng mẫu
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Nguyễn Văn A",
                    PhoneNumber = "0901122334",
                    Address = "TP. Hồ Chí Minh",
                    RewardPoints = 150,
                    MembershipRank = "Vàng"
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Trần Thị B",
                    PhoneNumber = "0918877665",
                    Address = "TP. Hồ Chí Minh",
                    RewardPoints = 50,
                    MembershipRank = "Bạc"
                },
                new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Lê Văn C",
                    PhoneNumber = "0983344556",
                    Address = "TP. Hồ Chí Minh",
                    RewardPoints = 10,
                    MembershipRank = "Chuẩn"
                }
            );
        }
    }
}
