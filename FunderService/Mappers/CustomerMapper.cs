namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;

    internal class CustomerMapper : ICustomerMapper
    {       
        private readonly IIndividualMapper _individualMapper;
        private readonly IAddressMapper _addressMapper;
        private readonly IEmployementMapper _employementMapper;
        private readonly IOrganisationMapper _organisationMapper;
        private readonly IMarketingMapper _marketingMapper;
        private readonly IProposalMapper _proposalMapper;

        public CustomerMapper(IIndividualMapper individualMapper, 
            IAddressMapper addressMapper, IEmployementMapper employementMapper, IMarketingMapper marketingMapper, IOrganisationMapper organisationMapper, IProposalMapper proposalMapper)
        {
            _individualMapper = individualMapper;
            _addressMapper = addressMapper;
            _employementMapper = employementMapper;
            _marketingMapper = marketingMapper;
            _organisationMapper = organisationMapper;
            _proposalMapper = proposalMapper;
        }

        public SendApplicationRequest Map(ApplicationRequest applicationRequest, int? customerId, int? proposalId)
        {
            Applicant mainApplicant = applicationRequest.Data?.Applicants?.FirstOrDefault(x => x.IsMainApplicant ?? false);
            return new SendApplicationRequest()
            {
                Customer_type = CustomerTypeMapper.Map(Convert.ToInt32(mainApplicant?.CompanyType)),
                Individual = _individualMapper.Map(mainApplicant),
                Address = _addressMapper.Map(mainApplicant?.ResidenceHistory),
                Employment = _employementMapper.Map(mainApplicant?.EmploymentHistory.FirstOrDefault()),
                Marketing = _marketingMapper.Map(mainApplicant?.MarketingPreference),
                Organisation = _organisationMapper.Map(mainApplicant),
                Proposal = _proposalMapper.Map(applicationRequest)
            };
        }
    }
}