using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapperSample.Models
{
    [Table("SubGroup")]
    public class SubGroup
    {
        public int Id { get; set; }

        public virtual Item Item { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}