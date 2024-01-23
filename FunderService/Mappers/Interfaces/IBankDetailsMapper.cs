namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;

    internal interface IBankDetailsMapper
    {
        BankDetails Map(Applicant applicant);
    }
}