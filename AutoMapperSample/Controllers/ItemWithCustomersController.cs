using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperSample.Models;

namespace AutoMapperSample.Controllers
{
    public class ItemWithCustomersController : ODataController
    {
        private readonly EntityFrameworkTesting _entityFrameworkTesting;

        public ItemWithCustomersController()
        {
            _entityFrameworkTesting = new EntityFrameworkTesting();
        }

        [EnableQuery]
        public IQueryable<DtoItemWithCustomer> Get()
        {
            try
            {
                MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
                {
                });

                IMapper mapper = new Mapper(mapperConfiguration);

                return _entityFrameworkTesting.Items.ProjectTo<DtoItemWithCustomer>(mapper.ConfigurationProvider);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
