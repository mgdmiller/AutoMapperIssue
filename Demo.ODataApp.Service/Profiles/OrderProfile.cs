using AutoMapper;
using Demo.ODataApp.Service.Domain;
using Demo.ODataApp.Service.Models;

namespace Demo.ODataApp.Service.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<BaseDomainObject, ApiModel>();
            CreateMap<Order, OrderModel>().IncludeBase<BaseDomainObject, ApiModel>();
            CreateMap<OrderPosition, OrderPositionModel>().IncludeBase<BaseDomainObject, ApiModel>();
        }
    }
}