using System.Text.Json;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.UpdateCampaignCard;

// Every field is optional: a card is patched, not replaced (the power of a card lives in its kind's
// meta, and the campaign service thin the incoming meta itself).
public class UpdateCampaignCardCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ContentFormat { get; set; }
    public JsonElement? Meta { get; set; }
    public string? BackgroundColor { get; set; }
    public int? Order { get; set; }
}