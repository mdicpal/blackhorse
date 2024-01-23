namespace ApplicationLayer.Handlers;

using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Models;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using Interfaces;
using Models;

internal class CommonResponseMapper : ICommonResponseMapper
{
    private readonly string _funderCode;

    public CommonResponseMapper(string funderCode)
    {
        _funderCode = funderCode;
    }
    public CommonResponse<T> Map<T>(int quoteId, ApplicationReference applicationReference, T subMessage, object requestObject = null, object responseObject = null)
        where T : SubResponse, ISubResponseType, new()
    {
        var commonResponse = new CommonResponse<T>
        {
            FunderCode = _funderCode,
            QuoteId = quoteId,
            FunderReference = new FunderReference
            {
                Application = applicationReference.ProposalId.ToString(),
                Agreement = applicationReference.CustomerId.ToString()
            },
            SubResponse = subMessage
        };

        if (requestObject is not null)
        {
            commonResponse.AddRequestData(requestObject);
        }

        if (responseObject is not null)
        {
            commonResponse.AddResponseData(responseObject);
        }

        return commonResponse;
    }
}