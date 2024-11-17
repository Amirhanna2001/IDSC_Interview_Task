using IDSC_Project.CORE.Models;
using IDSC_Project.CORE.Repositories;
using IDSC_Project.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace IDSC_Project.EF.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
      => await _context.Products.ToListAsync();
    public async Task<List<Product>> SearchAsync(string key)
     => await _context.Products.Where(p=>p.Name.Contains(key)).ToListAsync();

    public async void CreateAsync(Product product)
           =>await _context.Products.AddAsync(product);

    public async Task<Product> GetProductAsync(int id)
        => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    public  void Update(Product product)
        =>_context.Update(product);
    public async void DeleteAsync(int id)
    {
        Product product = await GetProductAsync(id);
        _context.Products.Remove(product);
    }

}