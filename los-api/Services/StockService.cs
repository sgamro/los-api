using System;
using System.Linq;
using System.Threading.Tasks;
using los_api.DataAccess.LosDB;
using los_api.Models;
using los_api.Services.Interfaces;
using los_api.Utils;

namespace los_api.Services
{
    public class StockService : IStockService
    {
        private readonly LosDbContext _context;
        public StockService(LosDbContext context)
        {
            this._context = context;
        }

        public async Task AddStock(StockModel model)
        {
            var data = Common.MapValue<StockEntity, StockModel>(model);
            _context.Stock.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStock(StockModel model)
        {
            var entities = _context.Stock;
            var oldData = (from a in entities where a.id == model.id select a).FirstOrDefault();
            if (oldData == null)
            {
                throw new Exception("not found Stock data.");
            }
            oldData.amount = model.amount;
            oldData.productId = model.productId;
            _context.Update(oldData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStock(int id)
        {
            var entities = _context.Stock;
            var oldData = (from a in entities where a.id == id select a).FirstOrDefault();
            if (oldData == null)
            {
                throw new Exception("not found Stock data.");
            }

            _context.Stock.Remove(oldData);
            await _context.SaveChangesAsync();

        }
    }
}