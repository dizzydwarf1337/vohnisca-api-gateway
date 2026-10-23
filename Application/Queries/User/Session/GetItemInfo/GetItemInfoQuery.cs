using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetItemInfo;

// An item's details.
public class GetItemInfoQuery : UserRequest<ItemInfoData>
{
    public Guid SessionId { get; set; }
    public Guid ItemId { get; set; }
}
