using FluentValidation;

namespace PropertyManagement.Validation.Property
{
    public class PropertyQueryValidator : AbstractValidator<PropertyQueryParameters>
    {
        public PropertyQueryValidator()
        {
            RuleFor(p => p.Page).GreaterThan(0);
            RuleFor(p => p.PageSize).InclusiveBetween(1, 100);
            RuleFor(p => p.SortBy).Must(s => new[] { "price", "title" }.Contains(s.ToLower())).WithMessage("SortBy must be 'price' or 'title'");
        }
    }
}
