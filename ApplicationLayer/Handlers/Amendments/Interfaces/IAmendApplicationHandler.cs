namespace ApplicationLayer.Handlers.Amendments.Interfaces;

using Models;

public interface IAmendApplicationHandler
{
    Task<AmendApplicationActivityResponse> Run(AmendApplicationActivityRequest request);
}