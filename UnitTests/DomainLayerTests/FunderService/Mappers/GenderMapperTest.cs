namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using global::FunderService.Mappers;
    using FunderGender = FunderApi.Gender;
    internal class GenderMapperTest
    {
        [Test]
        [TestCase(Gender.Male, ExpectedResult = FunderGender.Male)]
        [TestCase(Gender.Female, ExpectedResult = FunderGender.Female)]
        [TestCase("others", ExpectedResult = FunderGender.Unspecified)]
        public FunderGender EmploymentGenderTest(string Gender)
        {
            return GenderMapper.Map(Gender);
        }
    }
}