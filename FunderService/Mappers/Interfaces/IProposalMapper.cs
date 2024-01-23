namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;

    internal interface IProposalMapper
    {
        Proposal Map(ApplicationRequest applicationRequest);
    }
}