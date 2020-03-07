using AutoMapper;
using Demo.ODataApp.Service.Context;
using Demo.ODataApp.Service.Domain;
using Demo.ODataApp.Service.Models;

namespace Demo.ODataApp.Service.Controllers
{
    public class OrdersController : EfODataController<Order, OrderModel>
    {
        public OrdersController(OrdersContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}