using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web.OData;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace AutoMapperSample.Controllers
{
    public class EntityFrameworkTesting : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public EntityFrameworkTesting() : base("EntityFrameworkTesting")
        {
            Database.SetInitializer<EntityFrameworkTesting>(null);
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<Item>()
                .HasRequired(entity => entity.Customer)
                .WithMany(entity => entity.Items)
                .HasForeignKey(entity => entity.CustomerId);

            dbModelBuilder.Entity<Item>()
                .HasMany(entity => entity.SubGroups)
                .WithRequired(entity => entity.Item)
                .HasForeignKey(entity => entity.ItemId);
        }
    }

    public class ProfileDtoItem : Profile
    {
        public ProfileDtoItem()
        {
            CreateMap<Item, DtoItem>()
                .ForMember(
                    dto => dto.Amount,
                    entity =>
                    {
                        entity.MapFrom(source => source.SubGroups.Sum(s => s.Quantity));
                    });
        }
    }

    public class ProfileDtoCustomer : Profile
    {
        public ProfileDtoCustomer()
        {
            CreateMap<Customer, DtoCustomer>()
                .ForMember(
                    dto => dto.FullName,
                    entity =>
                    {
                        entity.MapFrom(source => source.FirstName + " " + source.LastName);
                    });
        }
    }

    [Table("Item")]
    public class Item
    {
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual ICollection<SubGroup> SubGroups { get; set; }
    }

    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }

    [Table("SubGroup")]
    public class SubGroup
    {
        public int Id { get; set; }

        public virtual Item Item { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }

    public class DtoItem
    {
        public int Id { get; set; }

        public int? Amount { get; set; }

        public virtual DtoCustomer Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual ICollection<DtoSubGroup> SubGroups { get; set; }
    }

    public class DtoCustomer
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<DtoItem> Items { get; set; }
    }

    public class DtoSubGroup
    {
        public int Id { get; set; }

        public virtual DtoItem Item { get; set; }

        public int ItemId { get; set; }
    }

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
            //return _entityFrameworkTesting.Items;


            try
            {
                MapperConfiguration mapperConfiguration = new MapperConfiguration(c => { c.AddProfile<ProfileDtoItem>(); c.AddProfile<ProfileDtoCustomer>(); });

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
}
