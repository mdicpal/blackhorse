namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FunderApi;

    public static class FunderStatusMapper
    {
        public static StatusResponseType Map(DecisionStatus funderStatus) =>
            funderStatus switch
            {
                DecisionStatus.ACCEPTED => StatusResponseType.Accepted,
                DecisionStatus.REFERRED => StatusResponseType.Referred,
                DecisionStatus.DECLINED => StatusResponseType.Declined,
                DecisionStatus.CHECKING => StatusResponseType.ConditionalAccept,
                DecisionStatus.DEFERRED => StatusResponseType.MoreInfo,
                DecisionStatus.CONDITIONALACCEPT => StatusResponseType.ConditionalAccept,
                _ => StatusResponseType.Referred
            };
    }
}
