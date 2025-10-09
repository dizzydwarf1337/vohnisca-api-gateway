using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.Public.Auth.ConfirmEmail;

public class ConfirmEmailCommand : UserRequest<Unit>
{
    public required string UserMail { get; set; }
    public required string Token { get; set; }
}