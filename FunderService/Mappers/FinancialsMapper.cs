namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class FinancialsMapper : IFinancialsMapper
    {       
        private readonly IDepositMapper _depositMapper;
        private const string financeTypeHP = "hp";
        private const string financeTypePCP = "pcp";
        private const string PlanHP = "CHD";
        private const string PlanPCP = "CHC";

        public FinancialsMapper(IDepositMapper  depositMapper)
        {
            _depositMapper= depositMapper;
        }
        public Financials Map(ApplicationRequest applicationRequest)
        {
            return new Financials()
            {
                Product = applicationRequest.Data.Quote.FinanceType,
                Plan = GetPlanData(applicationRequest.Data.Quote.FinanceType), // TO DO
                Deposit = _depositMapper.Map(applicationRequest),
                Cash_price = applicationRequest.Data.Quote.VehicleCashPrice,
                Deferred_payment = 0,//To Do
                Gfv = "0",//To Do
                Max_annual_mileage = Convert.ToInt32(applicationRequest.Data.Quote.AnnualMileage),
                Term = Convert.ToInt32(applicationRequest.Data.Quote.Term),
                Rate = applicationRequest.Data.Quote.Apr,
                Monthly_payment_amount = applicationRequest.Data.Quote.SettlementMonthlyAmount,
                Distance_marketed = true,
                Equalised_calculation = true,
                Part_exchange_shortfall = ((applicationRequest.Data.Quote.PartExchange - applicationRequest.Data.Quote.Settlement) + applicationRequest.Data.Quote.Deposit)
            };
        }

        private static string GetPlanData(string financeType)
        {
            if (financeType.ToLower() == financeTypeHP)
                return PlanHP;
            else if (financeType.ToLower() == financeTypePCP)
                return PlanPCP;
            else
                return null;
        }
    }
}
