namespace ApplicationLayer.Handlers.MakeApplication.Interfaces;


using FunderApi;
using Models;

internal interface IMakeApplicationActivityFailedResponseMapper
{
    MakeApplicationActivityResponse Map(int quoteId, SendApplicationRequest funderRequest, GenericErrorResponse funderResponse);
    MakeApplicationActivityResponse Map(int quoteId, string errorMessage, SendApplicationRequest funderRequest, GenericErrorResponse funderResponse = null);
}

