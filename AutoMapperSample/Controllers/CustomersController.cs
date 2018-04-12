using System;
using System.Linq;
using System.Web.OData;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperSample.Models;

namespace AutoMapperSample.Controllers
{
    public class CustomersController : ODataController
    {
        private readonly EntityFrameworkTesting _entityFrameworkTesting;

        public CustomersController()
        {
            _entityFrameworkTesting = new EntityFrameworkTesting();
        }

        [EnableQuery]
        public IQueryable<DtoCustomer> Get()
        {
            try
            {
                MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
                {
                    c.CreateMap<Customer, DtoCustomer>()
                        .ForMember(
                            dto => dto.Description,
                            entity => entity.MapFrom(source => source.FirstName));

                    c.CreateMap<Customer, DtoCustomer>()
                        .ForMember(
                            dto => dto.ItemCount,
                            entity => entity.MapFrom(source => source.Items.Count));

                    c.Advanced.AllowAdditiveTypeMapCreation = true;
                });

                IMapper mapper = new Mapper(mapperConfiguration);
                
                return _entityFrameworkTesting.Customers.ProjectTo<DtoCustomer>(mapper.ConfigurationProvider);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
