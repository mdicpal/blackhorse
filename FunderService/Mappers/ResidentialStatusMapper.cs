namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderResidentialStatus = FunderApi.ResidentialStatus;


    public static class ResidentialStatusMapper
    {

        public static FunderResidentialStatus Map(string residentialStatusShortCode)
        {
            return residentialStatusShortCode.ToLower() switch
            {
                ResidentialStatus.Owner => FunderResidentialStatus.Home_Owner,
                ResidentialStatus.WithParents => FunderResidentialStatus.Living_with_parents,
                ResidentialStatus.TenantUnfurnished => FunderResidentialStatus.Tenant,
                ResidentialStatus.TenantFurnished => FunderResidentialStatus.Tenant,             
                _ => FunderResidentialStatus.Other,
            };
        }
    }
}