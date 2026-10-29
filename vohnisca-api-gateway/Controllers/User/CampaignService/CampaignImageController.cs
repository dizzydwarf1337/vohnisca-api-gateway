using Application.Commands.User.Campaign.Image.UploadCampaignImage;
using Application.Queries.User.Campaign.Image.GetCampaignImage;
using Microsoft.AspNetCore.Mvc;
using vohnisca_api_gateway.Core.Requests;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

[Route("campaign-images")]
public class CampaignImageController : BaseController
{
    // Multipart: "file" — the picture; the campaign it belongs to comes from the route.
    [HttpPost]
    [Route("/campaigns/{campaignId:guid}/images")]
    public async Task<IActionResult> UploadImage(Guid campaignId, [FromForm] IFormFile? file)
    {
        if (campaignId == Guid.Empty)
            return BadRequest();

        var (bytes, contentType) = await GetFileContent.GetAsync(file, [
            FileType.ImageJpeg, FileType.ImagePng, FileType.ImageWebp, FileType.ImageGif,
        ]);

        if (bytes is null || contentType is null)
            return BadRequest();

        return await HandleResponse(new UploadCampaignImageCommand
        {
            CampaignId = campaignId,
            Data = bytes,
            MimeType = contentType,
        });
    }

    // A chapter may be game-master-only, so the picture is not a public URL: the caller's token decides
    // who gets the bytes, and the browser holds them as a blob.
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetImage(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        var result = await Send(new GetCampaignImageQuery { ImageId = id });

        if (!result.IsSuccess || result.Value is null)
            return StatusCode(result.StatusCode, result);

        Response.Headers.CacheControl = "private, max-age=31536000, immutable";

        return File(Convert.FromBase64String(result.Value.Data), result.Value.MimeType);
    }
}
