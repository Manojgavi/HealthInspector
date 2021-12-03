using NUnit.Framework;
using HealthInspector.ControllerServices;

namespace HealthInspector.TestCase.ControllerServices.Tests
{
    public class UserServicesTest
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void GetUserId_returnsString()
        {
            var userservices = new UserServices();
            var result = userservices.GetUserId("TestSubject", "9876543210");
            Assert.That(result == "Tes987");
        }
    }
}