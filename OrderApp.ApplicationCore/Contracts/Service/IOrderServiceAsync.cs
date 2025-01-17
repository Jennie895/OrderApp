using OrderApp.ApplicationCore.Model.Request;
using OrderApp.ApplicationCore.Model.Response;

namespace OrderApp.ApplicationCore.Contracts.Service;

public interface IOrderServiceAsync
{
    Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync();
    Task<OrderResponseModel> GetOrderByIdAsync(int id);
    Task<IEnumerable<OrderResponseModel>> GetOrdersByCustomerIdAsync(int customerId);
    Task<int> AddOrderAsync(OrderRequestModel model);
    Task<int> UpdateOrderAsync(int id, OrderRequestModel model);
    Task<int> DeleteOrderAsync(int id);
}