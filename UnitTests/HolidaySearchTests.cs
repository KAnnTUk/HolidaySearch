
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
            Assert.That(flights.Any(), Is.True);
        }

        [Test]
        public void FlightsFromManchesterToMalaga_ReturnsFlightsFromManchesterToMalaga()
        {
            string fromAirport = "MAN"; 
            string toAirport = "AGP"; 
            var flights = Flight.SearchForFlights(fromAirport, toAirport);
            Assert.That(flights, Is.Not.Empty);
        }
    }
}
