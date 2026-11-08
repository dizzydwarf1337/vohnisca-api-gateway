using FluentValidation;

namespace Application.Queries.User.Campaign.Discussion.ListChapterThreads;

public class ListChapterThreadsQueryValidator : AbstractValidator<ListChapterThreadsQuery>
{
    public ListChapterThreadsQueryValidator()
    {
        RuleFor(x => x.ChapterId).NotEmpty();
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
    }
}