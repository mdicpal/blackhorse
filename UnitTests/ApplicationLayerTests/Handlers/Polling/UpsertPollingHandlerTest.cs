namespace UnitTests.ApplicationLayerTests.Handlers.Polling
{
    using ApplicationLayer.Handlers.Polling.Interfaces;
    using ApplicationLayer.Handlers.Polling;
    using ApplicationLayer.Interfaces;
    using Domain.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ApplicationLayer.Handlers.Polling.Models;
    using Microsoft.Extensions.Logging;

    internal class UpsertPollingHandlerTest
    {
        private Mock< ILogger<UpsertPollingHandler>> _logger;
        private Mock< IInstanceToPollRepository> _repository;
        private Mock< IInstanceToPollDtoMapper> _mapper;
        private IUpsertPollingHandler _upsertPollingHandler;
        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger<UpsertPollingHandler>>();
            _repository = new Mock<IInstanceToPollRepository>();
            _mapper = new Mock<IInstanceToPollDtoMapper>();
            _upsertPollingHandler = new UpsertPollingHandler(_logger.Object,_repository.Object,_mapper.Object);
        }
        [Test]
        public void SuccesTest()
        {
            UpsertRequest upsertRequest = new UpsertRequest();
            var result = _upsertPollingHandler.RunAsync(upsertRequest);
            Assert.That(result, Is.Not.Null);
        }
    }
}
