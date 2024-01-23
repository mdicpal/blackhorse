namespace ApplicationLayer.Handlers.Amendments.Interfaces;

using FunderApi;
using Models;

internal interface IAmendSubmitSuccessResponseMapper
{
    AmendSubmitActivityResponse Map(int quoteId, string customer_id, string proposal_id, PostSubmitResponse funderResponse);
}