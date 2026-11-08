using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.ThreadId).NotEmpty();
        RuleFor(x => x.Body).NotEmpty().MaximumLength(10000);
        RuleFor(x => x.BodyFormat).Must(ContentFormats.IsKnown)
            .WithMessage("BodyFormat must be 'text' or 'html'.");
    }
}