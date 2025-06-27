using FluentValidation;
using PropertyManagement.BLL.Dtos.Property;

namespace PropertyManagement.BLL.Validation.Property
{
    public class PropertyCreateDtoValidator : AbstractValidator<PropertyCreateDto>
    {
        public PropertyCreateDtoValidator()
        {
            RuleFor(p => p.Title).NotEmpty().MaximumLength(100);
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Description).MaximumLength(255);
            RuleFor(p => p.OwnerId).GreaterThan(0);
            RuleFor(p => p.PropertyTypeId).GreaterThan(0);
        }
    }
}
