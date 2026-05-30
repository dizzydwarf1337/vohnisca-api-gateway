using FluentValidation;

namespace Application.Commands.User.Campaign.Campaign.AddMember;

public class AddMemberCommandValidator : AbstractValidator<AddMemberCommand>
{
    public AddMemberCommandValidator()
    {
        RuleFor(x => x.Role).NotEmpty();
    }
}