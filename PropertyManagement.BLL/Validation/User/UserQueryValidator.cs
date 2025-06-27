using FluentValidation;

namespace PropertyManagement.BLL.Validation.User
{
    public class UserQueryValidator : AbstractValidator<UserQueryParameters>
    {
        public UserQueryValidator()
        {
            RuleFor(u => u.Page).GreaterThan(0);
            RuleFor(u => u.PageSize).InclusiveBetween(1, 100);
        }
    }
}
