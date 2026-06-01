namespace vohnisca_api_gateway.Core.Requests;

public enum FileType
{
    ImageJpeg,
    ImagePng,
    ImageWebp,
    ImageGif,
    ImageSvg,
    PdfDocument,
    TextPlain,
    TextCsv,
    VideoMp4,
    VideoWebm,
    AudioMp3,
    AudioWav,
    ApplicationJson,
    ApplicationZip,
}

public static class GetFileContent
{
    private static readonly Dictionary<FileType, string> ContentTypeMap = new()
    {
        [FileType.ImageJpeg] = "image/jpeg",
        [FileType.ImagePng] = "image/png",
        [FileType.ImageWebp] = "image/webp",
        [FileType.ImageGif] = "image/gif",
        [FileType.ImageSvg] = "image/svg+xml",
        [FileType.PdfDocument] = "application/pdf",
        [FileType.TextPlain] = "text/plain",
        [FileType.TextCsv] = "text/csv",
        [FileType.VideoMp4] = "video/mp4",
        [FileType.VideoWebm] = "video/webm",
        [FileType.AudioMp3] = "audio/mpeg",
        [FileType.AudioWav] = "audio/wav",
        [FileType.ApplicationJson] = "application/json",
        [FileType.ApplicationZip] = "application/zip",
    };

    public static async Task<(byte[]? Bytes, string? ContentType)> GetAsync(
        IFormFile? file,
        IReadOnlyCollection<FileType> allowedTypes)
    {
        if (file is not { Length: > 0 })
            return (null, null);

        if (allowedTypes.Count > 0)
        {
            var allowedMimeTypes = allowedTypes.Select(t => ContentTypeMap[t]).ToHashSet();

            if (!allowedMimeTypes.Contains(file.ContentType))
            {
                var allowed = string.Join(", ", allowedTypes.Select(t => ContentTypeMap[t]));
                throw new InvalidOperationException(
                    $"Invalid file type '{file.ContentType}'. Allowed: {allowed}");
            }
        }

        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        return (ms.ToArray(), file.ContentType);
    }
}