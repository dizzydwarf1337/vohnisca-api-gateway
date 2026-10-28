using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.CreateSpell;

public class CreateWorkshopSpellCommandHandler : IRequestHandler<CreateWorkshopSpellCommand, ApiResponse<CreatedContent>>
{
    private readonly IWorkshopRpcClient _client;
    public CreateWorkshopSpellCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<CreatedContent>> Handle(CreateWorkshopSpellCommand request, CancellationToken cancellationToken)
        => (await _client.CreateSpell(request, request.Token!)).ToApiResponse(x => x, "Error creating spell");
}
