using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.DeleteSpell;

public class DeleteWorkshopSpellCommandHandler : IRequestHandler<DeleteWorkshopSpellCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public DeleteWorkshopSpellCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(DeleteWorkshopSpellCommand request, CancellationToken cancellationToken)
        => (await _client.DeleteSpell(request, request.Token!)).ToApiResponse(x => x, "Error deleting spell");
}
