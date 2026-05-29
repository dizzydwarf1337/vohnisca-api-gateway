using FluentValidation;

namespace Application.Queries.User.Campaign.Chapter.ListCampaignChapters;

public class ListCampaignChaptersQueryValidator : AbstractValidator<ListCampaignChaptersQuery>
{
    public ListCampaignChaptersQueryValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
    }
}