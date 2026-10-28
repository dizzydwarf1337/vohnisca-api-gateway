using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.SetNpcImage;

public class SetNpcImageCommand : UserRequest<bool>
{
    public Guid NpcId { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
    public bool RemoveImage { get; set; }
}
