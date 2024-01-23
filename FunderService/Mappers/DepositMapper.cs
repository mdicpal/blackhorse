namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    internal class DepositMapper : IDepositMapper
    {
        private const double defaultamount = 0.00;
   
        public Deposit Map(ApplicationRequest applicationRequest)
        {
            return new Deposit()
            {
                Total_deposit = Sum(applicationRequest.Data.Quote.Deposit , applicationRequest.Data.Quote.PartExchange),
                Manufacturer_deposit = defaultamount,
                Dealer_deposit = defaultamount,
                Part_exchange_deposit = applicationRequest.Data.Quote.PartExchange,
                Bank_transfer_deposit = defaultamount,
                Card_deposit = defaultamount,
                Cheque_deposit = defaultamount,
                Cash_deposit = applicationRequest.Data.Quote.Deposit,
                Electric_vehcile_grant_deposit = defaultamount
            };
        }
        private static string Sum(double Deposit,double PartExchange)
        {
            return (Deposit + PartExchange).ToString();
        }
    }
}
