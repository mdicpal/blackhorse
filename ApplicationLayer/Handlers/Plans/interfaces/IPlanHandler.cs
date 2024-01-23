namespace ApplicationLayer.Handlers.Plans.Interfaces;

using FunderApi;
using Models;

public interface IPlanHandler
{
    Task<GetPlanResponse> Run(int planId);
}