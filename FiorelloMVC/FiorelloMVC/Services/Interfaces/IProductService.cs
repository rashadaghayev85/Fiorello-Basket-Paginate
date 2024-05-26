using FiorelloMVC.Models;
using FiorelloMVC.ViewModels.Product;

namespace FiorelloMVC.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllWithImagesAsync();
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdWithAllDatasAsync(int id);
        Task<Product> GetByIdAsync(int id);
       Task<IEnumerable<Product>> GetAllPaginateAsync(int page, int take);
        IEnumerable<ProductVM> GetMappedDatas(IEnumerable<Product>products);
        Task<int> GetCountAsync();




       
    }
}
