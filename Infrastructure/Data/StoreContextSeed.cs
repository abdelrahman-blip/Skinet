using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
    public static async Task SeedAsync(StoreContext context)
    {
        if(!context.ProductBrands.Any())
        {
           var productbrands = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
           var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productbrands);
           context.ProductBrands.AddRange(brands);
        }
        if(!context.ProductTypes.Any())
        {
            var producttypes = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(producttypes);
            context.ProductTypes.AddRange(types);
        }
        if(!context.Products.Any())
        {
            var productsjson = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsjson);
            context.Products.AddRange(products);
        }
        if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
    }
   
}