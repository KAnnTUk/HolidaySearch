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
        public static List<Flight> SearchForFlights(string fromAirport, string toAirport)
        {
            var flights = ReadFlightsFromJson();

            var query = flights.AsEnumerable();

            if (!string.IsNullOrEmpty(fromAirport))
                query = query.Where(f => f.from.Equals(fromAirport, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(toAirport))
                query = query.Where(f => f.to.Equals(toAirport, StringComparison.OrdinalIgnoreCase));

            return query.ToList();
        }
    }
}

