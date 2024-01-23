namespace ApplicationLayer.Handlers.Amendments.Interfaces;

using FunderApi;
using Models;

public interface IAmendSubmitHandler
{
    Task<AmendSubmitActivityResponse> Run(AmendSubmitActivityRequest amendmentSubmitActivityRequest);
}