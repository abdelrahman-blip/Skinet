using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecifications:BaseSpecifiaction<Product>
    {
        public ProductWithFiltersForCountSpecifications(ProductSpecParams productParams)
         :base(x =>
                (string.IsNullOrEmpty(productParams.search) || x.Name.ToLower().Contains(productParams.search))
                &&
                (!productParams.brandId.HasValue || x.ProductBrandId == productParams.brandId) && 
                (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId)
        )
        {

        }
    }
}