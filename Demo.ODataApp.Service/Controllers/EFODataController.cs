using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.QueryableExtensions;
using Demo.ODataApp.Service.Context;
using Demo.ODataApp.Service.Domain;
using Microsoft.AspNet.OData;

namespace Demo.ODataApp.Service.Controllers
{
    public abstract class EfODataController<TEntity, TModel> : ODataController
        where TEntity : BaseDomainObject
        where TModel : class
    {
        private readonly OrdersContext _context;
        private readonly IMapper _mapper;

        protected EfODataController(OrdersContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        public IQueryable<TModel> Get()
        {
            // Good behaivour
            //return _context.Set<TEntity>().ProjectTo<TModel>(_mapper.ConfigurationProvider);
            // Bad behaivour
            return _context.Set<TEntity>().UseAsDataSource(_mapper).For<TModel>();
        }

        [EnableQuery]
        public virtual SingleResult<TEntity> Get([FromODataUri] long key)
        {
            return SingleResult.Create(_context.Set<TEntity>().Where(x => x.Id == key));
        }
    }
}