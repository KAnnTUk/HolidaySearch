
using NUnit.Framework;
using System.Collections.Generic;
using ConsoleApp;

namespace HolidaySearch
{
    [TestFixture]
    public class HolidaySearchTests
    {
        [Test]
        public void AllFlightsRequested_AllFlightsReturned()
        {
            var flights = Flight.ReadFlightsFromJson();

            Assert.That(flights, Is.Not.Null);
        }
    }
}
