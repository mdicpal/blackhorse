namespace ApplicationLayer.Handlers.FunderUpdates.Interfaces;

using Models;

public interface IFunderUpdateHandler
{
    FunderUpdateResponse Run(ApplicationStatusResponse applicationStatusResponse);
}