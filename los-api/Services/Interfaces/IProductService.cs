using System.Threading.Tasks;
using los_api.Models;

namespace los_api.Services.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductModel model);
        Task UpdateProduct(ProductModel model);
        Task DeleteProduct(int id);
    }
}