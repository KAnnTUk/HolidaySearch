
using NUnit.Framework;
using System.Collections.Generic;
using ConsoleApp;

namespace HolidaySearch.UnitTests
{
    [TestFixture]
    public class FlightSearchTests
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
            Assert.That(flights.All(f => f.from == "MAN" && f.to == "AGP"), Is.True);
        }

        [Test]
        public void FlightsFromAnywhereToMallorca_ReturnAllFlightsToMallorca()
        {
            string fromAirport = "";
            string toAirport = "PMI";
            var flights = Flight.SearchForFlights(fromAirport, toAirport);
            Assert.That(flights.Any(f => f.to == toAirport), Is.True);
        }

        [Test]
        public void FlightsManchestertoAnywhere_ReturnAllFlightsFromManchester()
        {
            string fromAirport = "MAN";
            string toAirport = "";
            var flights = Flight.SearchForFlights(fromAirport, toAirport);
            Assert.That(flights.Any(f => f.from == fromAirport), Is.True);
        }

        [Test]
        public void FlightsFromMANToAGPOnSetDate_ReturnsFlightsFromMANToAGPOnDate()
        {
            string fromAirport = "MAN";
            string toAirport = "AGP";
            DateTime departureDate = new DateTime(2023, 7, 1);
            var flights = Flight.SearchForFlights(fromAirport, toAirport, departureDate);
            Assert.That(flights.All(f => f.from == fromAirport && f.to == toAirport &&
                f.departure_date.Date == departureDate.Date), Is.True);
        }
    }
}
