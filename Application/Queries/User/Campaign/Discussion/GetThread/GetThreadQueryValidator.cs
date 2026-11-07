using FluentValidation;

namespace Application.Queries.User.Campaign.Discussion.GetThread;

public class GetThreadQueryValidator : AbstractValidator<GetThreadQuery>
{
    public GetThreadQueryValidator()
    {
        RuleFor(x => x.ThreadId).NotEmpty();
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
    }
}