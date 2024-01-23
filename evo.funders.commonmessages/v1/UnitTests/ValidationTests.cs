using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Request;

namespace UnitTests;

public class ValidationTests
{
    [Test]
    [TestCase("full")]
    [TestCase("no-address1")]
    [TestCase("no-bank")]
    [TestCase("no-curraddyr-main ")]
    [TestCase("no-email ")]
    [TestCase("no-mobtel-main")]
    [TestCase("no-title-main")]
    [TestCase("no-town")]
    [TestCase("no-annual-mileage")]
    [TestCase("no-postcode ")]
    public void TestValidMakeApplication(string test)
    {
        var testData = File.ReadAllText($@"TestData/MakeApplication/valid/{test}.json");

        var commonRequest = testData.FromJson<ApplicationRequest>();

        Assert.That(commonRequest?.IsValid, Is.True);
        
    }

    [Test]
    [TestCase("cash-price")]
    [TestCase("dob")]
    [TestCase("employment-status")]
    [TestCase("forename")]
    [TestCase("gross-income")]
    [TestCase("surname")]
    [TestCase("term")]
    public void TestValidMakeApplicationRequired(string test)
    {
        var testData = File.ReadAllText($@"../../../../../v1/UnitTests/TestData/MakeApplication/invalid/{test}.json");

        var commonRequest = testData.FromJson<ApplicationRequest>();

        Assert.That(commonRequest?.IsValid, Is.False);
    }
}