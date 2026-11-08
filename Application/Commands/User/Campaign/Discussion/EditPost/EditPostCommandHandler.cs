using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.EditPost;

public class EditPostCommandHandler : IRequestHandler<EditPostCommand, ApiResponse<PostData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public EditPostCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<PostData>> Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.EditPost(request.PostId, request.Body, request.BodyFormat, request.Token);
        return result.ToApiResponse(x => x.Post, "Error editing post");
    }
}