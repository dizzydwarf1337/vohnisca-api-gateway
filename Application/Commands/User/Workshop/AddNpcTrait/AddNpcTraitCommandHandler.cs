using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.AddNpcTrait;

public class AddNpcTraitCommandHandler : IRequestHandler<AddNpcTraitCommand, ApiResponse<NpcTraitAdded>>
{
    private readonly IWorkshopRpcClient _client;
    public AddNpcTraitCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<NpcTraitAdded>> Handle(AddNpcTraitCommand request, CancellationToken cancellationToken)
        => (await _client.AddNpcTrait(request, request.Token!)).ToApiResponse(x => x, "Error adding the trait");
}
