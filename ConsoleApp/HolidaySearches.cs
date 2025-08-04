
namespace ConsoleApp
{
    public class HolidaySearches
    {
        public static List<HolidaySearchResults> SearchForHolidays(HolidaySearchCriteria criteria)
        {
            var flights = Flight.SearchForFlights(criteria.fromAirport, criteria.toAirport, criteria.departureDate);
            var hotels = Hotel.SearchForHotels(criteria.departureDate.ToString("yyyy-MM-dd"), criteria.duration, criteria.toAirport);

            var results = new List<HolidaySearchResults>();

            foreach (var flight in flights)
            {
                foreach (var hotel in hotels)
                {
                    if (flight.to == hotel.local_airports[0]) // Assuming the first airport is the destination
                    {
                        results.Add(new HolidaySearchResults
                        {
                            Flight = flight,
                            Hotel = hotel
                        });
                    }
                }
            }

            return results.OrderBy(r => r.TotalPrice).ToList();
        }

    }
}