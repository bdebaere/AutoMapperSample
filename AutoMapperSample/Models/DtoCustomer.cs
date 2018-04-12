using System.Collections.Generic;

namespace AutoMapperSample.Models
{
    public class DtoCustomer
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ItemCount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<DtoItem> Items { get; set; }
    }
}
