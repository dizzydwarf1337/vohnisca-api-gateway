using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.CreateCampaignThread;

public class CreateCampaignThreadCommandValidator : AbstractValidator<CreateCampaignThreadCommand>
{
    public CreateCampaignThreadCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Visibility).Must(ThreadVisibilities.IsKnown)
            .WithMessage("Visibility must be 'all' or 'gm'.");
    }
}