using FluentValidation;
using Training.TagHelpers.Web.Pages;

namespace Training.TagHelpers.Web.Validators;

public class MemberRequestValidator : AbstractValidator<RegisterMemberRequest>
{
    public MemberRequestValidator()
    {
        RuleFor(request => request)
            .Must(NotBeJohnDoe)
            .WithMessage("you cannot register john")
            .When(request => request.FirstName is not null && request.LastName is not null);

        RuleFor(request => request.FirstName)
            .NotEmpty()
            .WithMessage("Your first name is missing")
            .MinimumLength(2);

        RuleFor(request => request.LastName)
            .NotEmpty()
            .WithMessage("Your last name is missing")
            .MinimumLength(2);

        RuleFor(request => request.Age)
            .GreaterThanOrEqualTo(18)
            .WithMessage("You must be an adult");
    }

    private bool NotBeJohnDoe(RegisterMemberRequest request)
    {
        return !(request.FirstName!.Equals("john", StringComparison.OrdinalIgnoreCase) &&
               request.LastName!.Equals("doe", StringComparison.OrdinalIgnoreCase));
    }
}