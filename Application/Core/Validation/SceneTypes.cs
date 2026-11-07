namespace Application.Core.Validation;

// The two things a scene card can be: a level the table loads, or a handout the players read.
public static class SceneTypes
{
    public const string Table = "table";
    public const string Handout = "handout";

    public static bool IsKnown(string? sceneType) => sceneType is Table or Handout;
}