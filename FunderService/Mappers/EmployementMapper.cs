namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;

    internal class EmployementMapper : IEmployementMapper
    {
        public Employment Map(EmploymentHistory employmentHistories)
        {
            return new Employment()
            {
                //Permanent_employee = employmentHistories. TO DO
                Full_time = employmentHistories.EmploymentType.Equals("full time"),    
                Employment_type = EmploymentTypeMapper.Map(employmentHistories.EmploymentType),
                Occupation = employmentHistories.OccupationType,
                Employer_name = employmentHistories.Company,
                Employer_address = new Employer_address
                {
                    Address_number = AddressTypeMapper.Map(employmentHistories.OrderNumber),
                    County = employmentHistories.Address.County,
                    House_name = employmentHistories.Address.HouseName,
                    House_number = employmentHistories.Address.HouseNumber,
                    Street = employmentHistories.Address.AddressLine1,
                    District = employmentHistories.Address.AddressLine2,
                    Town = employmentHistories.Address.Town,
                    Postcode = employmentHistories.Address.Postcode,
                    Flat_number = employmentHistories.Address.Unit
                },
                Years_with_employer = Convert.ToString(employmentHistories.YearsAtCompany),
                Months_with_employer = Convert.ToString(employmentHistories.MonthsAtCompany)
            };            
        }
    }
}