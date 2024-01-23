namespace ApplicationLayer.Handlers.MakeApplication;

using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using FunderApi;
using Handlers.Interfaces;
using Interfaces;
using Models;


internal class MakeApplicationActivityFailedResponseMapper : IMakeApplicationActivityFailedResponseMapper
{
    private readonly ICommonResponseMapper _commonResponseMapper;

    public MakeApplicationActivityFailedResponseMapper(ICommonResponseMapper commonResponseMapper)
    {
        _commonResponseMapper = commonResponseMapper;
    }
    public MakeApplicationActivityResponse Map(int quoteId, SendApplicationRequest funderRequest, GenericErrorResponse funderResponse)
    {
        return Map(quoteId, funderResponse.ResponseMessage, funderRequest, funderResponse);
    }
    public MakeApplicationActivityResponse Map(int quoteId, string errorMessage, SendApplicationRequest funderRequest, GenericErrorResponse funderResponse = null)
    {
        List<string> errors = new() { errorMessage };
        FunderErrors subMessage = new(errors, "Failed to submit new proposal to funder");

        CommonResponse commonResponse = _commonResponseMapper.Map(
            quoteId,
            null,
            subMessage,
            funderRequest,
            funderResponse is not null ? funderResponse : errorMessage
        );

        return new MakeApplicationActivityResponse
        {
            CommonResponses = { commonResponse },
            Success = false
        };
    }
}