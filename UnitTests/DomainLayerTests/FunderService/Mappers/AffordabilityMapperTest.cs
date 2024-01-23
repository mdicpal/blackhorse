namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;
    using FunderService.Mappers;
    using global::FunderService.Mappers;
    using Microsoft.AspNetCore.Mvc.ApplicationParts;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class AffordabilityMapperTest
    {
        private AffordabilityMapper _mapper = null!;
        private Applicant _mainApplicant = null!;
        [SetUp]
        public void SetUp()
        {
            
            _mapper = new AffordabilityMapper();
            _mainApplicant = new Applicant();
        }
        [Test]
        public void AffordabilityTest()
        {
            _mainApplicant = new Applicant()
            {
                FinancialStatus=new FinancialStatus()
                {
                    AnnualGrossIncome=10,
                    AffordabilityMonthlyMortgageRentContribution=12,
                    AffordabilityMonthlyOtherExpenditure=20,
                    Affordability="2",
                }
            };
            Affordability affordability = _mapper.Map(_mainApplicant);
            Assert.That(affordability,Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(affordability.Gross_annual_income, Is.EqualTo(_mainApplicant.FinancialStatus.AnnualGrossIncome));
                Assert.That(affordability.Mortgage_or_rent_contribution, Is.EqualTo(_mainApplicant.FinancialStatus.AffordabilityMonthlyMortgageRentContribution));
                Assert.That(affordability.Other_expenditure, Is.EqualTo(_mainApplicant.FinancialStatus.AffordabilityMonthlyOtherExpenditure));
                Assert.That(affordability.Circumstantial_change, Is.EqualTo(_mainApplicant.FinancialStatus.Affordability.Equals("2") ? 6 : 0));
            });
        }
    }
}
