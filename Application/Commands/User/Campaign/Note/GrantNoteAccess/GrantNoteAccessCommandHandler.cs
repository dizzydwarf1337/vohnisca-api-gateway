using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Note.GrantNoteAccess;

public class GrantNoteAccessCommandHandler : IRequestHandler<GrantNoteAccessCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GrantNoteAccessCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(GrantNoteAccessCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GrantNoteAccess(request.NoteId, request.TargetUserId, request.Token!);
        return result.ToApiResponse(_ => Unit.Value, "Error granting note access");
    }
}