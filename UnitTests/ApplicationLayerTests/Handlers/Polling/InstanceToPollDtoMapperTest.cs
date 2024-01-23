namespace UnitTests.ApplicationLayerTests.Handlers.Polling
{
    using ApplicationLayer.Handlers.Polling;
    using ApplicationLayer.Handlers.Polling.Interfaces;
    using ApplicationLayer.Handlers.Polling.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class InstanceToPollDtoMapperTest
    {
        private IInstanceToPollDtoMapper _instanceToPollDtoMapper;
        [SetUp]
        public void Setup()
        {
            _instanceToPollDtoMapper = new InstanceToPollDtoMapper();
        }
        [Test] 
        public void TestData()
        {
            UpsertRequest upsertRequest = new UpsertRequest();
            var result = _instanceToPollDtoMapper.Map(upsertRequest);
            Assert.That(result, Is.Not.Null);
        }
    }
}
