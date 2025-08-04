
using NUnit.Framework;
using System.Collections.Generic;
using ConsoleApp;
using HolidaySearch;

namespace HolidaySearch.UnitTests
{
    [TestFixture]
    public class HolidaySearchTests
    {
        [Test]
        public void HolidaysFromMANtoAGP_ReturnHolidaysFromMANtoAGPInPriceOrdere()
        {
            var searchCriteria = new HolidaySearchCriteria
            {
                fromAirport = "MAN",
                toAirport = "AGP",
                departureDate = new DateTime(2023, 7, 1),
                duration = 7,
            };

            var holidays = HolidaySearches.SearchForHolidays(searchCriteria);

            Assert.That(holidays.Any(), Is.True);

            Assert.That(holidays.First().TotalPrice, Is.EqualTo(245 + (83 * 7)));
            Assert.That(holidays.First().Flight.id, Is.EqualTo(2));
            Assert.That(holidays.First().Flight.from, Is.EqualTo("MAN"));
            Assert.That(holidays.First().Flight.to, Is.EqualTo("AGP"));
            Assert.That(holidays.First().Flight.price, Is.EqualTo(245));
            Assert.That(holidays.First().Hotel.id, Is.EqualTo(9));
            Assert.That(holidays.First().Hotel.name, Is.EqualTo("Nh Malaga"));
            Assert.That(holidays.First().Hotel.price_per_night, Is.EqualTo(83));

        }
    }
}