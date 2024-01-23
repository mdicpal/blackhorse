namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;

    internal interface IPostUploadRequestMapper
    {
        PostUploadRequest Map(DocumentRequest documentRequest);
    }
}