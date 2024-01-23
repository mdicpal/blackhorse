namespace ApplicationLayer.Handlers.Amendments.Interfaces;

using FunderApi;
using Models;

internal interface IAmendApplicationActivitySuccessResponseMapper
{
    AmendApplicationActivityResponse Map(int quoteId, SendApplicationRequest funderRequest, PutCustomerResponse funderResponse);
}