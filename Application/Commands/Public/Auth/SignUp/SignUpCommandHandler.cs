using Application.Core.ApiResponse;
using Application.Interfaces.GrpcClients;
using MediatR;

namespace Application.Commands.Public.Auth.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, ApiResponse<SignUpResult>>
{
    private readonly IAuthGrpcClient _authGrpcClient;
    
    public SignUpCommandHandler(IAuthGrpcClient authGrpcClient)
        => _authGrpcClient = authGrpcClient;
    
    public async Task<ApiResponse<SignUpResult>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
       return ApiResponse<SignUpResult>.Success(await _authGrpcClient.SignUpAsync(request.Email, request.Password, request.Password_confimation, request.name));
    }
}