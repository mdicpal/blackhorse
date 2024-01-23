namespace Orchestrator.Database;

using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

public class CustomAzureSqlAuthProvider : SqlAuthenticationProvider
{
    private static readonly string[] _azureSqlScopes = new[]
    {
        "https://database.windows.net//.default"
    };
#if DEBUG
    private static readonly TokenCredential _credential = new VisualStudioCredential();
#else
    private static readonly TokenCredential _credential = new ManagedIdentityCredential();
#endif
    public override async Task<SqlAuthenticationToken> AcquireTokenAsync(SqlAuthenticationParameters parameters)
    {
        var tokenRequestContext = new TokenRequestContext(_azureSqlScopes);
        var tokenResult = await _credential.GetTokenAsync(tokenRequestContext, default);
        return new SqlAuthenticationToken(tokenResult.Token, tokenResult.ExpiresOn);
    }
    public override bool IsSupported(SqlAuthenticationMethod authenticationMethod) => authenticationMethod.Equals(SqlAuthenticationMethod.ActiveDirectoryManagedIdentity);
}