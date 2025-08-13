using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.Public.Auth.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, ApiResponse<SignUpResult>>
{
    private readonly IAuthRpcClient _authGrpcClient;
    
    public SignUpCommandHandler(IAuthRpcClient authGrpcClient)
        => _authGrpcClient = authGrpcClient;
    
    public async Task<ApiResponse<SignUpResult>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var result = await _authGrpcClient.SignUpAsync(request.Email, request.Password, request.Password_confimation,
            request.name);
        return ApiResponse<SignUpResult>.Success(result);
    }
}