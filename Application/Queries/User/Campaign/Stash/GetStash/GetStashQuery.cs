using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Stash.GetStash;

public class GetStashQuery : UserRequest<StashData>
{
    public Guid CardId { get; set; }
}