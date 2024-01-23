namespace ApplicationLayer.Handlers.Amendments.Interfaces;

using ApplicationLayer.Handlers.MakeApplication.Models;
using FunderApi;
using Models;

internal interface IAmendApplicationActivityFailedResponseMapper
{
    AmendApplicationActivityResponse Map(int quoteId, SendApplicationRequest funderRequest, GenericErrorResponse funderResponse);
    AmendApplicationActivityResponse Map(int quoteId, string errorMessage, SendApplicationRequest funderRequest, GenericErrorResponse funderResponse = null);
}