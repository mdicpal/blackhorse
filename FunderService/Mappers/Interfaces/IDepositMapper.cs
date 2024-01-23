namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;

    internal interface IDepositMapper
    {
        Deposit Map(ApplicationRequest applicationRequest);
    }
}