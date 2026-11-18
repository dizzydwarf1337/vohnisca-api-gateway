using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.ResolveItemStack;

public class ResolveItemStackCommandHandler : IRequestHandler<ResolveItemStackCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public ResolveItemStackCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(ResolveItemStackCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ResolveItemStack(request, request.Token!);
        return result.ToApiResponse(x => x, "Error resolving the stack");
    }
}
