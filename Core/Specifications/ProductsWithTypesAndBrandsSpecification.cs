using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification: BaseSpecifiaction<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        :base(x =>
                (string.IsNullOrEmpty(productParams.search) || x.Name.ToLower().Contains(productParams.search))
                 &&
                (!productParams.brandId.HasValue || x.ProductBrandId == productParams.brandId) && 
                (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId)
        )
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),productParams.PageSize);
                if(!string.IsNullOrEmpty(productParams.sort))
                {
                    switch(productParams.sort)
                    {
                        case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescening(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                    }
                }

        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
             AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}