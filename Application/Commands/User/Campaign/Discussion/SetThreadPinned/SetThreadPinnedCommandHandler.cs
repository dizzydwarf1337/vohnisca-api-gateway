using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.SetThreadPinned;

public class SetThreadPinnedCommandHandler : IRequestHandler<SetThreadPinnedCommand, ApiResponse<ThreadData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetThreadPinnedCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ThreadData>> Handle(SetThreadPinnedCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetThreadPinned(request.ThreadId, request.IsPinned, request.Token);
        return result.ToApiResponse(x => x.Thread, "Error pinning thread");
    }
}