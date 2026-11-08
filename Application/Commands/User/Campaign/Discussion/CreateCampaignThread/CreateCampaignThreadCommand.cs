using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Validation;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.CreateCampaignThread;

// A topic of the campaign's own forum. Who may read it is decided server-side: the whole campaign ("all")
// or the game masters only ("gm").
public class CreateCampaignThreadCommand : UserRequest<ThreadData>
{
    public Guid CampaignId { get; set; }
    public string Title { get; set; }
    public string Visibility { get; set; } = ThreadVisibilities.All;
}