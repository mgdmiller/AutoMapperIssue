using System.Collections.Generic;

namespace Demo.ODataApp.Service.Domain
{
    public class Order : BaseDomainObject
    {
        public virtual ICollection<OrderPosition> Positions { get;  } = new List<OrderPosition>();
    }
}