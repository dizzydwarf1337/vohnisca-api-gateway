using FluentValidation;

namespace Application.Commands.User.Campaign.Campaign.UpdateMemberRole;

public class UpdateMemberRoleCommandValidator : AbstractValidator<UpdateMemberRoleCommand>
{
    public UpdateMemberRoleCommandValidator()
    {
        RuleFor(x => x.Role).NotEmpty();
    }
}