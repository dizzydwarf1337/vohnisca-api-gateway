using FluentValidation;

namespace Application.Queries.User.Campaign.Discussion.GetUnreadCounts;

public class GetUnreadCountsQueryValidator : AbstractValidator<GetUnreadCountsQuery>
{
    public GetUnreadCountsQueryValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
    }
}