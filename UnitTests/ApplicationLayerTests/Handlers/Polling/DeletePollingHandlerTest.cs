namespace UnitTests.ApplicationLayerTests.Handlers.Polling
{
    using ApplicationLayer.Handlers.Polling;
    using ApplicationLayer.Interfaces;
    using Microsoft.Extensions.Logging;


    internal class DeletePollingHandlerTest
    {
        private  Mock<IInstanceToPollRepository> _repository;
       private  Mock<ILogger<DeletePollingHandler>> _logger;
        private DeletePollingHandler _handler;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IInstanceToPollRepository>();
            _logger = new Mock<ILogger<DeletePollingHandler>>();
            _handler = new DeletePollingHandler(_logger.Object, _repository.Object);
        }
        [Test]
        public void Sucesspolling()
        {
            string applicationId = "123";
           var result=   _handler.RunAsync(applicationId);
            Assert.That(result, Is.Not.Null);
        }
    }
}
