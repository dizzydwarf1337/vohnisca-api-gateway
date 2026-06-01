using FluentValidation;

namespace Application.Commands.User.Campaign.Chapter.RevokeChapterAccess;

public class RevokeChapterAccessCommandValidator : AbstractValidator<RevokeChapterAccessCommand>
{
    public RevokeChapterAccessCommandValidator()
    {
        RuleFor(x => x.ChapterId).NotEmpty();
        RuleFor(x => x.TargetUserIds).NotEmpty();
        RuleForEach(x => x.TargetUserIds).NotEmpty();
    }
}