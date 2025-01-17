using AutoMapper;
using OrderApp.ApplicationCore;
using OrderApp.ApplicationCore.Contracts.Repository;
using OrderApp.ApplicationCore.Contracts.Service;
using OrderApp.ApplicationCore.Model.Request;
using OrderApp.ApplicationCore.Model.Response;

namespace OrderApp.Infrastructure.Services;

public class OrderDetailServiceAsync : IOrderDetailServiceAsync

{
    private readonly IOrderDetailRepositoryAsync _orderDetailRepository;
    private readonly IMapper _mapper;
    public OrderDetailServiceAsync(IOrderDetailRepositoryAsync productRepositoryAsync, IMapper mapper)
    {
        this._orderDetailRepository = productRepositoryAsync;
        this._mapper = mapper;
    }
    public async Task<IEnumerable<OrderDetailResponseModel>> GetAllOrderDetailsAsync()
    {
        var collection = await _orderDetailRepository.GetAllAsync();
        List<OrderDetailResponseModel> result = _mapper.Map<List<OrderDetailResponseModel>>(collection);
        return result;
    }

    public async Task<OrderDetailResponseModel> GetOrderDetailByIdAsync(int id)
    {
        var item = await _orderDetailRepository.GetByIdAsync(id);

        if (item != null)
        {
            return _mapper.Map<OrderDetailResponseModel>(item);
        }
        return null;
    }

    public Task<int> AddOrderDetailAsync(OrderDetailRequestModel model)
    {
        OrderDetail item = _mapper.Map<OrderDetail>(model);
        return _orderDetailRepository.InsertAsync(item);
    }

    public Task<int> UpdateOrderDetailAsync(int id,OrderDetailRequestModel model)
    {
        if (id == model.OrderDetailId)
        {
            OrderDetail item = _mapper.Map<OrderDetail>(model);

            return _orderDetailRepository.UpdateAsync(item);
        }
        return Task.Run(() => { return 0; });
    }

    public Task<int> DeleteOrderDetailAsync(int id)
    {
        return _orderDetailRepository.DeleteAsync(id);
    }
}