using IDSC_Project.CORE.Models;

namespace IDSC_Project.CORE.Repositories;
public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> SearchAsync(string key);
    void CreateAsync(Product product);
    Task<Product> GetProductAsync(int id);
    void Update(Product product);
    void DeleteAsync(int id);
}