namespace UnitTests.Helpers;

using AzureFunderCommonMessages.DotNet.Models;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;

public static class ApplicationFaker
{
    public static ApplicationRequest Build()
    {
        return new ApplicationRequest()
        {
            RequestType = RequestType.MakeApplication,
            QuoteId = 4334448,
            FunderCode = "SMF",
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
                            Forename = Faker.Name.First(),
                            Middlename = Faker.Name.Middle(),
                            Surname = Faker.Name.Last(),
                            Dob = DateTimeOffset.Now,
                            SexAtBirth = "m",
                            MaritalStatus = "Single",
                            IsUkResident = true,
                            Homephone = "07000000000",
                            Mobile = "07000000000",
                            Email = Faker.Internet.Email(),
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
                                            HouseNumber = Faker.RandomNumber.Next().ToString(),
                                            AddressLine1 = Faker.Address.StreetName(),
                                            AddressLine2 = Faker.Address.StreetAddress(),
                                            AddressLine3 = Faker.Address.StreetSuffix(),
                                            Town = Faker.Address.City(),
                                            County = Faker.Address.UkCountry(),
                                            Postcode = Faker.Address.ZipCode()
                                        },
                                        OrderNumber = 1,
                                        ResidentialStatusShortcode = "Owner",
                                        YearsAtAddress = 11,
                                        MonthsAtAddress = 1
                                    },
                                    new ResidenceHistory()
                                    {
                                        Address = new ()
                                        {
                                            Unit = "Eng",
                                            HouseName = "Amma center",
                                            HouseNumber = Faker.RandomNumber.Next().ToString(),
                                            AddressLine1 = Faker.Address.StreetName(),
                                            AddressLine2 = Faker.Address.StreetAddress(),
                                            AddressLine3 = Faker.Address.StreetSuffix(),
                                            Town = Faker.Address.City(),
                                            County = Faker.Address.UkCountry(),
                                            Postcode = Faker.Address.ZipCode()
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
                                            HouseName = "Brimington Medical Centre",
                                            HouseNumber = Faker.RandomNumber.Next().ToString(),
                                            AddressLine1 = Faker.Address.StreetName(),
                                            AddressLine2 = Faker.Address.StreetAddress(),
                                            AddressLine3 = Faker.Address.StreetSuffix(),
                                            Town = Faker.Address.City(),
                                            County = Faker.Address.UkCountry(),
                                            Postcode = Faker.Address.ZipCode()
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
                                        OccupationType = "Accountancy",
                                        JobTitle = "test",
                                        Company = Faker.Company.Name(),
                                        YearsAtCompany = 11,
                                        MonthsAtCompany = 1,
                                        PhoneNumber = Faker.Phone.Number().ToString(),
                                        EmploymentType =
                                            "EVOLVE DOES NOT STORE FULL TIME/PART TIME ETC",
                                        EmploymentStatus = "Employed",
                                        Address = new()
                                        {
                                            Unit = "Eng",
                                            HouseName = "Brimington Medical Centre",
                                            HouseNumber = Faker.RandomNumber.Next().ToString(),
                                            AddressLine1 = Faker.Address.StreetName(),
                                            AddressLine2 = Faker.Address.StreetAddress(),
                                            AddressLine3 = Faker.Address.StreetSuffix(),
                                            Town = Faker.Address.City(),
                                            County = Faker.Address.UkCountry(),
                                            Postcode = Faker.Address.ZipCode()
                                        }
                                    }
                                },
                            FinancialStatus = new() { AnnualGrossIncome = 50000, Affordability = "1" },
                            Bank = new()
                            {
                                AccountName = Faker.Name.FullName(),
                                BankName = "LLOYDS BANK PLC",
                                Address = { Town = Faker.Address.City(), Postcode = Faker.Address.ZipCode() },
                                AccountNumber = "31000000",
                                SortCode = "300000",
                                Years = "11",
                                Months = "1"
                            },
                            MarketingPreference = new()
                            {
                                OptInEmail = false,
                                OptInSms = false,
                                OptInPhone = false,
                                OptInPost = false
                            }
                        },
                        new Applicant()
                        {
                            IsMainApplicant = false,
                            ApplicantType = "Personal",
                            Title = "Mr",
                            Forename = Faker.Name.First(),
                            Middlename = Faker.Name.Middle(),
                            Surname = Faker.Name.Last(),
                            Dob = DateTimeOffset.Now,
                            SexAtBirth = "m",
                            MaritalStatus = "Single",
                            IsUkResident = true,
                            Homephone = Faker.Phone.Number(),
                            Mobile = Faker.Phone.Number(),
                            Email = Faker.Internet.Email(),
                            Nationality = "",
                            ResidenceHistory =
                                new()
                                {
                                    new ResidenceHistory()
                                    {
                                        Address = new()
                                        {
                                            Unit = "",
                                            HouseName = "Brimington Medical Centre",
                                            HouseNumber = Faker.RandomNumber.Next().ToString(),
                                            AddressLine1 = Faker.Address.StreetName(),
                                            AddressLine2 = Faker.Address.StreetAddress(),
                                            AddressLine3 = Faker.Address.StreetSuffix(),
                                            Town = Faker.Address.City(),
                                            County = Faker.Address.UkCountry(),
                                            Postcode = Faker.Address.ZipCode()
                                        },
                                        OrderNumber = 1,
                                        ResidentialStatusShortcode = "Cohabiting",
                                        YearsAtAddress = 0,
                                        MonthsAtAddress = 0
                                    }
                                },
                            EmploymentHistory = new()
                            {
                                new EmploymentHistory()
                                {
                                    OrderNumber = 1,
                                    OccupationType = "0",
                                    JobTitle = "1",
                                    Company = Faker.Company.Name(),
                                    YearsAtCompany = 1,
                                    MonthsAtCompany = 11,
                                    EmploymentType = "Employed"
                                }
                            },
                            FinancialStatus = new() { AnnualGrossIncome = 3750 }
                        }
                    },
                Dealer =
                    new Dealer()
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
                    PartExchange = Faker.RandomNumber.Next(),
                    Settlement = 0,
                    Deposit = 1000,
                    FlatRate = 5.63,
                    Term = 38,
                    VehicleCashPrice = 30012,
                    IsVehicleVatQualifying = true,
                    BalloonValue = 0,
                    FinanceType = "HP",
                    Apr = 10.99,
                    SettlementMonthlyAmount = Faker.RandomNumber.Next(),
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