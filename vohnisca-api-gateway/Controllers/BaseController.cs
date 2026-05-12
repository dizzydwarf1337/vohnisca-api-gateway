using Application.Core.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers;

[Route("api")]
[ApiController]
public class BaseController : Controller
{
    private IMediator? _mediator;
    private IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected async Task<IActionResult> HandleResponse<T>(IRequest<ApiResponse<T>> command)
    {
        var result = await Mediator.Send(command);
        return StatusCode(result.StatusCode, result);
    }
}