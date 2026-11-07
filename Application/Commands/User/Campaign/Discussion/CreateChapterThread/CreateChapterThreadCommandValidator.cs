using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.CreateChapterThread;

public class CreateChapterThreadCommandValidator : AbstractValidator<CreateChapterThreadCommand>
{
    public CreateChapterThreadCommandValidator()
    {
        RuleFor(x => x.ChapterId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Visibility).Must(ThreadVisibilities.IsKnown)
            .WithMessage("Visibility must be 'all' or 'gm'.");
    }
}