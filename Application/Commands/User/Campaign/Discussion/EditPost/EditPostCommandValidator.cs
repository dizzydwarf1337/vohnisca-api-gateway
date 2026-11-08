using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.EditPost;

public class EditPostCommandValidator : AbstractValidator<EditPostCommand>
{
    public EditPostCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.Body).NotEmpty().MaximumLength(10000);
        RuleFor(x => x.BodyFormat).Must(ContentFormats.IsKnown)
            .WithMessage("BodyFormat must be 'text' or 'html'.");
    }
}