using Microsoft.EntityFrameworkCore.Storage;
using Pokemon_WebApi.Context;
using Pokemon_WebApi.Repositories.Abastract;
using System.Collections;

namespace Pokemon_WebApi.Repositories.Implementation;

internal class UnitOfWork : IUnitOfWork
{
    private readonly PokemonContext _context;
    IDbContextTransaction dbContextTransaction;
    private Hashtable _repositories;
    public UnitOfWork(PokemonContext context)
    {
        _context = context;
    }
    public IEfCoreRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        _repositories ??= new Hashtable();

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(EfCoreRepository<>);

            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IEfCoreRepository<TEntity>)_repositories[type];
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public int Save()
    {
        return _context.SaveChanges();
    }
    public void BeginTransaction()
    {
        dbContextTransaction = _context.Database.BeginTransaction();
    }
    public void CommitTransaction()
    {
        dbContextTransaction?.Commit();
    }
    public void RollbackTransaction()
    {
        dbContextTransaction?.Rollback();
    }
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
