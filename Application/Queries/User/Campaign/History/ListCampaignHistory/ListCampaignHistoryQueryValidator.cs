using Application.Core.Validation;
using FluentValidation;

namespace Application.Queries.User.Campaign.History.ListCampaignHistory;

public class ListCampaignHistoryQueryValidator : AbstractValidator<ListCampaignHistoryQuery>
{
    public ListCampaignHistoryQueryValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.Kind).Must(HistoryKinds.IsKnown)
            .WithMessage($"Kind must be one of {string.Join(", ", HistoryKinds.All)}.");
        RuleFor(x => x.From).LessThanOrEqualTo(x => x.To)
            .When(x => x.From is not null && x.To is not null)
            .WithMessage("From must not be later than To.");
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
    }
}