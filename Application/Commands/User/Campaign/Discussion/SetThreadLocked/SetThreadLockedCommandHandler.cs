using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.SetThreadLocked;

public class SetThreadLockedCommandHandler : IRequestHandler<SetThreadLockedCommand, ApiResponse<ThreadData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetThreadLockedCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ThreadData>> Handle(SetThreadLockedCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetThreadLocked(request.ThreadId, request.IsLocked, request.Token);
        return result.ToApiResponse(x => x.Thread, "Error locking thread");
    }
}