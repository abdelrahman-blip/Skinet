
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
        private readonly IGenericRepository<Product> _productrepo;
        private readonly IGenericRepository<ProductBrand> _productbrandrepo;
        private readonly IGenericRepository<ProductType> _productyperepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productrepo,IGenericRepository<ProductBrand> productbrandrepo,
        IGenericRepository<ProductType> productyperepo,IMapper mapper)
        {
            _productrepo = productrepo;
            _productbrandrepo = productbrandrepo;
            _productyperepo = productyperepo;
            _mapper = mapper;
        }

         [HttpGet]
         public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countspec = new ProductWithFiltersForCountSpecifications(productParams);

            var products = await _productrepo.ListAsyncSpec(spec);
            var totalitms = await _productrepo.CountAsync(countspec);
            
            var data =  _mapper
            .Map<IReadOnlyList<Product> ,IReadOnlyList<ProductDto>>(products); 

            return Ok(new Pagination<ProductDto>(productParams.PageIndex,productParams.PageSize,totalitms,data));   
        }
         

         [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
             var spec = new ProductsWithTypesAndBrandsSpecification(id);
             var products =  await _productrepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product , ProductDto>(products);
                                        
        }

        [HttpGet("brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            
            return Ok(await  _productbrandrepo.ListAllAsync());
            
        }
        
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var prodcuttypes = await _productyperepo.ListAllAsync();
            return Ok(prodcuttypes);
        }
        
    }
}