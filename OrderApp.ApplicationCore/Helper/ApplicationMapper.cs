using AutoMapper;
using OrderApp.ApplicationCore.Model.Request;
using OrderApp.ApplicationCore.Model.Response;

namespace OrderApp.ApplicationCore.Helper;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Order,OrderRequestModel>().ReverseMap();
        CreateMap<Order, OrderResponseModel>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailRequestModel>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailResponseModel>().ReverseMap();
    }
}