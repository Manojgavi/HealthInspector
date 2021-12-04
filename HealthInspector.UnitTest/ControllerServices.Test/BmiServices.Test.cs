using NUnit.Framework;
using HealthInspector.ControllerServices;

namespace HealthInspector.TestCase.ControllerServices.Tests
{
    public class BmiServicesTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Calculator_returnsbmi()
        {
            var bmiservices = new BmiServices();
            var result = bmiservices.Calculator(1.82, 80);
            Assert.That(result == 80 / (1.82 * 1.82));
        }
    }
}