using System.Threading.Tasks;
using los_api.Models;

namespace los_api.Services.Interfaces
{
    public interface IStockService
    {
        Task AddStock(StockModel model);
        Task UpdateStock(StockModel model);
        Task DeleteStock(int id);
    }
}