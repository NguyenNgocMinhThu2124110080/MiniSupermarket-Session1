/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 27/09/2026
 * CustomersController - Quan ly khach hang than thiet
 * Su dung EF Core + Async/Await truy van SQL Server
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        // Tiem DbContext thong qua Constructor Injection
        public CustomersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. GET /api/customers - Lay toan bo danh sach khach hang
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Customers.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        // 2. GET /api/customers/{id} - Lay chi tiet 1 khach hang theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng trong CSDL!" });
            }
            return Ok(customer);
        }

        // 3. GET /api/customers/search?keyword=... - Tim kiem theo ten hoac so dien thoai
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa tìm kiếm!" });
            }

            // EF Core dich bieu thuc LINQ thanh cau lenh SQL LIKE tuong ung
            var result = await _context.Customers
                .Where(c => c.CustomerName.Contains(keyword) || c.PhoneNumber.Contains(keyword))
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        // 4. POST /api/customers - Them moi khach hang thanh vien
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync(); // Luu thay doi vao SQL Server

            return CreatedAtAction(nameof(GetById), new { id = newCustomer.CustomerId }, newCustomer);
        }

        // 5. PUT /api/customers/{id} - Cap nhat thong tin va hang the cua khach hang
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer updateCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng cần cập nhật!" });
            }

            customer.CustomerName = updateCustomer.CustomerName;
            customer.PhoneNumber = updateCustomer.PhoneNumber;
            customer.Address = updateCustomer.Address;
            customer.RewardPoints = updateCustomer.RewardPoints;
            customer.MembershipRank = updateCustomer.MembershipRank;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. DELETE /api/customers/{id} - Xoa tai khoan khach hang khoi he thong
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng cần xóa!" });
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
