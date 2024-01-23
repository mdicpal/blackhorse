namespace UnitTests.ApplicationLayerTests.Handlers.Polling
{
    using ApplicationLayer.Handlers.Polling;
    using ApplicationLayer.Models;
    using FunderService.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PollingHandlerTest
    {
        private Mock< IFunderClient> _funderClient;
        private PollingHandler _pollingHandler;
        [SetUp]
        public void SetUp()
        {
            _funderClient = new Mock<IFunderClient>();
            _pollingHandler = new PollingHandler(_funderClient.Object);
        }
        [Test]
        public void ReturnfunderUpdate()
        {
            InstanceToPollDto instanceToPollDto = new InstanceToPollDto()
            {
                Id= 1,
                CreatedAt= DateTime.UtcNow,
                CustomerId= 1,
                ProposalId= 1,
                ApplicationId="1",
                QuoteId=1,
                InstanceId="1",
                DeterministicHash="1"
            };
            var Funderupdate = _pollingHandler.RunAsync(instanceToPollDto);
            Assert.That(Funderupdate, Is.Not.Null);
        }
    }
}
