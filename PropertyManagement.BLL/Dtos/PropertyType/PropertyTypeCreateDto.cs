using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.BLL.Dtos.PropertyType
{
    public class PropertyTypeCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
