namespace PropertyManagement.BLL.Dtos.Property
{
    public class PropertyReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int OwnerName { get; set; }
        public int PropertyTypeName { get; set; }
    }
}
