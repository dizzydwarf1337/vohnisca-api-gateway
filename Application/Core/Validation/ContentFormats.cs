namespace Application.Core.Validation;

// The formats the campaign service stores for a chapter or a note. A request that says nothing keeps
// whatever the text already is, so null is allowed through.
public static class ContentFormats
{
    public const string Text = "text";
    public const string Html = "html";

    public static bool IsKnown(string? format) => format is null or Text or Html;
}
