using System.Data.Entity;
using AutoMapperSample.Models;

namespace AutoMapperSample.Controllers
{
    public class EntityFrameworkTesting : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

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
}
