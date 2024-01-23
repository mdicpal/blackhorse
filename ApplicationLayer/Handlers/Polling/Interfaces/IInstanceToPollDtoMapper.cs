namespace ApplicationLayer.Handlers.Polling.Interfaces;

using ApplicationLayer.Models;
using Models;

public interface IInstanceToPollDtoMapper
{
    InstanceToPollDto Map(UpsertRequest request);
}