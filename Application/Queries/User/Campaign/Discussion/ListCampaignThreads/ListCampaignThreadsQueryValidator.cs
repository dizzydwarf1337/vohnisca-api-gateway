using FluentValidation;

namespace Application.Queries.User.Campaign.Discussion.ListCampaignThreads;

public class ListCampaignThreadsQueryValidator : AbstractValidator<ListCampaignThreadsQuery>
{
    public ListCampaignThreadsQueryValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
    }
}