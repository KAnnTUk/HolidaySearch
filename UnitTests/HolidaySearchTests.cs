
using NUnit.Framework;
using System.Collections.Generic;
using ConsoleApp;

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
            var holidays = Holiday.SearchForHolidays(searchCriteria);

            Assert.That(holidays.Any(), Is.True);

            Assert.That(holidays.Results.First().TotalPrice, Is.EqualTo(245 + (83 * 7)));
            Assert.That(holidays.Results.First().Flight.Id, Is.EqualTo(1));
            Assert.That(holidays.Results.First().Flight.DepartingFrom, Is.EqualTo("MAN"));
            Assert.That(holidays.Results.First().Flight.TravalingTo, Is.EqualTo("AGP'"));
            Assert.That(holidays.Results.First().Flight.Price, Is.EqualTo(245));
            Assert.That(holidays.Results.First().Hotel.Id, Is.EqualTo(9));
            Assert.That(holidays.Results.First().Hotel.Name, Is.EqualTo("Hotel Costa del Sol"));
            Assert.That(holidays.Results.First().Hotel.Price, Is.EqualTo(83));

        }
    }
}