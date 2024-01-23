namespace FunderService.Mappers
{   
    using FunderService.Mappers.Interfaces;
    using Address = FunderApi.Address;
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;
    using Microsoft.Extensions.Logging;

    public class AddressMapper : IAddressMapper
    {     
        public Address[] Map(ICollection<ResidenceHistory> address)
        {
            Address[] mapAddressDetails = address.Select(history => new Address
            {
                Address_number = AddressTypeMapper.Map(history.OrderNumber),
                County = history.Address.County,
                House_name = history.Address.HouseName,
                House_number = history.Address.HouseNumber,
                Months_at_address = Convert.ToString(history.MonthsAtAddress),
                Years_at_address = Convert.ToString(history.YearsAtAddress),
                Street = history.Address.AddressLine1,
                District = history.Address.AddressLine2,
                Town = history.Address.Town,
                Postcode = history.Address.Postcode,
                Flat_number = history.Address.Unit
            }).ToArray<Address>();
           
            return mapAddressDetails;
        }
    }
}