using Auth; 
using Grpc.Core;
using Application.Interfaces.GrpcClients;

namespace Infrastructure.GrpcClients;

public class AuthGrpcClient : IAuthGrpcClient
{
    private readonly AuthService.AuthServiceClient _client;

    public AuthGrpcClient(AuthService.AuthServiceClient client)
    {
        _client = client;
    }

    public async Task<LoginResult> LoginAsync(string email, string password)
    {
        var request = new LoginRequest
        {
            Email = email,
            Password = password
        };

        try
        {
            var response = await _client.LoginAsync(request);
            return new LoginResult(response.AccessToken, response.TokenType, response.ExpiresIn);
        }
        catch (RpcException ex)
        {
            throw;
        }
    }

    public async Task<SignUpResult> SignUpAsync(string email, string password, string password_confirmation, string name)
    {
        var request = new SignUpRequest
        {
            Email = email,
            Password = password,
            PasswordConfirmation = password_confirmation,
            Name = name
        };

        try
        {
            var response = await _client.SignUpAsync(request);
            return new SignUpResult(response.Token); 
        }
        catch (RpcException ex)
        {
            throw;
        }
    }
}