namespace InstanceStoreAdapter.Interfaces;

using ApplicationLayer.Models;
using System.Threading.Tasks;

public interface IInstanceStoreServiceAdapter
{
    Task<Instance> GetAsync(int quoteId);
    Task CreateAsync(int quoteId, string instanceId);
    Task SetApplicationIdAsync(int quoteId, string instanceId, string applicationId);
}