namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types;
    using FunderApi;
    using global::FunderService.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class FunderStatusMapperTest
    {
        [Test]
        [TestCase(DecisionStatus.ACCEPTED, ExpectedResult = StatusResponseType.Accepted)]
        [TestCase(DecisionStatus.DECLINED, ExpectedResult = StatusResponseType.Declined)]
        [TestCase(DecisionStatus.REFERRED, ExpectedResult = StatusResponseType.Referred)]
        [TestCase(DecisionStatus.DEFERRED, ExpectedResult = StatusResponseType.MoreInfo)]
        [TestCase(DecisionStatus.CONDITIONALACCEPT, ExpectedResult = StatusResponseType.ConditionalAccept)]
        [TestCase(DecisionStatus.CHECKING, ExpectedResult = StatusResponseType.ConditionalAccept)]
        [TestCase(1, ExpectedResult = StatusResponseType.Referred)]
        public StatusResponseType StatusTest(DecisionStatus decision)
        {
            return FunderStatusMapper.Map(decision);
        }
    }
}
