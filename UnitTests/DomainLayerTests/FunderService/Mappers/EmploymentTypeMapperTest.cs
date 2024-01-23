namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using global::FunderService.Mappers;
    using FunderEmploymentType = FunderApi.EmploymentType;

    internal class EmploymentTypeMapperTest
    {
        [Test]
        [TestCase(EmploymentStatus.Employed, ExpectedResult = FunderEmploymentType.Government)]
        [TestCase(EmploymentStatus.Retired, ExpectedResult = FunderEmploymentType.Retired)]
        [TestCase(EmploymentStatus.SelfEmployed, ExpectedResult = FunderEmploymentType.Self_Employed)]
        [TestCase(EmploymentStatus.NonWorking, ExpectedResult = FunderEmploymentType.Unemployed)]
        [TestCase("Student", ExpectedResult = FunderEmploymentType.Student)]
        public FunderEmploymentType EmploymentTypeTest(string EmploymentType)
        {
            return EmploymentTypeMapper.Map(EmploymentType);
        }
    }
}
