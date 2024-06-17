
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductController:ControllerBase
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<List<Product>>> GetProduct(int id)
        // {
        //     var products = await _context.Products.ToListAsync();
        //     return products;
        // }
         

         [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}