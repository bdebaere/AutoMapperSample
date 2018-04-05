using System.Collections.Generic;

namespace AutoMapperSample.Models
{
    public class DtoItem
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }

        public virtual ICollection<DtoSubGroup> SubGroups { get; set; }
    }
}
