namespace ApplicationLayer.Interfaces;

using Models;

public interface IInstanceToPollRepository
{
    Task<List<InstanceToPollDto>> GetAllAsync();
    Task<bool> UpsertAsync(InstanceToPollDto instanceDto);
    Task<bool> DeleteAsync(string applicationId);
}