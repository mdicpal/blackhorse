namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class AddonsMapper:IAddonsMapper
    {
        private const double defaultamount = 0.00;
        public Addons Map()
        {
            return new Addons()
            {
                Warranty=defaultamount,
                Guaranteed_asset_protection=defaultamount,
                Tyre_insurance=defaultamount,
                Breakdown_assistance=defaultamount,
                Service_plan=defaultamount,
                Cosmetic_protection=defaultamount,
                Leisure_non_tangibles=defaultamount
            };
        }
    }
}
