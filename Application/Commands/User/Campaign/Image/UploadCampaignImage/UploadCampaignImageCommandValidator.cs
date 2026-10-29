using FluentValidation;

namespace Application.Commands.User.Campaign.Image.UploadCampaignImage;

public class UploadCampaignImageCommandValidator : AbstractValidator<UploadCampaignImageCommand>
{
    private const int MaxBytes = 5 * 1024 * 1024;

    private static readonly string[] AllowedMimeTypes =
        ["image/png", "image/jpeg", "image/webp", "image/gif"];

    public UploadCampaignImageCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.Data).NotNull().Must(data => data is null || data.Length <= MaxBytes)
            .WithMessage("The image is larger than 5 MB.");
        RuleFor(x => x.MimeType).Must(mimeType => AllowedMimeTypes.Contains(mimeType))
            .WithMessage("Only PNG, JPEG, WebP and GIF images are accepted.");
    }
}
