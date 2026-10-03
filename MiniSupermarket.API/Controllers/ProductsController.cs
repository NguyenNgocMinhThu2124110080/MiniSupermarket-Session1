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