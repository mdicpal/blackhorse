namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderGender = FunderApi.Gender;

    public static class GenderMapper
    {
        public static FunderGender Map(string gender)
        {
            return gender.ToLower() switch
            {
                Gender.Male => FunderGender.Male,
                Gender.Female => FunderGender.Female,
                _ => FunderGender.Unspecified
            };
        }
    }
}