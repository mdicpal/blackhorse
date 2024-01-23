namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;
    using System.Collections.Generic;

    internal interface IMarketingMapper
    {
        Marketing Map(MarketingPreference marketingPreference);
    }
}