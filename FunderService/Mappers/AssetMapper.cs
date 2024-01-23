namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Asset = FunderApi.Asset;
    using Assets = AzureFunderCommonMessages.DotNet.Models.Asset;
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderApi;
    internal class AssetMapper:IAssetMapper
    {
        public Asset Map(ApplicationRequest applicationRequest)
        {
            return new Asset()
            {
                //Goods_code = 0, TO DO
                //Vehicle_use = applicationReqppuest.Data.Asset.
                //(FunderApi.VehicleUse)((Convert.ToInt32(FunderApi.VehicleUse.Business)==1)?1:0),
                Registration_number = applicationRequest.Data.Asset.Vrm,
                //Business_use = VehicleUse.Business ? true: false, TO DO
                Vehicle_mileage = Convert.ToInt32(applicationRequest.Data.Asset.CurrentMileage),
                Registration_month = Registration_month(applicationRequest.Data.Asset.RegistrationDate.ToString()) ,// TO Be checked
                Registration_year = Convert.ToInt32(Registration_Year(applicationRequest.Data.Asset.RegistrationDate.ToString())),
                Make =  applicationRequest.Data.Asset.Make,
                New_vehicle =  (bool) applicationRequest.Data.Asset.IsNew,
                Cap_code = applicationRequest.Data.Asset.CapCode,
                //Hpi = "",
                Model=applicationRequest.Data.Asset.Model,
                Model_year =  Convert.ToBoolean(value: applicationRequest.Data.Asset.IsNew)?Convert.ToInt32(Registration_Year(applicationRequest.Data.Asset.RegistrationDate.ToString())):0,
                Description =applicationRequest.Data.Asset.Style,
                Goods_identification = applicationRequest.Data.Asset.Vin
            };
        } 
        private static string Registration_month(string RegistrationDate)
        {
            string RegDate = RegistrationDate;
            DateTime datevalue = (Convert.ToDateTime(RegDate.ToString()));
            string mn = datevalue.Month.ToString();
            return  mn;
        }
        private static string Registration_Year(string RegistrationDate)
        {
            string RegDate = RegistrationDate;
            DateTime datevalue = (Convert.ToDateTime(RegDate.ToString()));
            string mn = datevalue.Year.ToString();
            return mn;
        }
    }
}
