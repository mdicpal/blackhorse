namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using global::FunderService.Mappers;
    using FunderMaritalStatus = FunderApi.MaritalStatus;

    internal class MaritalStatusMapperTest
    {
        [Test]
        [TestCase(MaritalStatus.Single, ExpectedResult = FunderMaritalStatus.Single)]
        [TestCase(MaritalStatus.Married, ExpectedResult = FunderMaritalStatus.Married)]
        [TestCase(MaritalStatus.Widowed, ExpectedResult = FunderMaritalStatus.Widowed)]
        [TestCase(MaritalStatus.LivingWithPartner, ExpectedResult = FunderMaritalStatus.CoHabiting)]
        [TestCase(MaritalStatus.Seperated, ExpectedResult = FunderMaritalStatus.Separated)]
        [TestCase(MaritalStatus.Divorced, ExpectedResult = FunderMaritalStatus.Divorced)]
        public FunderMaritalStatus EmploymentMaritalStatusTest(string Maritalsatus)
        {
            return MaritalStatusMapper.Map(Maritalsatus);
        }
    }
}
