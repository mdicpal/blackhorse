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
    internal class AffordabilityMapper:IAffordabilityMapper
    {
        public Affordability Map(Applicant applicant)
        {
            return new Affordability()
            {
                //  Replace_existing_agreement= applicant.,TO DO
                Gross_annual_income = Convert.ToInt32(applicant.FinancialStatus.AnnualGrossIncome),
                Mortgage_or_rent_contribution = Convert.ToInt32(applicant.FinancialStatus.AffordabilityMonthlyMortgageRentContribution),
                Other_expenditure = Convert.ToInt32(applicant.FinancialStatus.AffordabilityMonthlyOtherExpenditure),
                Circumstantial_change = applicant.FinancialStatus.Affordability.Equals("2") ? 6 : 0
            };
        }

      
    }
}
