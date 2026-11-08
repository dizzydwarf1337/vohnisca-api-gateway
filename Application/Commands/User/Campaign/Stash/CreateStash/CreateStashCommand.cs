using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Stash.CreateStash;

// A stash is a card of kind "stash": a camp, a cart, a hiding place — each with its own coins and access.
public class CreateStashCommand : UserRequest<StashData>
{
    public Guid CampaignId { get; set; }
    public Guid? ChapterId { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public string? ContentFormat { get; set; }
}