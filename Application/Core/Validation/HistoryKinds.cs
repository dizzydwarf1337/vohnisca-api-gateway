namespace Application.Core.Validation;

// The operations a campaign journal knows (App\Enums\HistoryKind on the campaign service). The names
// travel over the wire and are frozen: a kind is added together with the stage that writes it.
public static class HistoryKinds
{
    public const string CardAttached = "card-attached";
    public const string CardDetached = "card-detached";
    public const string ItemFound = "item-found";
    public const string ItemGiven = "item-given";
    public const string ItemReturned = "item-returned";
    public const string ItemDropped = "item-dropped";
    public const string Purchase = "purchase";
    public const string Sale = "sale";
    public const string CoinsAdded = "coins-added";
    public const string CoinsSpent = "coins-spent";
    public const string Revealed = "revealed";
    public const string ApprovalRequested = "approval-requested";
    public const string ApprovalGranted = "approval-granted";
    public const string ApprovalRejected = "approval-rejected";
    public const string TransferPending = "transfer-pending";
    public const string TransferFailed = "transfer-failed";
    public const string TransferDone = "transfer-done";

    public static readonly string[] All =
    [
        CardAttached, CardDetached, ItemFound, ItemGiven, ItemReturned, ItemDropped,
        Purchase, Sale, CoinsAdded, CoinsSpent, Revealed,
        ApprovalRequested, ApprovalGranted, ApprovalRejected,
        TransferPending, TransferFailed, TransferDone,
    ];

    public static bool IsKnown(string? kind) => kind is null || All.Contains(kind);
}