using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.UpdateSpell;

public class UpdateWorkshopSpellCommandHandler : IRequestHandler<UpdateWorkshopSpellCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public UpdateWorkshopSpellCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UpdateWorkshopSpellCommand request, CancellationToken cancellationToken)
        => (await _client.UpdateSpell(request, request.Token!)).ToApiResponse(x => x, "Error updating spell");
}
