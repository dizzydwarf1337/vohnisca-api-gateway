using FluentValidation;

namespace Application.Commands.User.Campaign.Chapter.GrantChapterAccess;

public class GrantChapterAccessCommandValidator : AbstractValidator<GrantChapterAccessCommand>
{
    public GrantChapterAccessCommandValidator()
    {
        RuleFor(x => x.ChapterId).NotEmpty();
        RuleFor(x => x.TargetUserId).NotEmpty();
    }
}