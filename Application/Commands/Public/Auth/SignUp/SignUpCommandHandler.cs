using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.Public.Auth.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, ApiResponse<SignUpCommand.Result>>
{
    private readonly IAuthRpcClient _authGrpcClient;
    
    public SignUpCommandHandler(IAuthRpcClient authGrpcClient)
        => _authGrpcClient = authGrpcClient;
    
    public async Task<ApiResponse<SignUpCommand.Result>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var result = await _authGrpcClient.SignUpAsync(request.Email, request.Password, request.PasswordConfirmation,
            request.Name);
        return result.IsSuccess
            ? ApiResponse<SignUpCommand.Result>.Success(new SignUpCommand.Result())
            : ApiResponse<SignUpCommand.Result>.Failure(result.Error ?? "Unknown error");
    }
}