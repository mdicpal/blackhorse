namespace ApplicationLayer.Handlers.FunderUpdates.Models;

using ApplicationLayer.Models;
using FunderApi;

public class ApplicationStatusResponse
{
    public Decision StatusUpdate { get; set; }
    public int QuoteId { get; set; }
    public ApplicationReference ApplicationReference { get; set; }
}