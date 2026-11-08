using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.SetThreadHidden;

public class SetThreadHiddenCommandHandler : IRequestHandler<SetThreadHiddenCommand, ApiResponse<ThreadData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetThreadHiddenCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ThreadData>> Handle(SetThreadHiddenCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetThreadHidden(request.ThreadId, request.IsHidden, request.Token);
        return result.ToApiResponse(x => x.Thread, "Error hiding thread");
    }
}