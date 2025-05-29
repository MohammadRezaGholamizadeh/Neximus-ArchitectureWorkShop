namespace Neximus.WorkShop.Services.Infrastructures.Contracts;

public interface IUnitOfWork : IRepository
{
    Task Save();
    Task BeginTransaction();
    Task CommitTransaction();
}