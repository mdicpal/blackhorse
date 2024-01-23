namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Request;
    using global::FunderService.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request.DataTypes;
    using global::Domain;
    using Helpers;
    using global::FunderService.Mappers.Interfaces;
    using Castle.Core.Logging;
    using Microsoft.Extensions.Logging;
    using AzureFunderCommonMessages.DotNet.Types;
    using FunderApi;
    internal class ProposalDetailsMappersTest
    {
        private Mock<IBankDetailsMapper> _bankDetailsMapperMock= null!;
        private Mock<IFinancialsMapper> _financialsMapperMock = null!;
        private Mock<IAffordabilityMapper> _affordabilityMapperMock = null!;
        private Mock<IAssetMapper> _assetMapperMock = null!;
        private Mock<IAddonsMapper> _addonsMapperMock = null!;
        private ApplicationRequest applicationRequest;
        private ProposalMapper _proposalMapper = null!;
        [SetUp]
        public void SetUp()
        {
            applicationRequest = new () { Data = new ApplicationRequestData() { Applicants = new List<Applicant>() { new Applicant { Title = "Mr", Forename = "sam", Middlename = "hhh", IsMainApplicant = true, CompanyType = CompanyType.Limted, ResidenceHistory = new List<ResidenceHistory> { new ResidenceHistory { OrderNumber = 10 } } } } }, QuoteId = 101 };
            _bankDetailsMapperMock = new();
            _financialsMapperMock = new();
            _addonsMapperMock = new();
            _assetMapperMock = new();
            _affordabilityMapperMock = new();
            _proposalMapper = new(_bankDetailsMapperMock.Object
                , _financialsMapperMock.Object, _affordabilityMapperMock.Object
                , _assetMapperMock.Object, _addonsMapperMock.Object);
        }
        [Test]
        public void ProposalMapperSuccessTest()
        {
           var successResponse =  _proposalMapper.Map(applicationRequest);
           Assert.That(successResponse,Is.Not.Null);
        }
    }
}
