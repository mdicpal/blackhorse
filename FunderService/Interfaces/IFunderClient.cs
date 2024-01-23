namespace FunderService.Interfaces;

using FunderApi;

/**
 * We define our own methods to use throughout the application with this interface,
 * this will help to standardise these method names throughout all the integrations
 * making it easier to recognise what the method is  
 */
public interface IFunderClient
{
    System.Threading.Tasks.Task<SendApplicationResponse> SendApplicationAsync(int majorDealerId, int minorDealerId, string idempotency, SendApplicationRequest funderRequest);
    System.Threading.Tasks.Task<Decision> GetApplicationStatusAsync(int majorDealerId, int minorDealerId, int customerId, int proposalId);
    System.Threading.Tasks.Task<PutCustomerResponse> UpdateApplicationAsync(int majorDealerId, int minorDealerId, string idempotency, SendApplicationRequest funderRequest, int customerId);
    System.Threading.Tasks.Task<PostSubmitResponse> SendSubmitAsync(int majorDealerId, int minorDealerId, string idempotency, int customerId, int proposalId);
    System.Threading.Tasks.Task<NotTakenUpResponse> NotTakenUpAsync(int majorDealerId, int minorDealerId, string idempotency, int customerId, int proposalId);
    System.Threading.Tasks.Task<GetPlanResponse> GetPlansAsync(int majorDealerId, int minorDealerId, int planId);
    System.Threading.Tasks.Task<PostUploadResponse> UploadAsync(int majorDealerId, int minorDealerId, string idempotency, int customerId, int proposalId, PostUploadRequest postUploadRequest);




}