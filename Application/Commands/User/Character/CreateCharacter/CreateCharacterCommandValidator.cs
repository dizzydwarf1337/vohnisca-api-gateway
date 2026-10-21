using FluentValidation;

namespace Application.Commands.User.Character.CreateCharacter;

public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
{
    public CreateCharacterCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.RaceId).NotEmpty();
        RuleFor(x => x.BackgroundId).NotEmpty();
        RuleFor(x => x.ClassId).NotEmpty();
        RuleFor(x => x.Age).GreaterThanOrEqualTo(0);
    }
}
