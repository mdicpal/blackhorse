namespace KeyVaultService
{
    using Azure;
    using Azure.Security.KeyVault.Secrets;
    using Domain;
    using Domain.Logger;
    using Microsoft.Extensions.Logging;

    public class KeyVaultClient : ISecretClient
    {
        private readonly SecretClient _secretClient;
        private readonly ILogger<KeyVaultClient> _logger;

        public KeyVaultClient(SecretClient secretClient, ILogger<KeyVaultClient> logger)
        {
            _secretClient = secretClient;
            _logger = logger;
        }
        
        public async Task<string> GetSecretAsync(string secretName)
        {
            try
            {
                Response<KeyVaultSecret> response = await _secretClient.GetSecretAsync(secretName);
                return response.Value.Value;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception thrown when attempting to retrieve secret from KeyVault {SecretName}", secretName);
                throw;
            }
        }
    }
}