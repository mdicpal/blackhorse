namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;

    internal interface IAssetMapper
    {
        Asset Map(ApplicationRequest applicationRequest);
    }
}