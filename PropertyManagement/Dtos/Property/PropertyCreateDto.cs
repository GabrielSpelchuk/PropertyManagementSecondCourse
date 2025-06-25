namespace PropertyManagement.Dtos.Property
{
    public class PropertyCreateDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public int PropertyTypeId { get; set; }
    }
}
