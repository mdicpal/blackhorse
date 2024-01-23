namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;

    internal interface IIndividualMapper
    {
       Individual Map(Applicant applicant);
    }
}