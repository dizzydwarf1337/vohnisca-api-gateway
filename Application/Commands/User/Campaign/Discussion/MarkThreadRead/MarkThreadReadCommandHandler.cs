using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.MarkThreadRead;

public class MarkThreadReadCommandHandler : IRequestHandler<MarkThreadReadCommand, ApiResponse<ThreadReadResponse>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public MarkThreadReadCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ThreadReadResponse>> Handle(MarkThreadReadCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.MarkThreadRead(request.ThreadId, request.Token);
        return result.ToApiResponse(x => x, "Error marking thread read");
    }
}