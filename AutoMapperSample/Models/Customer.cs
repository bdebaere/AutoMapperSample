using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapperSample.Models
{
    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
