namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;

    internal interface IOrganisationMapper
    {
        Organisation Map(Applicant applicant);
    }
}