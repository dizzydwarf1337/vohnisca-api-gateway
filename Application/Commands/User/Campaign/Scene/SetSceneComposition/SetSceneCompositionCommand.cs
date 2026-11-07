using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Scene.SetSceneComposition;

// The encounter's composition: NPCs with how many of each, and workshop items with quantities. Five spiders
// are one entry with count 5 — there are no five cards. Players never see this part of the card.
public class SetSceneCompositionCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public List<SceneNpcEntry> Npcs { get; set; } = [];
    public List<SceneItemEntry> Items { get; set; } = [];
}