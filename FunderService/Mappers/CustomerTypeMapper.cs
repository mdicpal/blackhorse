namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderApi;

    public static class CustomerTypeMapper
    {
        public static CustomerType Map(int customerType)
        {
            return customerType switch
            {
                (int)CompanyType.Partnership => CustomerType.Partnership,
                (int) CompanyType.SoleTrader => CustomerType.Sole_Trader,
                (int)CompanyType.Limted => CustomerType.Limited_Company,
                 _ => CustomerType.Consumer
            };
        }
    }
}