using System;
using System.Linq;
using System.Threading.Tasks;
using los_api.DataAccess.LosDB;
using los_api.Models;
using los_api.Services.Interfaces;
using los_api.Utils;

namespace los_api.Services
{
    public class ProductService : IProductService
    {
        private readonly LosDbContext _context;
        public ProductService(LosDbContext context)
        {
            this._context = context;
        }

        public async Task AddProduct(ProductModel model)
        {
            var data = Common.MapValue<ProductEntity, ProductModel>(model);
            _context.Product.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductModel model)
        {
            var entities = _context.Product;
            var oldData = (from a in entities where a.id == model.id select a).FirstOrDefault();
            if (oldData == null)
            {
                throw new Exception("not found product data.");
            }
            oldData.name = model.name;
            oldData.price = model.price;
            oldData.imageUrl = model.imageUrl;
            _context.Update(oldData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var entities = _context.Product;
            var oldData = (from a in entities where a.id == id select a).FirstOrDefault();
            if (oldData == null)
            {
                throw new Exception("not found product data.");
            }

            _context.Product.Remove(oldData);
            await _context.SaveChangesAsync();

        }
    }
}