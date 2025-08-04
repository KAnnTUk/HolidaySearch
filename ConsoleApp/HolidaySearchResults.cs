using ConsoleApp;

public class HolidaySearchResults
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalPrice => Flight.price + (Hotel.price_per_night * Hotel.nights);
    }