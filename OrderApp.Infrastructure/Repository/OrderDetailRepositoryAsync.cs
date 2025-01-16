using OrderApp.ApplicationCore;
using OrderApp.ApplicationCore.Contracts.Repository;
using OrderApp.Infrastructure.Data;

namespace OrderApp.Infrastructure.Repository;

public class OrderDetailRepositoryAsync :BaseRepositoryAsync<OrderDetail>, IOrderDetailRepositoryAsync
{
    public OrderDetailRepositoryAsync(OrderAppDbContext dbContext) : base(dbContext)
    {
    }
}