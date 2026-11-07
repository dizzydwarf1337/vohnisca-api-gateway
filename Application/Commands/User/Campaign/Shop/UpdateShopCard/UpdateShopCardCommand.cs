using System.Text.Json;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Shop.UpdateShopCard;

// A patch: the title and the text may change, and meta carries the shop's settings (isOpen,
// requiresApproval, markupPercent) — the campaign service validates them by kind.
public class UpdateShopCardCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ContentFormat { get; set; }
    public JsonElement? Meta { get; set; }
}