using AzureFunderCommonMessages.DotNet.Types;

namespace AzureFunderCommonMessages.DotNet.Interfaces.Response
{
    public interface ISubResponseType
    {
        ResponseType DefaultResponseType { get; }
    }
}