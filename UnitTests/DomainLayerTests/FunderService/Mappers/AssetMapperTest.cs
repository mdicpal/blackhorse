namespace UnitTests.DomainLayerTests.FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using FunderApi;
    using global::FunderService.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Asset = FunderApi.Asset;

    internal class AssetMapperTest
    {
        private AssetMapper _mapper = null!;
        private ApplicationRequest _mainApplicant = null!;
        [SetUp]
        public void SetUp()
        {

            _mapper = new AssetMapper();
            _mainApplicant = new ApplicationRequest();
        }
        [Test]
        public void AssetTest()
        {
            _mainApplicant = new ApplicationRequest()
            {
                Data = new()
                {
                    Asset = new()
                    {
                        Vrm = "Ts56Fc1505",
                        CurrentMileage = 40,
                        RegistrationDate = DateTime.Now,
                        Make = "abcd",
                        IsNew = true,
                        CapCode = "defscg",
                        Model = "benz",
                        Style = "foren",
                        Vin = "1233"
                    }
                }
            };
            Asset asset = _mapper.Map(_mainApplicant);
            Assert.That(asset, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(asset.Registration_number, Is.EqualTo(_mainApplicant.Data.Asset.Vrm));
                Assert.That(asset.Make, Is.EqualTo(_mainApplicant.Data.Asset.Make));
                Assert.That(asset.Vehicle_mileage, Is.EqualTo(_mainApplicant.Data.Asset.CurrentMileage));
                Assert.That(asset.New_vehicle, Is.EqualTo(_mainApplicant.Data.Asset.IsNew));
                Assert.That(asset.Cap_code, Is.EqualTo(_mainApplicant.Data.Asset.CapCode));
                Assert.That(asset.Registration_number, Is.EqualTo(_mainApplicant.Data.Asset.Vrm));
                Assert.That(asset.Description, Is.EqualTo(_mainApplicant.Data.Asset.Style));
                Assert.That(asset.Goods_identification, Is.EqualTo(_mainApplicant.Data.Asset.Vin));
            });
        }
    }
}
