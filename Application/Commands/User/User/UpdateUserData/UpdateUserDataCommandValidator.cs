using FluentValidation;

namespace Application.Commands.User.User.UpdateUserData;

public class UpdateUserDataCommandValidator : AbstractValidator<UpdateUserDataCommand>
{
    public UpdateUserDataCommandValidator()
    {
        RuleFor(x => x.UserData).NotNull();
        RuleFor(x => x.UserData.UserName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.UserData.Bio).MaximumLength(1000);
    }
}