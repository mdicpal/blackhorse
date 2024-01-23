namespace ApplicationLayer.Handlers.MakeApplication.Interfaces;

using Models;

public interface IMakeApplicationHandler
{
    Task<MakeApplicationActivityResponse> Run(MakeApplicationActivityRequest request);
}