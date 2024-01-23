namespace UnitTests.DomainLayerTests.FunderService.Mappers.TestData
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;
    using global::FunderService.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class AddonsMapperTest
    {
        private AddonsMapper _mapper = null!;
        [SetUp]
        public void SetUp()
        {
            _mapper = new AddonsMapper();
        }
        [Test]
        public void Testaddons()
        {
            Addons addons = _mapper.Map();
            Assert.That(addons, Is.Not.Null);
        }
    }
}
