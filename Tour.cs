namespace TravellingSalesmanWithAnnealing
{
  using System.Collections.Generic;
  using System.Linq;

  public class Tour
  {
    // Holds our tour of cities
    private readonly List<City> tour = new List<City>();    

    // Cache
    private double distance = 0;

    // Constructs a blank tour
    public Tour()
    {
      for (var i = 0; i < TourManager.NumberOfCities(); i++)
      {
        this.tour.Add(null);
      }
    }

    // Constructs a tour from another tour
    public Tour(IEnumerable<City> tour)
    {
      this.tour = tour.Select(c => c.Clone()).ToList();
    }

    // Returns tour information
    public List<City> GetTour => this.tour;

    // Creates a random individual
    public void GenerateIndividual()
    {
      // Loop through all our destination cities and add them to our tour
      for (var cityIndex = 0; cityIndex < TourManager.NumberOfCities(); cityIndex++)
      {
        this.SetCity(cityIndex, TourManager.GetCity(cityIndex));
      }

      // Randomly reorder the tour
      this.tour.Shuffle();
    }

    // Gets a city from the tour
    public City GetCity(int tourPosition)
    {
      return this.tour[tourPosition];
    }

    // Sets a city in a certain position within a tour
    public void SetCity(int tourPosition, City city)
    {
      this.tour[tourPosition] = city;
      
      // If the tours been altered we need to reset the distance      
      this.distance = 0;
    }

    // Gets the total distance of the tour
    public double GetDistance()
    {
      if (this.distance == 0)
      {
        double tourDistance = 0;
        
        // Loop through our tour's cities
        for (var cityIndex = 0; cityIndex < this.TourSize(); cityIndex++)
        {
          // Get city we're travelling from
          var fromCity = this.GetCity(cityIndex);

          // City we're travelling to
          // Check we're not on our tour's last city, if we are set our
          // tour's final destination city to our starting city
          var destinationCity = cityIndex + 1 < this.TourSize() 
            ? this.GetCity(cityIndex + 1) 
            : this.GetCity(0);
          
          // Get the distance between the two cities
          tourDistance += fromCity.DistanceTo(destinationCity);
        }
        
        this.distance = tourDistance;
      }

      return this.distance;
    }

    // Get number of cities on our tour
    public int TourSize()
    {
      return this.tour.Count;
    }

    // Check if the tour contains a city
    public bool ContainsCity(City city)
    {
      return this.tour.Contains(city);
    }

    public override string ToString()
    {
      var geneString = "|";
      for (var i = 0; i < this.TourSize(); i++)
      {
        geneString += this.GetCity(i) + "|";
      }

      return geneString;
    }
  }
}
