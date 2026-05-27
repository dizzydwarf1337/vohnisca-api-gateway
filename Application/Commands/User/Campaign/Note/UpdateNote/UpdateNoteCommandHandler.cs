using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Note.UpdateNote;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, ApiResponse<NoteData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public UpdateNoteCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<NoteData>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.UpdateNote(request.NoteId, request.Title, request.Content, request.UserId!.Value.ToString());
        return result.ToApiResponse(x => x.Note, "Error updating note");
    }
}