using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.SetItemVisibility;

public class SetWorkshopItemVisibilityCommand : UserRequest<bool>
{
    public Guid ItemId { get; set; }
    public string Visibility { get; set; } = "Private";
}
