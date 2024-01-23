namespace ApplicationLayer.Models;

using FunderApi;

public class FunderUpdate
{
    public Decision FunderResponse { get; set; } 
    public string InstanceId { get; set; }
    public bool HasChanged { get; set; }
}