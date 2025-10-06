using Application.Core.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers;

[Route("api")]
[ApiController]
public class BaseController : Controller
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();



    protected IActionResult HandleResponse<T>(ApiResponse<T> result)
    {
        return StatusCode(result.StatusCode, result);
    }
}