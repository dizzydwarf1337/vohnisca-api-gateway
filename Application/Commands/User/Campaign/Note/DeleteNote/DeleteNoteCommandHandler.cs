using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Note.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public DeleteNoteCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.DeleteNote(request.NoteId, request.Token!);
        return result.ToApiResponse(_ => Unit.Value, "Error deleting note");
    }
}