namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class IndividualMapper :IIndividualMapper
    {
        public Individual Map(Applicant applicant)
        {
            return new Individual()
            {
                Title = TitleMapper.Map(applicant.Title),
                First_name = applicant.Forename,
                Middle_initial = applicant.Middlename,
                Surname = applicant.Surname,
                Date_of_birth = Convert.ToString(applicant.Dob),
                Email_address = applicant.Email,
                Contact_number = applicant.Mobile,
                Contact_number_alternative = applicant.Homephone,
                Number_of_dependants = "0",
                Marital_status = MaritalStatusMapper.Map(applicant.MaritalStatus),
                Residential_status = ResidentialStatusMapper.Map(applicant.ResidenceHistory?.FirstOrDefault()?.ResidentialStatusShortcode),
                Nationality = NationalityMapper.Map(applicant.Nationality)                
            };
        }
    }
}
