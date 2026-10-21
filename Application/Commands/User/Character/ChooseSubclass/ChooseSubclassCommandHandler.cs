using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.ChooseSubclass;

public class ChooseSubclassCommandHandler : IRequestHandler<ChooseSubclassCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public ChooseSubclassCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(ChooseSubclassCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ChooseSubclass(request, request.Token!);
        return result.ToApiResponse(x => x, "Error choosing subclass");
    }
}
