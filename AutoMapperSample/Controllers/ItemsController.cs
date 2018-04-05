using System;
using System.Linq;
using System.Web.OData;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperSample.Models;

namespace AutoMapperSample.Controllers
{
    public class ItemsController : ODataController
    {
        private readonly EntityFrameworkTesting _entityFrameworkTesting;

        public ItemsController()
        {
            _entityFrameworkTesting = new EntityFrameworkTesting();
        }

        [EnableQuery]
        public IQueryable<DtoItem> Get()
        {
            try
            {
                MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
                {
                });

                IMapper mapper = new Mapper(mapperConfiguration);

                return _entityFrameworkTesting.Items.ProjectTo<DtoItem>(mapper.ConfigurationProvider);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    //public class ProfileDtoItem : Profile
    //{
    //    public ProfileDtoItem()
    //    {
    //        CreateMap<Item, DtoItem>()
    //            .PreserveReferences()
    //            .ForMember(
    //                dto => dto.Amount,
    //                entity =>
    //                {
    //                    entity.MapFrom(source => source.SubGroups.Sum(s => s.Quantity));
    //                    entity.SetMappingOrder(1);
    //                });
    //    }
    //}

    //public class ProfileDtoCustomer : Profile
    //{
    //    public ProfileDtoCustomer()
    //    {
    //        CreateMap<Customer, DtoCustomer>()
    //            .PreserveReferences()
    //            .ForMember(
    //                dto => dto.FullName,
    //                entity =>
    //                {
    //                    entity.MapFrom(source => source.FirstName + " " + source.LastName);
    //                    entity.SetMappingOrder(1);
    //                });
    //    }
    //}
}
