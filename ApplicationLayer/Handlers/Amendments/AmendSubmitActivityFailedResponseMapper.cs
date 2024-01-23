namespace ApplicationLayer.Handlers.Amendments;

using ApplicationLayer.Handlers.Amendments.Interfaces;
using ApplicationLayer.Handlers.Amendments.Models;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using FunderApi;
using Handlers.Interfaces;

internal class AmendSubmitActivityFailedResponseMapper : IAmendSubmitActivityFailedResponseMapper
{
    private readonly ICommonResponseMapper _commonResponseMapper;

    public AmendSubmitActivityFailedResponseMapper(ICommonResponseMapper commonResponseMapper)
    {
        _commonResponseMapper = commonResponseMapper;
    }
    public AmendSubmitActivityResponse Map(int quoteId, string customer_id, string proposal_id, Exception exception, GenericErrorResponse funderResponse)
    {
        List<string> errors = new() { exception.Message };
        FunderErrors subMessage = new(errors, "Failed to submit amendment to funder");
        CommonResponse<FunderErrors> commonResponse = _commonResponseMapper.Map(
            quoteId,
            null,
            subMessage,
            customer_id,
            funderResponse is not null? funderResponse : exception.Message
        );
        return new AmendSubmitActivityResponse { CommonResponses = { commonResponse }, Success = true };
    }
}
