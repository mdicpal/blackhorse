namespace Domain
{
    public interface ISecretClient
    {
        Task<string> GetSecretAsync(string secretName);
    }
}