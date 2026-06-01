using Application.Commands.User.User.DeleteProfilePicture;
using Application.Commands.User.User.UpdateUserData;
using Application.Queries.User.User.GetUser;
using Application.Queries.User.User.Me.GetMe;
using Microsoft.AspNetCore.Mvc;
using vohnisca_api_gateway.Core.Requests;

namespace vohnisca_api_gateway.Controllers.User.UserService;

[Route("user")]
public class UserController : BaseController
{
    [HttpGet]
    [Route("get-me")]
    public async Task<IActionResult> GetMe()
        => await HandleResponse(new GetMeQuery());

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetUserQuery
        {
            Id = id
        });
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateUserData([FromForm] UpdateUserDataCommand command,
        [FromForm] IFormFile? file)
    {
        if (command == null)
            return BadRequest();

        var (bytes, contentType) =
            await GetFileContent.GetAsync(file,
                [FileType.ImageJpeg, FileType.ImagePng, FileType.ImageSvg, FileType.ImageWebp]);

        command.UserData.ProfilePicture = bytes;
        command.UserData.ProfilePictureContentType = contentType;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("delete-profile-picture")]
    public async Task<IActionResult> DeleteProfilePicture()
        => await HandleResponse(new DeleteProfilePictureCommand());
}