namespace ApplicationLayer.Handlers.Polling;

using ApplicationLayer.Models;
using Extensions;
using Interfaces;
using Models;

public class InstanceToPollDtoMapper : IInstanceToPollDtoMapper
{
    public InstanceToPollDto Map(UpsertRequest request)
    {
        string deterministicHash = request.FunderResponse is not null ? request.FunderResponse.ToDeterministicHash() : string.Empty;
        return new InstanceToPollDto()
        {
            QuoteId = request.QuoteId,
            ApplicationId = request.ApplicationId,
            CustomerId = request.CustomerId,
            ProposalId = request.ProposalId,
            InstanceId = request.InstanceId,
            DeterministicHash = deterministicHash
        };
    }
}