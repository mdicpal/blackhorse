namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderApi;
    using FunderMaritalStatus =  FunderApi.MaritalStatus;
    using MaritalStatus = AzureFunderCommonMessages.DotNet.Types.ValueConstants.MaritalStatus;

    public static class MaritalStatusMapper
    {
        public static FunderMaritalStatus Map(string maritalStatus)
        {
            return maritalStatus.ToLower() switch
            {
                MaritalStatus.Single => FunderMaritalStatus.Single,
                MaritalStatus.Married => FunderMaritalStatus.Married,
                MaritalStatus.LivingWithPartner => FunderMaritalStatus.CoHabiting,
                MaritalStatus.Divorced => FunderMaritalStatus.Divorced,
                MaritalStatus.Seperated => FunderMaritalStatus.Separated,
                MaritalStatus.Widowed => FunderMaritalStatus.Widowed,
                _ => FunderMaritalStatus.Single
            };
        }
    }
}