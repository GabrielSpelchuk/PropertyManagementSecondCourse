using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Dtos.PropertyType
{
    public class PropertyTypeCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
