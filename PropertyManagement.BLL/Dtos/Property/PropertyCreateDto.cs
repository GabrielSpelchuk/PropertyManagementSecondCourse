using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.BLL.Dtos.Property
{
    public class PropertyCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }

        [Range(0, 1_000_000)]
        public decimal Price { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public int PropertyTypeId { get; set; }
    }
}
