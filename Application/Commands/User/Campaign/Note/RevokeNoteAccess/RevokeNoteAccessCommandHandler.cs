using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Note.RevokeNoteAccess;

public class RevokeNoteAccessCommandHandler : IRequestHandler<RevokeNoteAccessCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public RevokeNoteAccessCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(RevokeNoteAccessCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.RevokeNoteAccess(request.NoteId, request.TargetUserId, request.UserId!.Value.ToString());
        return result.ToApiResponse(_ => Unit.Value, "Error revoking note access");
    }
}