using System;
using System.Linq;
using los_api.DataAccess.LosDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace los_api.Utils
{
    public class MockData
    {
        public static void Generate(IServiceProvider service)
        {
            using var context = new LosDbContext(service.GetRequiredService<DbContextOptions<LosDbContext>>());
            if (context.Product.Any() && context.Stock.Any())
            {
                return;
            }
            
            context.Product.AddRange(
                new ProductEntity(){ id = 1, price = 200, imageUrl = "http://prd.local"});
        }
    }
}