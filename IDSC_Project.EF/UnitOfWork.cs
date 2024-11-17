using IDSC_Project.CORE;
using IDSC_Project.CORE.Repositories;
using IDSC_Project.EF.Data;
using IDSC_Project.EF.Repositories;

namespace IDSC_Project.EF;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IProductRepository ProductRepository { get; private set; }
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        ProductRepository = new ProductRepository(_context);
    }

    public void Dispose()   
        =>_context.Dispose();

    public int SaveChanges() 
        => _context.SaveChanges();
}
