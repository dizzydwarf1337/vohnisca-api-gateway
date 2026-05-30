using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Campaign.ListMembers;

public class ListMembersQuery : UserRequest<List<MemberData>>
{
    public Guid CampaignId { get; set; }
}