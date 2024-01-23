namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using global::FunderService.Mappers;
    using FunderAddressType = FunderApi.AddressType;
    internal class AddressTypeMapperTest
    {
        [Test]
        [TestCase(0, ExpectedResult = FunderAddressType.Current_Address)]
        [TestCase(1, ExpectedResult = FunderAddressType.Previous_Address)]
        [TestCase(2, ExpectedResult = FunderAddressType.Address_prior_to_Previous_Address_1)]
        [TestCase(3, ExpectedResult = FunderAddressType.Address_prior_to_Previous_Address_2)]
        [TestCase(4,ExpectedResult =FunderAddressType.Address_prior_to_Previous_Address_3)]
        [TestCase(5, ExpectedResult = FunderAddressType.Address_prior_to_Previous_Address_4)]
        [TestCase(1234,ExpectedResult = FunderAddressType.Undeclared_Address)]
        public FunderAddressType EmploymentTypeTest(long AddressType)
        {
            return AddressTypeMapper.Map(AddressType);
        }
    }
}
