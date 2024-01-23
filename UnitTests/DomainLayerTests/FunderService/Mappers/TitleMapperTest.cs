namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderService.Mappers;
    using global::FunderService.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FunderTitle = FunderApi.Title;

    internal class TitleMapperTest
    {
        [Test]
        [TestCase(Title.Mr, ExpectedResult = FunderTitle.Mr)]
        [TestCase(Title.Miss, ExpectedResult = FunderTitle.Miss)]
        [TestCase(Title.Mrs, ExpectedResult = FunderTitle.Mrs)]
        [TestCase(Title.Rev, ExpectedResult = FunderTitle.Rev)]
        [TestCase(Title.Dr, ExpectedResult = FunderTitle.Dr)]
        [TestCase(Title.Ms, ExpectedResult = FunderTitle.Ms)]
        [TestCase("Mr", ExpectedResult = FunderTitle.Mr)]
        public FunderTitle EmploymentTitleTest(string title)
        {
            return TitleMapper.Map(title);
        }
    }
}
