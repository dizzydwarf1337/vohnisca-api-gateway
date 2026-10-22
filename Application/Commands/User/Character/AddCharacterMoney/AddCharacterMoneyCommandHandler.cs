using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.AddCharacterMoney;

public class AddCharacterMoneyCommandHandler : IRequestHandler<AddCharacterMoneyCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public AddCharacterMoneyCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(AddCharacterMoneyCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AddCharacterMoney(request, request.Token!);
        return result.ToApiResponse(x => x, "Error adding money");
    }
}
