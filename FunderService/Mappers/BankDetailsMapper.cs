namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class BankDetailsMapper:IBankDetailsMapper
    {
        public BankDetails Map(Applicant applicant)
        {
            return new BankDetails()
            {
                Account_name = applicant.Bank.AccountName,
                Account_number = Convert.ToInt32(applicant.Bank.AccountNumber),
                Sort_code = Convert.ToInt32(applicant.Bank.SortCode),
                Months_with_bank = Convert.ToInt32(applicant.Bank.Months),
                Years_with_bank = Convert.ToInt32(applicant.Bank.Years)
            };
        }
    }
}
