namespace ApplicationLayer.Handlers.NotTakenUp.Interfaces
{
    using ApplicationLayer.Handlers.NotTakenUp.Models;
    using FunderApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INotTakenUpActivitySuccessResponseMapper
    {
        NotTakenUpActivityResponse Map(int quoteId,string customerId,string proposalId,NotTakenUpResponse funderResponse);
    }
}
