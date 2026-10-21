using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.UpdateCharacterAvatar;

public class UpdateCharacterAvatarCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}
