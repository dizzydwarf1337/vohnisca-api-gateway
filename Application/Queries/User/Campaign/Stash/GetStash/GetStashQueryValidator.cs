using FluentValidation;

namespace Application.Queries.User.Campaign.Stash.GetStash;

public class GetStashQueryValidator : AbstractValidator<GetStashQuery>
{
    public GetStashQueryValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}