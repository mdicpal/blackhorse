namespace UnitTests.DomainLayerTests.FunderService.Clients
{
    using FunderApi;
    using global::FunderService.Clients;
    using global::FunderService.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class FunderClientTests
    {
        private Mock<IFunderClient> _funderClientMock = null!;
        private Mock<FunderApi> _funderApi = null!;

        [SetUp]
        public void Setup()
        {
            int majorDealerId = 25000000;
            int minorDealerId = 57076700;
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            _funderApi = new Mock<FunderApi>("", new Mock<HttpClient>().Object);
            _funderClientMock = new Mock<IFunderClient>();
            _funderApi
                .Setup(x => x.SendapplicationAsync(majorDealerId,minorDealerId,idempotency,It.IsAny<SendApplicationRequest>()))
                .ReturnsAsync(new SendApplicationResponse());
            
            _funderApi
                .Setup(x => x.PutcustomerAsync(It.IsAny<int>(), majorDealerId, minorDealerId, idempotency, It.IsAny<SendApplicationRequest>()))
                .ReturnsAsync(new PutCustomerResponse());
            
            _funderApi
                .Setup(x => x.GetdecisionAsync(It.IsAny<int>(), It.IsAny<int>(),majorDealerId,minorDealerId))
                .ReturnsAsync(new Decision());
        }

        [Test]
        public void SendApplicationTest()
        {
            int majorDealerId = 25000000;
            int minorDealerId = 57076700;
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            SendApplicationResponse funderResponse = new();
            PutCustomerResponse putCustomerResponse = new();
            PostSubmitResponse postSubmitResponse = new();
            NotTakenUpResponse notTakenUpResponse = new();
            GetPlanResponse getPlanResponse = new();
            PostUploadResponse postUploadResponse = new();
            Decision decision = new();
            _funderClientMock
           .Setup(x => x.UpdateApplicationAsync(majorDealerId,minorDealerId,idempotency,It.IsAny<SendApplicationRequest>(),It.IsAny<int>()))
           .ReturnsAsync(putCustomerResponse);

            _funderClientMock
            .Setup(x => x.SendApplicationAsync(majorDealerId, minorDealerId, idempotency, It.IsAny<SendApplicationRequest>()))
            .ReturnsAsync(funderResponse);

            _funderClientMock
            .Setup(x => x.SendSubmitAsync(majorDealerId, minorDealerId, idempotency, It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(postSubmitResponse);

            _funderClientMock
            .Setup(x => x.NotTakenUpAsync(majorDealerId, minorDealerId, idempotency, It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(notTakenUpResponse);

            _funderClientMock
            .Setup(x => x.GetPlansAsync(majorDealerId, minorDealerId,It.IsAny<int>()))
            .ReturnsAsync(getPlanResponse);

            _funderClientMock
            .Setup(x => x.UploadAsync(majorDealerId, minorDealerId, idempotency, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<PostUploadRequest>()))
            .ReturnsAsync(postUploadResponse);

            _funderClientMock
            .Setup(x => x.GetApplicationStatusAsync(majorDealerId, minorDealerId, It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(decision);

            Assert.Multiple(() =>
            {
                Assert.That(putCustomerResponse, Is.Not.Null);
                Assert.That(putCustomerResponse, Is.TypeOf<PutCustomerResponse>());

                Assert.That(funderResponse, Is.Not.Null);
                Assert.That(funderResponse, Is.TypeOf<SendApplicationResponse>());

                Assert.That(postSubmitResponse, Is.Not.Null);
                Assert.That(postSubmitResponse, Is.TypeOf<PostSubmitResponse>());

                Assert.That(notTakenUpResponse, Is.Not.Null);
                Assert.That(notTakenUpResponse, Is.TypeOf<NotTakenUpResponse>());

                Assert.That(getPlanResponse, Is.Not.Null);
                Assert.That(getPlanResponse, Is.TypeOf<GetPlanResponse>());

                Assert.That(postUploadResponse, Is.Not.Null);
                Assert.That(postUploadResponse, Is.TypeOf<PostUploadResponse>());

                Assert.That(decision, Is.Not.Null);
                Assert.That(decision, Is.TypeOf<Decision>());
            });
        }        
    }
}