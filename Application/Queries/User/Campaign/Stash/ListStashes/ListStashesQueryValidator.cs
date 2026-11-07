using FluentValidation;

namespace Application.Queries.User.Campaign.Stash.ListStashes;

public class ListStashesQueryValidator : AbstractValidator<ListStashesQuery>
{
    public ListStashesQueryValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
    }
}