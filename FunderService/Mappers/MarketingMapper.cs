namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;
    internal class MarketingMapper : IMarketingMapper
    {
        public Marketing Map(MarketingPreference marketingPreference)
        {
            return new Marketing()
            {
                Email = marketingPreference.OptInEmail,
                Mail = marketingPreference.OptInPost,
                Phone = marketingPreference.OptInPhone,
                Sms = marketingPreference.OptInSms
            };
        }
    }
}