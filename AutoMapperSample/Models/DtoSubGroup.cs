namespace AutoMapperSample.Models
{
    public class DtoSubGroup
    {
        public int Id { get; set; }

        public virtual DtoItem Item { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
