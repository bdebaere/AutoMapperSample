using System.Collections.Generic;

namespace AutoMapperSample.Models
{
    public class DtoItemWithCustomer
    {
        public int Id { get; set; }

        public virtual DtoCustomer Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual ICollection<DtoSubGroup> SubGroups { get; set; }
    }
}
