using NUnit.Framework;
using Calendar.Events;

namespace Calendar.Tests.Events
{
    public class EventDateCalculatorTests
    {
        private EventDateCalculator _eventDateCalculator;
        [SetUp]
        public void SetUp()
        {
            _eventDateCalculator = new EventDateCalculator();
        }

        [Test]
        public void Test()
        {
            Assert.IsTrue(true);
        }
    }
}