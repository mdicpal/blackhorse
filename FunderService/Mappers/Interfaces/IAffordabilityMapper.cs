namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;

    internal interface IAffordabilityMapper
    {
        Affordability Map(Applicant applicant);
    }
}