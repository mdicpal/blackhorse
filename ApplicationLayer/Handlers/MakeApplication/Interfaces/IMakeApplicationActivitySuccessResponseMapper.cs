namespace ApplicationLayer.Handlers.MakeApplication.Interfaces;

using FunderApi;
using Models;

internal interface IMakeApplicationActivitySuccessResponseMapper
{
    MakeApplicationActivityResponse Map(int quoteId, SendApplicationRequest funderRequest, SendApplicationResponse funderResponse);
}