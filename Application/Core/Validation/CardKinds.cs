namespace Application.Core.Validation;

// The card kinds the campaign service knows (App\Enums\NoteKind). A kind without its own meta
// validator does not get added there, so this list is closed.
public static class CardKinds
{
    public const string Note = "note";
    public const string Npc = "npc";
    public const string Item = "item";
    public const string Shop = "shop";
    public const string Stash = "stash";
    public const string Scene = "scene";

    public static readonly string[] All = [Note, Npc, Item, Shop, Stash, Scene];

    public static bool IsKnown(string? kind) => kind is null || All.Contains(kind);
}