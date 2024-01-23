namespace ApplicationLayer.Handlers.Amendments.Interfaces
{
    using ApplicationLayer.Handlers.Amendments.Models;
    using FunderApi;
    using System;

    internal interface IAmendSubmitActivityFailedResponseMapper
    {
        AmendSubmitActivityResponse Map(int quoteId, string customer_id, string proposal_id, Exception exception, GenericErrorResponse funderResponse);
    }
}