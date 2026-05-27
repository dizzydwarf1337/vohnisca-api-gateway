using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Campaign.ListMyCampaigns;

public class ListMyCampaignsQuery : UserRequest<List<CampaignData>>
{
}