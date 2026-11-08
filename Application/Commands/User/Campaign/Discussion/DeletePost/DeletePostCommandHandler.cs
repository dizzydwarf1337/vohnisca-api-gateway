using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.DeletePost;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, ApiResponse<PostData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public DeletePostCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<PostData>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.DeletePost(request.PostId, request.Token);
        return result.ToApiResponse(x => x.Post, "Error deleting post");
    }
}