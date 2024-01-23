namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using EmploymentType = FunderApi.EmploymentType;

    public static class EmploymentTypeMapper
    {
        public static EmploymentType Map(string employmentType)
        {
            return employmentType switch
            {
              EmploymentStatus.Employed =>  EmploymentType.Government,
              EmploymentStatus.SelfEmployed => EmploymentType.Self_Employed,
              EmploymentStatus.Retired => EmploymentType.Retired,
              EmploymentStatus.NonWorking => EmploymentType.Unemployed,
              _ => EmploymentType.Student           
            };
        }
    }
}