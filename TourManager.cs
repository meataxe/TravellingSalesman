namespace TravellingSalesman
{
  using System.Collections.Generic;

  public class TourManager
  {
    // Holds our cities
    private static readonly List<City> DestinationCities = new List<City>();

    // Adds a destination city
    public static void AddCity(City city)
    {
      DestinationCities.Add(city);
    }

    // Get a city
    public static City GetCity(int index)
    {
      return DestinationCities[index];
    }

    // Get the number of destination cities
    public static int NumberOfCities()
    {
      return DestinationCities.Count;
    }
  }
}
