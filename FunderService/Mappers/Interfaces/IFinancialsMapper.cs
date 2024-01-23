namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;

    internal interface IFinancialsMapper
    {
        Financials Map(ApplicationRequest applicationRequest);
    }
}