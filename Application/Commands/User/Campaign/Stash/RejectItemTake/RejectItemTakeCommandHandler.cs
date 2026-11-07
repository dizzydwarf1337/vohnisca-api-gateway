using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Stash.RejectItemTake;

public class RejectItemTakeCommandHandler : IRequestHandler<RejectItemTakeCommand, ApiResponse<ItemRequestData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public RejectItemTakeCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ItemRequestData>> Handle(RejectItemTakeCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.RejectItemTake(request.RequestId, request.Token);
        return result.ToApiResponse(x => x.ItemRequest, "Error rejecting item take");
    }
}