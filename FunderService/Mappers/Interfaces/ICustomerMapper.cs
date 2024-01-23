namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;

    public interface ICustomerMapper
    {
       SendApplicationRequest Map(ApplicationRequest applicationRequest, int? customerId, int? proposalId);
    }
}