namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderApi;

    public static class AddressTypeMapper
    {
        public static AddressType Map(long addressType)
        {
            return addressType switch
            {
              0 =>  AddressType.Current_Address,
              1 => AddressType.Previous_Address,
              2 => AddressType.Address_prior_to_Previous_Address_1,
              3 => AddressType.Address_prior_to_Previous_Address_2,
              4 => AddressType.Address_prior_to_Previous_Address_3,
              5 => AddressType.Address_prior_to_Previous_Address_4,
              _ => AddressType.Undeclared_Address
            };
        }
    }
}