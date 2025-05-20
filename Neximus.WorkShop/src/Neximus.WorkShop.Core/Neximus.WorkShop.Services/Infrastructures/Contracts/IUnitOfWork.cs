namespace Neximus.WorkShop.Services.Infrastructures.Contracts
{
    public interface IUnitOfWork
    {
        Task Save();
        Task BeginTransaction();
        Task Commit();
    }
}
