namespace Orchestrator.Extensions;

using Azure.Messaging.ServiceBus;
using AzureFunderCommonMessages.DotNet.Response;

public static class ServiceBusApplicationSettingsExtension
{
    public static void SetApplicationPropertiesFromMessage(
        this ServiceBusMessage serviceBusMessage,
        CommonResponse response,
        string serviceBusRequestType = "Response"
    )
    {
        serviceBusMessage.ApplicationProperties.Add("requestType", serviceBusRequestType);
        serviceBusMessage.ApplicationProperties.Add("quoteId", response.QuoteId);
        serviceBusMessage.ApplicationProperties.Add("funderCode", response.FunderCode.ToString());
    }
        
}