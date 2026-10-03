/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 * ProductsController - Quan ly san pham sieu thi
 * Su dung EF Core + Async/Await truy van SQL Server
 * Ket hop Eager Loading (.Include) de lay ten danh muc
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        // Tiem DbContext thong qua Constructor Injection
        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. GET /api/products - Lay toan bo danh sach san pham (kem ten danh muc)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();
            return Ok(list);
        }

        // 2. GET /api/products/{id} - Lay chi tiet 1 san pham theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm trong CSDL!" });
            }
            return Ok(product);
        }

        // 3. GET /api/products/search?keyword=... - Tim kiem theo ten hoac ma vach
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa tìm kiếm!" });
            }

            // EF Core dich LINQ thanh SQL LIKE
            var result = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.ProductName.Contains(keyword) || p.Barcode.Contains(keyword))
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        // 4. GET /api/products/by-category/{categoryId} - Loc san pham theo danh muc
        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var result = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        // 5. POST /api/products - Them moi san pham
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiem tra Barcode trung lap
            bool barcodeExists = await _context.Products
                .AnyAsync(p => p.Barcode == newProduct.Barcode);
            if (barcodeExists)
            {
                return BadRequest(new { message = "Mã vạch đã tồn tại trong hệ thống!" });
            }

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductId }, newProduct);
        }

        // 6. PUT /api/products/{id} - Cap nhat thong tin san pham
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product updateProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần cập nhật!" });
            }

            // Kiem tra Barcode trung lap (ngoai tru ban than no)
            bool barcodeExists = await _context.Products
                .AnyAsync(p => p.Barcode == updateProduct.Barcode && p.ProductId != id);
            if (barcodeExists)
            {
                return BadRequest(new { message = "Mã vạch đã được dùng bởi sản phẩm khác!" });
            }

            product.Barcode       = updateProduct.Barcode;
            product.ProductName   = updateProduct.ProductName;
            product.Price         = updateProduct.Price;
            product.StockQuantity = updateProduct.StockQuantity;
            product.CategoryId    = updateProduct.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 7. DELETE /api/products/{id} - Xoa san pham khoi he thong
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần xóa!" });
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
