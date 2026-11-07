using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Stash.ApproveItemTake;

public class ApproveItemTakeCommandHandler : IRequestHandler<ApproveItemTakeCommand, ApiResponse<ItemRequestData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ApproveItemTakeCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ItemRequestData>> Handle(ApproveItemTakeCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ApproveItemTake(request.RequestId, request.Token);
        return result.ToApiResponse(x => x.ItemRequest, "Error approving item take");
    }
}