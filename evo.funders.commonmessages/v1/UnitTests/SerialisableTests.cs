using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Models;
using Newtonsoft.Json;
using AzureFunderCommonMessages.DotNet.Helpers;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;
using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using AzureFunderCommonMessages.DotNet;

namespace UnitTests
{
    public class SerialisableTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SerialisableErrorList()
        {
            Serialisable testClass = new();
            Assert.That(testClass, Is.Not.Null);
            testClass.Errors.Clear();
            Assert.That(testClass.Errors, Is.Empty);
            testClass.Errors.Add("error");
            Assert.That(testClass.Errors, Has.Count.EqualTo(1));
            Assert.That(testClass.Errors[0], Is.EqualTo("error"));
        }

        [Test]
        public void IsValidTests()
        {
            Serialisable testClass = new();
            Assert.That(testClass, Is.Not.Null);
            testClass.Errors.Clear();
            Assert.That(testClass.IsValid, Is.True);
            testClass.Errors.Add("error");
            Assert.That(testClass, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(testClass.Errors, Has.Count.EqualTo(1));
                Assert.That(testClass.IsValid, Is.EqualTo(false));
            });
        }
    }
}