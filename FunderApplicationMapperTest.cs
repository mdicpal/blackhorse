namespace UnitTests
{
    using Application.Mappers;
    using Application.Mappers.Interfaces;
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using AzureFunderCommonMessages.DotNet.Types;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;
    using OpenApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    internal class FunderApplicationMapperTest
    {
        private readonly ILogger<FunderApplicationMapper>? _logger;
        LoanApplicationRequest? loanApplicationRequest;
        IFunderApplicationMapper funderApplicationMapper;
        Applicant applicant;
        [SetUp]
        public void SetUp()
        {
            funderApplicationMapper = new FunderApplicationMapper(_logger);
            loanApplicationRequest = funderApplicationMapper.Map(_requestObject);
            loanApplicationRequest.ArrangerId = "3Y3434E";
            loanApplicationRequest.SupplierId = "3Y3434E";
            loanApplicationRequest.ExternalId = "3Y3434E";
            loanApplicationRequest.IntroducerId = "3Y3434E";
            //occupancyRecordval= occupationhistorymapper.MapOccupationRecord(_requestObject);
            Applicant applicant = _requestObject.Data.Applicants?.First(x => x.IsMainApplicant is true);
        }
        //[Test]
        //public void TestLoanRequestRequestIntroducerIdMapsCorrectly()
        //{
        //    Assert.That(loanApplicationRequest?.IntroducerId, Is.EqualTo("3Y3434E"));
        //}
        //[Test]
        //public void TestLoanRequestRequestArrangerIdMapsCorrectly()
        //{
        //    Assert.That(loanApplicationRequest?.ArrangerId, Is.EqualTo("3Y3434E"));
        //}
        ////[Test]
        ////public void TestLoanRequestRequestSupplierIdMapsCorrectly()
        ////{
        ////    Assert.That(loanApplicationRequest?.SupplierId, Is.EqualTo("3Y3434E"));
        ////}
        //[Test]
        //public void TestLoanRequestRequestExternalIdMapsCorrectly()
        //{
        //    Assert.That(loanApplicationRequest?.ExternalId, Is.EqualTo("3Y3434E"));
        //}
        [Test]
        public void TestLoanRequestRequestCustomerDetailsTitleMapsCorrectly()
        {
            Assert.That(loanApplicationRequest?.MainApplicant.Title, Is.EqualTo(applicant.Title));
        }

        private readonly ApplicationRequest _requestObject = new()
        {
            RequestType = RequestType.MakeApplication,

            QuoteId = 4334448,
            FunderCode = "Oodle",
            Version = 1,
            Data = new()
            {
                Applicants =
                   new List<Applicant>()
                   {
                        new Applicant()
                        {
                            IsMainApplicant = true,
                            ApplicantType = "Personal",
                            Title = "Mr",
                            Forename = "James",
                            Middlename = "daniel",
                            Surname = "bodewar",
                            Dob = DateTimeOffset.Now,
                            SexAtBirth = "m",
                            MaritalStatus = "Single",
                            IsUkResident = true,
                            Homephone = "040366576474",
                            Mobile = "86875875876",
                            Email = "abcd@gmail.com",
                            DrivingLicenceType = "UK Full",
                            Nationality = "Irish",
                            ResidenceHistory =
                                new List<ResidenceHistory>()
                                {
                                    new ResidenceHistory()
                                    {
                                        Address = new()
                                        {
                                            Unit = "Eng",
                                            HouseName = "Anna center",
                                            HouseNumber = "28-575",
                                            AddressLine1 = "mochigalli",
                                            AddressLine2 = " near busstop",
                                            AddressLine3 = "nearrailway",
                                            Town = "chennai",
                                            County = "uk",
                                            Postcode = "629343",
                                        },
                                        OrderNumber = 1,
                                        ResidentialStatusShortcode = "Owner",
                                        MonthsAtAddress = 11,
                                        YearsAtAddress = 1,
                                    },
                                    new ResidenceHistory()
                                    {
                                        Address = new ()
                                        {
                                             Unit = "Eng",
                                            HouseName = "Anna center",
                                            HouseNumber = "28-575",
                                            AddressLine1 = "mochigalli",
                                            AddressLine2 = " near busstop",
                                            AddressLine3 = "nearrailway",
                                            Town = "chennai",
                                            County = "uk",
                                            Postcode = "629343",
                                        },
                                        OrderNumber = 2,
                                        ResidentialStatusShortcode = "",
                                        YearsAtAddress = 1,
                                        MonthsAtAddress = 1
                                    },
                                    new ResidenceHistory()
                                    {
                                        Address = new ()
                                        {
                                            Unit = "Eng",
                                            HouseName = "Anna center",
                                            HouseNumber = "28-575",
                                            AddressLine1 = "mochigalli",
                                            AddressLine2 = " near busstop",
                                            AddressLine3 = "nearrailway",
                                            Town = "chennai",
                                            County = "uk",
                                            Postcode = "629343",
                                        },
                                        OrderNumber = 3,
                                        ResidentialStatusShortcode = "",
                                        YearsAtAddress = 1,
                                        MonthsAtAddress = 1
                                    }
                                },
                            EmploymentHistory =
                                new List<EmploymentHistory>()
                                {
                                    new EmploymentHistory()
                                    {

                                         OrderNumber = 1,
                                        OccupationType = "PERMANENT_FULL_TIME",
                                        JobTitle="test",
                                        Company="hdsfdsfsolutions",
                                        MonthsAtCompany=11,
                                        YearsAtCompany=1,
                                        EmploymentStatus="Employed",
                                        EmploymentType="PERMANENT_FULL_TIME",
                                        PhoneNumber="64234343587",
                                        Address = new ()
                                        {
                                             Unit = "Eng",
                                            HouseName = "Anna center",
                                            HouseNumber = "28-575",
                                            AddressLine1 = "mochigalli",
                                            AddressLine2 = " near busstop",
                                            AddressLine3 = "nearrailway",
                                            Town = "chennai",
                                            County = "uk",
                                            Postcode = "629343",
                                        },



                                    }
                                },
                            FinancialStatus = new() { AnnualGrossIncome = 50000, Affordability = "1", },
                            Bank = new Bank()
                            {
                                AccountName = "BSIS",
                                BankName = "LLOYDS BANK PLC",
                                Address = { Town = "chennai", Postcode = "629343" },
                                AccountNumber = "31000000",
                                SortCode = "300000",
                            },
                            MarketingPreference = new MarketingPreference()
                            {

                                OptInEmail = false,
                                OptInSms = false,
                                OptInPhone = false,
                                OptInPost = false
                            }
                        },
                         new Applicant()
                        {
                            IsMainApplicant = true,
                            ApplicantType = "Personal",
                            Title = "Mr",
                            Forename = "James",
                            Middlename = "daniel",
                            Surname = "bodewar",
                            Dob = DateTimeOffset.Now,
                            SexAtBirth = "m",
                            MaritalStatus = "Single",
                            IsUkResident = true,
                            Homephone = "040366576474",
                            Mobile = "86875875876",
                            Email = "abcd@gmail.com",
                            DrivingLicenceType = "UK Full",
                            Nationality = "Irish",
                            ResidenceHistory =
                                new List<ResidenceHistory>()
                                {
                                    new ResidenceHistory()
                                    {
                                        Address = new()
                                        {
                                            Unit = "Eng",
                                            HouseName = "Anna center",
                                            HouseNumber = "28-575",
                                            AddressLine1 = "mochigalli",
                                            AddressLine2 = " near busstop",
                                            AddressLine3 = "nearrailway",
                                            Town = "chennai",
                                            County = "uk",
                                            Postcode = "629343",
                                        },
                                        OrderNumber = 1,
                                        ResidentialStatusShortcode = "Owner",
                                        MonthsAtAddress = 11,
                                        YearsAtAddress = 1,
                                    },
                                    new ResidenceHistory()
                                    {
                                        Address = new ()
                                        {
                                             Unit = "Eng",
                                            HouseName = "Anna center",
                                            HouseNumber = "28-575",
                                            AddressLine1 = "mochigalli",
                                            AddressLine2 = " near busstop",
                                            AddressLine3 = "nearrailway",
                                            Town = "chennai",
                                            County = "uk",
                                            Postcode = "629343",
                                        },
                                        OrderNumber = 2,
                                        ResidentialStatusShortcode = "",
                                        YearsAtAddress = 1,
                                        MonthsAtAddress = 1
                                    },
                                    new ResidenceHistory()
                                    {
                                        Address = new ()
                                        {
                                            Unit = "Eng",
                                            HouseName = "Anna center",
                                            HouseNumber = "28-575",
                                            AddressLine1 = "mochigalli",
                                            AddressLine2 = " near busstop",
                                            AddressLine3 = "nearrailway",
                                            Town = "chennai",
                                            County = "uk",
                                            Postcode = "629343",
                                        },
                                        OrderNumber = 3,
                                        ResidentialStatusShortcode = "",
                                        YearsAtAddress = 1,
                                        MonthsAtAddress = 1
                                    }
                                },
                            EmploymentHistory =
                                new List<EmploymentHistory>()
                                {
                                    new EmploymentHistory()
                                    {

                                         OrderNumber = 1,
                                        OccupationType = "PERMANENT_FULL_TIME",
                                        JobTitle="test",
                                        Company="hdsfdsfsolutions",
                                        MonthsAtCompany=11,
                                        YearsAtCompany=1,
                                        EmploymentStatus="Employed",
                                        EmploymentType="PERMANENT_FULL_TIME",
                                        PhoneNumber="64234343587",
                                        Address = new ()
                                        {
                                             Unit = "Eng",
                                            HouseName = "Anna center",
                                            HouseNumber = "28-575",
                                            AddressLine1 = "mochigalli",
                                            AddressLine2 = " near busstop",
                                            AddressLine3 = "nearrailway",
                                            Town = "chennai",
                                            County = "uk",
                                            Postcode = "629343",
                                        },



                                    }
                                },
                            FinancialStatus = new() { AnnualGrossIncome = 50000, Affordability = "1", },
                            Bank = new Bank()
                            {
                                AccountName = "BSIS",
                                BankName = "LLOYDS BANK PLC",
                                Address = { Town = "chennai", Postcode = "629343" },
                                AccountNumber = "31000000",
                                SortCode = "300000",
                            },
                            MarketingPreference = new MarketingPreference()
                            {

                                OptInEmail = false,
                                OptInSms = false,
                                OptInPhone = false,
                                OptInPost = false
                            }
                        },
                   },
                Dealer = new Dealer()
                {

                    DealerId = "6859",
                    DealerCode = "6859",
                    IsMccWeblead = false,
                    CommissionType = "Comparision Logic",
                    DealerPackageCode = ""
                },
                Quote = new()
                {
                    IsBusinessQuote = false,
                    QuoteDate = DateTimeOffset.Now,
                    AnnualMileage = 10000,
                    PartExchange = 5435435,
                    Settlement = 0,
                    Deposit = 1000,
                    FlatRate = 5.63,
                    Term = 38,
                    VehicleCashPrice = 30012,
                    IsVehicleVatQualifying = true,
                    BalloonValue = 0,
                    FinanceType = "HP",
                    Apr = 10.99,
                    SettlementMonthlyAmount = 730937857,
                    EquifaxDefaults = 10,
                    ExperianDefaults = 12,
                    EquifaxCountyCourtJudgments = 2,
                    ExperianCountyCourtJudgments = 3,
                },
                Asset = new()
                {
                    Make = "MERCEDES - BENZ",
                    Model = "CLS DIESEL COUPE",
                    Style = "CLS 350d 4Matic AMG Line Premium +4dr 9G - Tronic",
                    AssetType = "1",
                    IsNew = false,
                    Vrm = "KW68TVD",
                    Vin = "WDD2573212A026020",
                    CapCode = "MECS29PLL4SDTA4 4",
                    CurrentMileage = 10000,
                    RegistrationDate = DateTimeOffset.Now
                },
                DispersalOptions = new()
                {
                    new DispersalOption()
                    {
                    Name = "Warranty product",
                    Amount = 100
                    },
                    new DispersalOption()
                    {
                        Name = "RoadFundLicense product",
                        Amount= 200
                    }
                }
            }
        };
    }
}
