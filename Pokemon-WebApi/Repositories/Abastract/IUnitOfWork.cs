namespace Pokemon_WebApi.Repositories.Abastract;

public interface IUnitOfWork
{
    IEfCoreRepository<T> Repository<T>() where T 
        : class;
    Task<int> SaveAsync();
    int Save();
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
