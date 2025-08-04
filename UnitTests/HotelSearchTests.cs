
using NUnit.Framework;
using System.Collections.Generic;
using ConsoleApp;

namespace HolidaySearch.UnitTests
{
    [TestFixture]
    public class HotelSearchTests
    {
        [Test]
        public void AllHotelsRequested_AllHotelsReturned()
        {
            var hotels = Hotel.ReadHotelsFromJson();
            Assert.That(hotels.Any(), Is.True);
        }

        [Test]
        public void HotelsSpecificDateAndDuration_ReturnsHotelsForSpecificDateAndDuration()
        {
            string arrivalDate = "2022-11-05";
            int nights = 7;
            var hotels = Hotel.SearchForHotels(arrivalDate, nights);
            Assert.That(hotels.All(h => h.arrival_date == arrivalDate && h.nights == nights), Is.True);
        }

        [Test]
        public void HotelsSearchBasedonDateAiportAndDuration_ReturnsHotelsForSpecificDateAirportAndDuration()
        {
            string arrivalDate = "2022-11-05";
            int nights = 7;
            string airport = "TFS";
            var hotels = Hotel.SearchForHotels(arrivalDate, nights, airport);
            Assert.That(hotels.All(h => h.arrival_date == arrivalDate && h.nights == nights &&
            h.local_airports.Any(a => a.Equals(airport, StringComparison.OrdinalIgnoreCase))), Is.True);
        }   
    }
}