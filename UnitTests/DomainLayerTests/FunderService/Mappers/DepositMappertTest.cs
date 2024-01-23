namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;
    using global::FunderService.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DepositMappertTest
    {
        private DepositMapper _mapper = null!;
        private ApplicationRequest _applicationRequest;
        [SetUp]
        public void SetUp()
        {
            _applicationRequest = new ApplicationRequest();
            _mapper = new DepositMapper();
        }
        [Test]
        public void Testdeposit()
        {
          const double defaultamount = 0.00;
        _applicationRequest = new ApplicationRequest()
            {
                Data = new()
                {
                    Quote = new()
                    {
                        Deposit=456,
                        PartExchange=45,
                    }
                }
            };
            Deposit deposit = _mapper.Map(_applicationRequest);
            Assert.That(deposit, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(Convert.ToInt32(deposit.Total_deposit), Is.EqualTo(_applicationRequest.Data.Quote.Deposit + _applicationRequest.Data.Quote.PartExchange));
                Assert.That(deposit.Manufacturer_deposit, Is.EqualTo(defaultamount));
                Assert.That(deposit.Dealer_deposit, Is.EqualTo(defaultamount));
                Assert.That(Convert.ToInt32(deposit.Part_exchange_deposit), Is.EqualTo(_applicationRequest.Data.Quote.PartExchange));
                Assert.That(deposit.Bank_transfer_deposit, Is.EqualTo(defaultamount));
                Assert.That(deposit.Cheque_deposit, Is.EqualTo(defaultamount));
                Assert.That(deposit.Card_deposit, Is.EqualTo(defaultamount));
                Assert.That(Convert.ToInt32(deposit.Cash_deposit), Is.EqualTo(_applicationRequest.Data.Quote.Deposit));
                Assert.That(deposit.Electric_vehcile_grant_deposit, Is.EqualTo(defaultamount));
            });
        }
    }
}
