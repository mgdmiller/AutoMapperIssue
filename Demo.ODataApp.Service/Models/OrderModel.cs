using System.Collections.Generic;

namespace Demo.ODataApp.Service.Models
{
    public class OrderModel : ApiModel
    {
        public IEnumerable<OrderPositionModel> Positions { get; set; }
    }
}