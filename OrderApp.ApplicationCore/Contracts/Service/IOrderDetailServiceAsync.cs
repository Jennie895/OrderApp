using OrderApp.ApplicationCore.Model.Request;
using OrderApp.ApplicationCore.Model.Response;

namespace OrderApp.ApplicationCore.Contracts.Service;

public interface IOrderDetailServiceAsync
{
    Task<IEnumerable<OrderDetailResponseModel>> GetAllOrderDetailsAsync();
    Task<OrderDetailResponseModel> GetOrderDetailByIdAsync(int id);
    Task<int> AddOrderDetailAsync(OrderDetailRequestModel model);
    Task<int> UpdateOrderDetailAsync(int id,OrderDetailRequestModel orderDetail);
    Task<int> DeleteOrderDetailAsync(int id);
}