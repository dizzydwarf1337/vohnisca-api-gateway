using Application.Core.Mediatr.Requests.AdminRequest;
using MediatR;

namespace Application.Commands.Admin.Mail;

public class SendMailCommand : AdminRequest<Unit>
{
    public required string Email { get; set; }
    public required string Subject { get; set; }
    public required string Content { get; set; }
}