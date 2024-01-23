namespace ApplicationLayer.Models;

public class SendErrorToServiceBusActivityRequest
{
    public int QuoteId { get; init; }
    public ApplicationReference ApplicationReference { get; set; }
    public string ErrorMessage { get; init; }
}