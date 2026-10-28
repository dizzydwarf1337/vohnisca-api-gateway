using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.RemoveNpcTrait;

public class RemoveNpcTraitCommandHandler : IRequestHandler<RemoveNpcTraitCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public RemoveNpcTraitCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(RemoveNpcTraitCommand request, CancellationToken cancellationToken)
        => (await _client.RemoveNpcTrait(request, request.Token!)).ToApiResponse(x => x, "Error removing the trait");
}
