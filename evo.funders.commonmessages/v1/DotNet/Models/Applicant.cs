using System;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class Applicant
    {
        public Applicant()
        {
            Bank = new Bank();
            EmploymentHistory = new List<EmploymentHistory>();
            FinancialStatus = new FinancialStatus();
            FinancialStatus = new FinancialStatus();
            Company = new Company();
            Dob = new DateTimeOffset();
            MarketingPreference = new MarketingPreference();
            ResidenceHistory = new List<ResidenceHistory>();
        }

        [JsonProperty("applicantType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? ApplicantType { get; set; } = "";

        [JsonProperty("bank")]
        public Bank? Bank { get; set; }

        [JsonProperty("nationality", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Nationality { get; set; } = "";

        [JsonProperty("company", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Company? Company { get; set; }

        [JsonProperty("dob", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Dob { get; set; }

        [JsonProperty("drivingLicenceType", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string DrivingLicenceType { get; set; } = "";

        [JsonProperty("email", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; } = "";

        [JsonProperty("employmentHistory", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<EmploymentHistory>? EmploymentHistory { get; set; }

        [JsonProperty("financialStatus", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public FinancialStatus? FinancialStatus { get; set; }

        [JsonProperty("forename", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Forename { get; set; } = "";

        [JsonProperty("homephone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Homephone { get; set; } = "";

        [JsonProperty("isMainApplicant", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMainApplicant { get; set; }

        [JsonProperty("isUkResident", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUkResident { get; set; } = true;

        [JsonProperty("maritalStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? MaritalStatus { get; set; } = "";

        [JsonProperty("marketingPreference", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public MarketingPreference? MarketingPreference { get; set; }

        [JsonProperty("middlename", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Middlename { get; set; } = "";

        [JsonProperty("mobile", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Mobile { get; set; } = "";

        [JsonProperty("residenceHistory", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<ResidenceHistory>? ResidenceHistory { get; set; }

        [JsonProperty("sexAtBirth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? SexAtBirth { get; set; } = "";

        [JsonProperty("surname", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Surname { get; set; } = "";

        [JsonProperty("title", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; } = "";

        [JsonProperty("workphone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Workphone { get; set; } = "";

        [JsonProperty("companyType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public CompanyType? CompanyType { get; set; }
    }
}