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

    internal class OrganisationMapper : IOrganisationMapper
    {
        public Organisation Map(Applicant applicant)
        {         
            return new Organisation
            {
                Company_type = CustomerTypeMapper.Map(Convert.ToInt32(applicant?.CompanyType)).ToString(),
                Company_name = applicant?.Company.Name,
                Company_registered_number = applicant?.Company.CompanyNumber,
                Trading_as_name = String.Empty,
                Contact = new()
                {
                    Name = applicant?.Forename+""+applicant?.Surname
                },
                Contact_number = applicant?.Company.Phone,
                Vat_number = applicant?.Company.VatNumber,
                Vat_registered = Convert.ToBoolean(applicant?.Company.IsVatRegistered),
               // Incorporation_date = Incorporation_date(Convert.ToInt32(applicant?.Company?.EstablishedMonth),Convert.ToInt32(applicant?.Company.EstablishedYear)),
                Nature_of_business = applicant?.Company.Nature,
                Industry_code = applicant?.Company.Sortcode,
                Additional_personnel = null,
                Email_address = applicant?.Email,
                Contact_number_alternative = applicant?.Homephone                
            };
        }       
    }
}
