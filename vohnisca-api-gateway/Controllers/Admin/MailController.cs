using Application.Commands.Admin.Mail.SendMail;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.Admin;

[Route("admin/mail")]
public class MailController : BaseController
{
    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> SendMail(SendMailCommand command)
        => await HandleResponse(command);
}