namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using global::FunderService.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderResidentialStatus = FunderApi.ResidentialStatus;

    internal class ResidentialStatusMapperTest
    {
        [Test]
        [TestCase(ResidentialStatus.Owner, ExpectedResult = FunderResidentialStatus.Home_Owner)]
        [TestCase(ResidentialStatus.WithParents, ExpectedResult = FunderResidentialStatus.Living_with_parents)]
        [TestCase(ResidentialStatus.TenantUnfurnished, ExpectedResult = FunderResidentialStatus.Tenant)]
        [TestCase(ResidentialStatus.TenantFurnished, ExpectedResult = FunderResidentialStatus.Tenant)]
        [TestCase("Others", ExpectedResult = FunderResidentialStatus.Other)]

        public FunderResidentialStatus EmploymentResidentialStatusTest(string ResidentialStatus)
        {
            return ResidentialStatusMapper.Map(ResidentialStatus);
        }
    }
}
