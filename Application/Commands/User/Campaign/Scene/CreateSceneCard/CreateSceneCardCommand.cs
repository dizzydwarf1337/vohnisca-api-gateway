using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Validation;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Scene.CreateSceneCard;

// A scene is a card of kind "scene": a table scene (a map level that the table will load) or a handout
// (rich text with a picture). The level itself lives in the workshop; the card only points at it.
public class CreateSceneCardCommand : UserRequest<CampaignCardData>
{
    public Guid CampaignId { get; set; }
    public Guid? ChapterId { get; set; }
    public string SceneType { get; set; } = SceneTypes.Handout;
    public Guid? MapId { get; set; }
    // A workshop level id is not a uuid (CreateSceneCardRequest: string|max:64).
    public string? LevelId { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public string? ContentFormat { get; set; }
}