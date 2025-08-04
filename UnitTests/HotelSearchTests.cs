
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
    }
}