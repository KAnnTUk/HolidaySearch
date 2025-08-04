using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp
{
    public class Hotel
    {
        private static readonly string filePath = "Data/Hotel.json";

        #region Properties
        public int id { get; set; }
        public string name { get; set; }
        public string arrival_date { get; set; }
        public decimal price_per_night { get; set; }
        public string[] local_airports { get; set; }
        public int nights { get; set; }
        #endregion

        // Reads a list of hotels from a JSON file
        public static List<Hotel> ReadHotelsFromJson()
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            var json = File.ReadAllText(filePath);
            var hotels = JsonSerializer.Deserialize<List<Hotel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return hotels ?? new List<Hotel>();
        }

        // Searches for hotels based on arrival date and number of nights
        public static List<Hotel> SearchForHotels(string arrivalDate, int nights)
        {
            return ReadHotelsFromJson()
            .Where(h =>
                h.arrival_date.Equals(arrivalDate, StringComparison.OrdinalIgnoreCase) &&
                h.nights == nights
            )
            .ToList();
        }
    }
}