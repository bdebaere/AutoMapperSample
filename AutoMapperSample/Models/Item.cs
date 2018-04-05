using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapperSample.Controllers;

namespace AutoMapperSample.Models
{
    [Table("Item")]
    public class Item
    {
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual ICollection<SubGroup> SubGroups { get; set; }
    }
}