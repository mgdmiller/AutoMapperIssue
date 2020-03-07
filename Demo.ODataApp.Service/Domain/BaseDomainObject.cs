using System.ComponentModel.DataAnnotations;

namespace Demo.ODataApp.Service.Domain
{
    public abstract class BaseDomainObject
    {
        [Key]
        public long Id { get; set; }
    }
}