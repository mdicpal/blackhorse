namespace FunderService.Clients;

using AzureFunderCommonMessages.DotNet.Models;
using Domain;
using FunderApi;
using Interfaces;
using System.Net.Http;

public class FunderClient : FunderApi, IFunderClient
{
    public FunderClient(string funderEndpoint, HttpClient httpClient) : base(httpClient)
    {
        
    }

    public async Task<SendApplicationResponse> SendApplicationAsync(int majorDealerId, int minorDealerId, string idempotency, SendApplicationRequest funderRequest)
    {
        return await SendapplicationAsync(majorDealerId, minorDealerId, idempotency, funderRequest);
    }
    public async Task<PutCustomerResponse> UpdateApplicationAsync(int majorDealerId, int minorDealerId, string idempotency, SendApplicationRequest funderRequest, int customerId)
    {
        return await PutcustomerAsync(customerId, majorDealerId, minorDealerId, idempotency, funderRequest);
    }
    public async Task<PostSubmitResponse> SendSubmitAsync(int majorDealerId, int minorDealerId, string idempotency, int customerId, int proposalId)
    {
        return await PostsubmitAsync(customerId, proposalId, majorDealerId, minorDealerId, idempotency);
    }
    public async Task<NotTakenUpResponse> NotTakenUpAsync(int majorDealerId, int minorDealerId, string idempotency, int customerId, int proposalId)
    {
        return await NottakenupAsync(customerId, proposalId,majorDealerId, minorDealerId,idempotency);
    }
    public async Task<GetPlanResponse> GetPlansAsync(int majorDealerId, int minorDealerId,int planId)
    {
        return await GetplansAsync(majorDealerId,minorDealerId, planId);
    }
    public async Task<PostUploadResponse> UploadAsync(int majorDealerId, int minorDealerId, string idempotency, int customerId, int proposalId, PostUploadRequest postUploadRequest)
    {
        return await PostuploadsAsync(customerId, proposalId, majorDealerId,minorDealerId,idempotency, postUploadRequest);
    }
    public async Task<Decision> GetApplicationStatusAsync(int majorDealerId, int minorDealerId, int customerId, int proposalId)
    {
        return await GetdecisionAsync(majorDealerId,minorDealerId, customerId, proposalId);
    }
}