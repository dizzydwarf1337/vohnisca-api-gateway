using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Note.SetNoteVisibility;

public class SetNoteVisibilityCommandHandler : IRequestHandler<SetNoteVisibilityCommand, ApiResponse<NoteData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetNoteVisibilityCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<NoteData>> Handle(SetNoteVisibilityCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetNoteVisibility(request.NoteId, request.IsPublic, request.UserId!.Value.ToString());
        return result.ToApiResponse(x => x.Note, "Error setting note visibility");
    }
}