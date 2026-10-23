using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Character.GetLevelUpPreview;

// What the next level of a class would give with the choices made so far (tried, not saved).
public class GetLevelUpPreviewQuery : UserRequest<LevelUpPreviewData>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public Dictionary<string, List<string>> Choices { get; set; } = new();
}
