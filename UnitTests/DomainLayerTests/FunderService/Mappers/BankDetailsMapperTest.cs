namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;
    using global::FunderService.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class BankDetailsMapperTest
    {
        private BankDetailsMapper _mapper = null!;
        private Applicant _mainApplicant = null!;
        [SetUp]
        public void SetUp()
        {

            _mapper = new BankDetailsMapper();
            _mainApplicant = new Applicant();
        }
        [Test]
        public void BankDetailsTest()
        {
            _mainApplicant = new Applicant()
            {
                Bank=new Bank()
                {
                    AccountName="abcdfds",
                    AccountNumber="125754688",
                    SortCode="5687368",
                    Months="2",
                    Years="5"
                }
            };
            BankDetails bankDetails = _mapper.Map(_mainApplicant);
            Assert.That(bankDetails, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(bankDetails.Account_name, Is.EqualTo(_mainApplicant.Bank.AccountName));
                Assert.That(bankDetails.Account_number, Is.EqualTo(Convert.ToInt32(_mainApplicant.Bank.AccountNumber)));
                Assert.That(bankDetails.Sort_code, Is.EqualTo(Convert.ToInt32(_mainApplicant.Bank.SortCode)));
                Assert.That(bankDetails.Months_with_bank, Is.EqualTo(Convert.ToInt32(_mainApplicant.Bank.Months)));
                Assert.That(bankDetails.Years_with_bank, Is.EqualTo(Convert.ToInt32(_mainApplicant.Bank.Years)));
            });
        }
    }
}
