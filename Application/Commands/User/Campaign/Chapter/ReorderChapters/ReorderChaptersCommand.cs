using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.ReorderChapters;

public class ReorderChaptersCommand : UserRequest<Unit>
{
    public required string CampaignId { get; set; }
    public string? ParentId { get; set; }
    public List<string> OrderedIds { get; set; } = [];
}