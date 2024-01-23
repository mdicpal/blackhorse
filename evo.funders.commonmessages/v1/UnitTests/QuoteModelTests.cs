using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Models;
using Newtonsoft.Json;
using AzureFunderCommonMessages.DotNet.Helpers;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;
using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using AzureFunderCommonMessages.DotNet;
using AzureFunderCommonMessages.DotNet.Response;

namespace UnitTests
{
    public class QuoteModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAdvanceTest()
        {
            Quote quote = new() {
                Deposit = 200,
                VehicleCashPrice = 1000,
                PartExchange = 100,
                Settlement = 100
            };

            double advance = quote.GetAdvance();
            Assert.That(advance, Is.EqualTo(800));
        }
    }
}