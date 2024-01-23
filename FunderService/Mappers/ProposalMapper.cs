namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Asset = FunderApi.Asset;

    internal class ProposalMapper : IProposalMapper
    {       
        private readonly IBankDetailsMapper _bankdetailsmapper;
        private readonly IFinancialsMapper _financialsMapper;
        private readonly IAffordabilityMapper _affordabilityMapper;
        private readonly IAssetMapper _assetMapper;
        private readonly IAddonsMapper _addonsMapper;
        public ProposalMapper(IBankDetailsMapper bankDetailsMapper,
            IFinancialsMapper financialsMapper, IAffordabilityMapper affordabilityMapper,IAssetMapper assetMapper,IAddonsMapper addonsMapper)
        {
            _bankdetailsmapper = bankDetailsMapper;
            _financialsMapper = financialsMapper;
            _affordabilityMapper = affordabilityMapper;
            _assetMapper = assetMapper;
            _addonsMapper = addonsMapper;
        }
        public Proposal Map(ApplicationRequest applicationRequest)
        {
            Applicant mainApplicant = applicationRequest.Data.Applicants.FirstOrDefault();
            return new Proposal()
            {
               Callback_url = String.Empty,
               Customer_permission_given = true,
               Financials = _financialsMapper.Map(applicationRequest),
               Bank_details = _bankdetailsmapper.Map(mainApplicant),
               Asset = _assetMapper.Map(applicationRequest),
               Addons = _addonsMapper.Map(),
               Affordability = _affordabilityMapper.Map(mainApplicant)
            };
        }
    }
}
