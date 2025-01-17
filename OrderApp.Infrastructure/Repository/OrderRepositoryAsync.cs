using Microsoft.EntityFrameworkCore;
using OrderApp.ApplicationCore;
using OrderApp.ApplicationCore.Contracts.Repository;
using OrderApp.Infrastructure.Data;

namespace OrderApp.Infrastructure.Repository;

public class OrderRepositoryAsync : BaseRepositoryAsync<Order>,IOrderRepositoryAsync
{
    public OrderRepositoryAsync(OrderAppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
    {
        return await dbContext.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
    }
}