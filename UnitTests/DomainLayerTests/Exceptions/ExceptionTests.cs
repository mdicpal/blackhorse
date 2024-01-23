namespace UnitTests.DomainLayerTests.Exceptions
{
    using Domain.Exceptions;
    using Newtonsoft.Json;

    public class ExceptionTests
    {
        [TestCase(typeof(MappingException))]
        public void TestException(Type exceptionType)
        {
            TestExceptionParams(exceptionType);
            TestExceptionParams(exceptionType, "Error");
            TestExceptionParams(exceptionType, "Error", new Exception());
            TestExceptionSerialisation(exceptionType, "Error");
        }

        private static void TestExceptionParams(Type exceptionType, params object[] constructorArgs)
        {
            // Create the exception instance using reflection
            Exception? exception = Activator.CreateInstance(exceptionType, constructorArgs) as Exception;

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception, Is.InstanceOf(exceptionType));
            Assert.Multiple(() =>
            {
                Assert.That(exception, Is.InstanceOf<Exception>());
                if (constructorArgs.Length > 0)
                {
                    Assert.That(exception!.Message, Is.EqualTo(constructorArgs[0]));
                }
            });
        }

        private static void TestExceptionSerialisation(Type exceptionType, string errorMessage)
        {
            // Create the exception instance using reflection
            Exception? exception = Activator.CreateInstance(exceptionType, errorMessage) as Exception;

            string json = JsonConvert.SerializeObject(exception);
            Exception? deserialised = JsonConvert.DeserializeObject(json, exceptionType) as Exception;

            Assert.That(deserialised, Is.Not.Null);
            Assert.That(deserialised, Is.InstanceOf(exceptionType));
            Assert.That(deserialised!.Message, Is.EqualTo(errorMessage));
        }
    }
}