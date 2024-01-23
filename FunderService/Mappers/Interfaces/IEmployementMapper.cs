namespace FunderService.Mappers.Interfaces
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;
    using System.Collections.Generic;

    internal interface IEmployementMapper
    {
        Employment Map(EmploymentHistory employmentHistories);
    }
}