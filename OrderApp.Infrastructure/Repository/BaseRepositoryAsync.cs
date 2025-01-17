using Microsoft.EntityFrameworkCore;
using OrderApp.ApplicationCore.Contracts.Repository;
using OrderApp.Infrastructure.Data;

namespace OrderApp.Infrastructure.Repository;

public class BaseRepositoryAsync<T>: IRepositoryAsync<T> where T : class
{
    protected OrderAppDbContext dbContext;

    public BaseRepositoryAsync(OrderAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<int> InsertAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        return await dbContext.SaveChangesAsync();
    }

    public Task<int> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var t = await GetByIdAsync(id);
        dbContext.Remove(t);
        return await dbContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public Task<IEnumerable<T>> Search(Func<T, bool> predicate)
    {
        throw new NotImplementedException();
    }
}