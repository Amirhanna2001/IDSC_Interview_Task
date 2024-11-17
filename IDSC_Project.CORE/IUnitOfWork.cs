using IDSC_Project.CORE.Repositories;

namespace IDSC_Project.CORE;
public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository {get;} 
    int SaveChanges();
}