using FluentValidation;

namespace PropertyManagement.BLL.Validation.PropertyType
{
    public class PropertyTypeQueryValidator : AbstractValidator<PropertyTypeQueryParameters>
    {
        public PropertyTypeQueryValidator()
        {
            RuleFor(pt => pt.Page).GreaterThan(0);
            RuleFor(pt => pt.PageSize).InclusiveBetween(1, 100);
        }
    }
}
