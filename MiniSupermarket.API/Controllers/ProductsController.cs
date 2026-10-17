/*
 Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        // Không cần đăng nhập để xem danh sách
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<object>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new
                {
                    p.ProductId,
                    p.Barcode,
                    p.ProductName,
                    p.Price,
                    p.StockQuantity,
                    p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : ""
                })
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/products/paged?keyword=sua&categoryId=1&pageNumber=1&pageSize=5
        [HttpGet("paged")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPagedProducts(
            [FromQuery] string? keyword,
            [FromQuery] int? categoryId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            // 1. Kiểm tra tham số trang đầu vào hợp lệ
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 5; // Mặc định 5 dòng, tối đa 50 dòng

            // 2. Khởi tạo truy vấn LINQ IQueryable kết hợp Eager Loading (.Include)
            var query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            // 3. Lọc theo từ khóa tìm kiếm (nếu người dùng có nhập)
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string search = keyword.Trim().ToLower();
                query = query.Where(p => p.ProductName.ToLower().Contains(search) 
                                      || p.Barcode.Contains(search));
            }

            // BÀI TẬP 6.2: Lọc theo nhóm ngành hàng
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            // 4. Đếm tổng số lượng bản ghi thỏa mãn điều kiện
            int totalItems = await query.CountAsync();

            // 5. Tính toán tổng số trang
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // 6. Áp dụng toán tử Skip và Take để phân trang trực tiếp dưới SQL Server
            var items = await query
                .OrderBy(p => p.ProductId) // Bắt buộc phải OrderBy trước khi Skip/Take
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductItemDto
                {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : string.Empty
                })
                .ToListAsync();

            // 7. Đóng gói kết quả trả về cho Client
            var response = new PagedResult<ProductItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            };

            return Ok(response);
        }

        // GET: api/products/with-category  (Bài tập 1 - Eager Loading)
        [HttpGet("with-category")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithCategory()
        {
            var products = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Select(p => new
                {
                    p.ProductId,
                    p.Barcode,
                    p.ProductName,
                    p.Price,
                    p.StockQuantity,
                    IsLowStock = p.StockQuantity <= 20,
                    CategoryName = p.Category != null ? p.Category.CategoryName : string.Empty
                })
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/products/search?barcode={barcode}
        // Không cần đăng nhập để tìm kiếm
        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> SearchByBarcode([FromQuery] string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return BadRequest("Barcode is required.");

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Barcode == barcode);

            if (product == null)
                return NotFound("Product not found");

            return Ok(new
            {
                product.ProductId,
                product.Barcode,
                product.ProductName,
                product.Price,
                product.StockQuantity,
                product.CategoryId
            });
        }

        // POST: api/products
        [HttpPost]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (await _context.Products.AnyAsync(p => p.Barcode == product.Barcode))
            {
                return BadRequest("Mã vạch đã tồn tại.");
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts),
                new { id = product.ProductId }, product);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            if (await _context.Products.AnyAsync(
                p => p.Barcode == product.Barcode && p.ProductId != id))
            {
                return BadRequest("Mã vạch đã bị trùng với sản phẩm khác.");
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}