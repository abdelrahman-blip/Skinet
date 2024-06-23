
using Core.Entities;
using Core.Interfaces;
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
        private readonly IproductRepository _repo;
        public ProductController(IproductRepository repo)
        {
            _repo = repo;
        }

         [HttpGet]
         public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
             return Ok(products);
        }
         

         [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return  await _repo.GetProductByIdAsync(id);
            
        }

        [HttpGet("brand")]
        public async Task<ActionResult<ProductBrand>> GetProductBrand()
        {
            var productsbrands =  await  _repo.GetProductsBrandAsync();
            return Ok(productsbrands);
            
        }
        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            var prodcuttypes = await _repo.GetProductsTypeAsync();
            return Ok(prodcuttypes);
        }

        
    }
}