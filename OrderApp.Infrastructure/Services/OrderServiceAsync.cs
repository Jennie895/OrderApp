using AutoMapper;
using OrderApp.ApplicationCore;
using OrderApp.ApplicationCore.Contracts.Repository;
using OrderApp.ApplicationCore.Contracts.Service;
using OrderApp.ApplicationCore.Model.Request;
using OrderApp.ApplicationCore.Model.Response;

namespace OrderApp.Infrastructure.Services;

public class OrderServiceAsync : IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepository;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepository, IMapper mapper)
    {
        this._orderRepository = orderRepository;
        this._mapper = _mapper;
    }
    public async Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync()
    {
        var collection = await _orderRepository.GetAllAsync();
        List<OrderResponseModel> orders = _mapper.Map<List<OrderResponseModel>>(collection);
        return orders;
    }

    public async Task<OrderResponseModel> GetOrderByIdAsync(int id)
    {
        var item = await _orderRepository.GetByIdAsync(id);

        if (item != null)
        {
            return _mapper.Map<OrderResponseModel>(item);
        }
        return null;
    }

    
    public async Task<IEnumerable<OrderResponseModel>> GetOrdersByCustomerIdAsync(int customerId)
    {
        var item = await _orderRepository.GetOrdersByCustomerIdAsync(customerId);

        if (item != null)
        {
            return _mapper.Map<IEnumerable<OrderResponseModel>>(item);
        }

        return null;
    }

    public Task<int> AddOrderAsync(OrderRequestModel model)
    {
        
        Order item = _mapper.Map<Order>(model);
        return _orderRepository.InsertAsync(item);
    }

    public Task<int> UpdateOrderAsync(int id, OrderRequestModel model)
    {
        if (id == model.Id)
        {
            Order item = _mapper.Map<Order>(model);

            return _orderRepository.UpdateAsync(item);
        }
        return Task.Run(() => { return 0; });
    }

    public Task<int> DeleteOrderAsync(int id)
    {
        return _orderRepository.DeleteAsync(id);
    }
}