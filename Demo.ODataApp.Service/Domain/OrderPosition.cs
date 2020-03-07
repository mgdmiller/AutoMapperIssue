namespace Demo.ODataApp.Service.Domain
{
    public class OrderPosition : BaseDomainObject
    {
        public virtual Order Order { get; set; }

        public int Amount { get; set; }
    }
}