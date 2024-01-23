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

public class FinancialsMapperTest
{
    private Mock<IDepositMapper> _depositMapperMock = null!;
   
    private ApplicationRequest applicationRequesthp;
    private ApplicationRequest applicationRequestpcp;
    private ApplicationRequest applicationRequestno;
    private FinancialsMapper _financialsMapper = null!;

    [SetUp]
    public void SetUp()
    {
        applicationRequesthp = new ApplicationRequest() { Data = new ApplicationRequestData() {  Quote = new Quote { FinanceType = "hp",VehicleCashPrice = 12.56, AnnualMileage = 10000,Term =120,Apr=200.12,SettlementMonthlyAmount = 333.12,PartExchange = 200.23,Settlement = 50.12,Deposit = 1002.20 }  }, QuoteId = 101 };
        applicationRequestpcp = new ApplicationRequest() { Data = new ApplicationRequestData() {  Quote = new Quote { FinanceType = "pcp",VehicleCashPrice = 12.56, AnnualMileage = 10000,Term =120,Apr=200.12,SettlementMonthlyAmount = 333.12,PartExchange = 200.23,Settlement = 50.12,Deposit = 1002.20 }  }, QuoteId = 101 };
        applicationRequestno = new ApplicationRequest() { Data = new ApplicationRequestData() {  Quote = new Quote { FinanceType = "cc",VehicleCashPrice = 12.56, AnnualMileage = 10000,Term =120,Apr=200.12,SettlementMonthlyAmount = 333.12,PartExchange = 200.23,Settlement = 50.12,Deposit = 1002.20 }  }, QuoteId = 101 };
        _depositMapperMock = new();
        _financialsMapper = new(_depositMapperMock.Object);
    }

    [Test]
    public void CustomerMapperSuccessTest()
    {
        var successResponsewithhp = _financialsMapper.Map(applicationRequesthp);
        var successResponsewithpcp = _financialsMapper.Map(applicationRequestpcp);
        var successResponseno = _financialsMapper.Map(applicationRequestno);       

        Assert.Multiple(() =>
        {
            Assert.That(successResponsewithhp, Is.Not.Null);
            Assert.That(successResponsewithpcp, Is.Not.Null);
            Assert.That(successResponseno, Is.Not.Null);
        });
    }

    }