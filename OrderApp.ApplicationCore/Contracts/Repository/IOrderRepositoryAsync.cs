namespace OrderApp.ApplicationCore.Contracts.Repository;

public interface IOrderRepositoryAsync: IRepositoryAsync<Order>
{
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
}