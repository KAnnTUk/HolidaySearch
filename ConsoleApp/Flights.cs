using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp
{
    public class Flight
    {
        private static readonly string filePath = "Data/Flight.json";

        #region Properties
        public int id { get; set; }
        public string airline { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime departure_date { get; set; }
        public decimal price { get; set; }
        #endregion

        // Reads a list of flights from a JSON file
        public static List<Flight> ReadFlightsFromJson()
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            var json = File.ReadAllText(filePath);
            var flights = JsonSerializer.Deserialize<List<Flight>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return flights ?? new List<Flight>();
        }

        // Searches for flights based on departure and arrival airports
        public static List<Flight> SearchForFlights(string fromAirport, string toAirport, DateTime? departureDate = null)
        {
            return ReadFlightsFromJson()
            .Where(f =>
                (string.IsNullOrEmpty(fromAirport) || f.from.Equals(fromAirport, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(toAirport) || f.to.Equals(toAirport, StringComparison.OrdinalIgnoreCase)) &&
                (!departureDate.HasValue || f.departure_date.Date == departureDate.Value.Date)
            )
            .ToList();
        }
    }
}

