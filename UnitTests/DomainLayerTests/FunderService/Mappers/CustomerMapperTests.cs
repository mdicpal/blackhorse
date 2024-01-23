namespace UnitTests.DomainLayerTests.FunderService.Mappers;

using ApplicationLayer.Extensions.ApiExceptions;
using ApplicationLayer.Handlers.MakeApplication;
using ApplicationLayer.Handlers.MakeApplication.Interfaces;
using ApplicationLayer.Handlers.MakeApplication.Models;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Models;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using AzureFunderCommonMessages.DotNet.Types;
using Domain.Logger;
using FluentValidation;
using FluentValidation.Results;
using FunderApi;
using FunderService.Mappers;
using global::FunderService.Interfaces;
using global::FunderService.Mappers;
using global::FunderService.Mappers.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Orchestrator.Exceptions;
using Orchestrator.Triggers;

public class CustomerMapperTests
{
    private Mock<IIndividualMapper> _individualMapperMock = null!;
    private Mock<IAddressMapper> _addressMapperMock = null!;
    private Mock<IEmployementMapper> _employementMapperMock = null!;
    private Mock<IOrganisationMapper> _organisationMapperMock = null!;
    private Mock<IMarketingMapper> _marketingMapperMock = null!;
    private Mock<IProposalMapper> _proposalMapperMock = null!;
    private ApplicationRequest applicationRequest;
    private CustomerMapper _customerMapper = null!;

    [SetUp]
    public void SetUp()
    {
        applicationRequest = new ApplicationRequest() { Data = new ApplicationRequestData() { Applicants = new List<Applicant>() { new Applicant { Title = "Mr", Forename = "sam", Middlename = "hhh", IsMainApplicant = true, CompanyType = CompanyType.Limted, ResidenceHistory = new List<ResidenceHistory> { new ResidenceHistory { OrderNumber =10 } } } } }, QuoteId = 101 };
        _individualMapperMock = new Mock<IIndividualMapper>();
        _addressMapperMock = new Mock<IAddressMapper>();
        _employementMapperMock = new Mock<IEmployementMapper>();
        _organisationMapperMock = new Mock<IOrganisationMapper>();
        _marketingMapperMock = new Mock<IMarketingMapper>();
        _proposalMapperMock = new Mock<IProposalMapper>();
        _customerMapper = new CustomerMapper(_individualMapperMock.Object
            , _addressMapperMock.Object, _employementMapperMock.Object
            , _marketingMapperMock.Object, _organisationMapperMock.Object, _proposalMapperMock.Object);
    }

    [Test]
    public void CustomerMapperSuccessTest()
    {    
        Individual individual = new () {  First_name = "aaaa"};  
        List<ResidenceHistory> residenceHistories = new() { new ResidenceHistory() { OrderNumber =10 } };
        ICollection<ResidenceHistory> residenceHistories1 = (ICollection<ResidenceHistory>)residenceHistories;
      
        _individualMapperMock
            .Setup(x => x.Map(It.IsAny<Applicant>()))
            .Returns(individual);
        _addressMapperMock.Setup(x => x.Map(residenceHistories1));
        _employementMapperMock.Setup(x => x.Map(It.IsAny<EmploymentHistory>())).Returns(new Employment());
        _marketingMapperMock.Setup(x => x.Map(It.IsAny<MarketingPreference>())).Returns(new Marketing());
        _organisationMapperMock
             .Setup(x => x.Map(It.IsAny<Applicant>()))
             .Returns(new Organisation());
        _proposalMapperMock
            .Setup(x => x.Map(applicationRequest))
            .Returns(new Proposal());
        SendApplicationRequest funderRequestactual = _customerMapper.Map(applicationRequest, 101, 201);
  
        Assert.That(funderRequestactual, Is.Not.Null);
    }

    [Test]
    public void CustomerTypeMapperSuccessTest()
    {
        string customerTypeExpected1 = "Limited_Company";
        string customerTypeActual1 = CustomerTypeMapper.Map(1).ToString();
        string customerTypeExpected2 = "Partnership";
        string customerTypeActual2 = CustomerTypeMapper.Map(2).ToString();
        string customerTypeExpected3 = "Sole_Trader";
        string customerTypeActual3 = CustomerTypeMapper.Map(3).ToString();
        string customerTypeExpected0 = "Consumer";
        string customerTypeActual0 = CustomerTypeMapper.Map(0).ToString();
        Assert.Multiple(() =>
        {
            Assert.That(customerTypeExpected1, Is.EqualTo(customerTypeActual1));
            Assert.That(customerTypeExpected2, Is.EqualTo(customerTypeActual2));
            Assert.That(customerTypeExpected3, Is.EqualTo(customerTypeActual3));
            Assert.That(customerTypeExpected0, Is.EqualTo(customerTypeActual0));
        });
    }

    [Test]
    public void OrganisationMapperSuccessTest()
    {
        Applicant applicant = new Applicant {Title = "TT", CompanyType = CompanyType.Limted, Company = new Company { Name = "AAA", CompanyNumber = "111222", Phone = "+441212121", VatNumber = "QQ1212", IsVatRegistered = true, Nature = "nn", Sortcode = "FF0001" }, Forename = "RR", Surname = "EE", Homephone = "+44232323", Email = "aa@qq.com", Middlename = "mm",Dob = new DateTimeOffset(new DateTime(2012, 02, 29, 12, 43, 0, DateTimeKind.Utc)), Mobile ="+4422222",MaritalStatus = "MMQQ", Nationality = "india", ResidenceHistory = new List<ResidenceHistory> { new ResidenceHistory { ResidentialStatusShortcode ="rhsc" } } };
        OrganisationMapper organisationMapper = new OrganisationMapper();
        var organisationmap =  organisationMapper.Map(applicant);
        MarketingPreference marketingPreference = new MarketingPreference() { OptInEmail = true, OptInPhone = true, OptInPost = true, OptInSms = true };
        MarketingMapper marketingMapper = new MarketingMapper();
        var marketing = marketingMapper.Map(marketingPreference);
        EmploymentHistory employmentHistory = new EmploymentHistory { EmploymentType = "full time",OccupationType = "occ",Company = "FF", OrderNumber = 100,YearsAtCompany =12,MonthsAtCompany =120,Address = new AzureFunderCommonMessages.DotNet.Models.Address { County="ccc", HouseName = "hh", HouseNumber = "222", AddressLine1 = "che", AddressLine2 = "mum",Town ="tt", Postcode ="pp",Unit = "uu" } };
        EmployementMapper employementMapper = new EmployementMapper();
        var employment = employementMapper.Map(employmentHistory);
        IndividualMapper individualMapper = new IndividualMapper();
        var individual = individualMapper.Map(applicant);
        Assert.Multiple(() =>
        {
            Assert.That(organisationmap, Is.Not.Null);
            Assert.That(marketing, Is.Not.Null);
            Assert.That(employment, Is.Not.Null);
            Assert.That(individual, Is.Not.Null);
        });
    }
}