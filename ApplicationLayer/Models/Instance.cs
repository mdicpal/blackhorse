namespace ApplicationLayer.Models;

public class Instance
{
    public string ApplicationId { get; init; } = null!;
    public int QuoteId { get; init; }
    public string Id { get; init; }
    public string Status { get; init; }
    public bool IsInProgress()
    {
        bool isCompleted = Status?.ToLower() == "completed";
        bool hasInstanceId = Id is not null;

        return hasInstanceId && !isCompleted;
    }
}