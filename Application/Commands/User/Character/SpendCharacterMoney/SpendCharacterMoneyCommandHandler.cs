using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.SpendCharacterMoney;

public class SpendCharacterMoneyCommandHandler : IRequestHandler<SpendCharacterMoneyCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public SpendCharacterMoneyCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SpendCharacterMoneyCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SpendCharacterMoney(request, request.Token!);
        return result.ToApiResponse(x => x, "Error spending money");
    }
}
