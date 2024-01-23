namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using System.Collections.Generic;
    using Address = FunderApi.Address;
    public interface IAddressMapper
    {
        Address[] Map(ICollection<ResidenceHistory> address);
    }
}