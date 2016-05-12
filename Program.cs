namespace TravellingSalesmanWithAnnealing
{
  using System;
  
  public class Program
  {
    // Calculate the acceptance probability
    public static double AcceptanceProbability(double energy, double newEnergy, double temperature)
    {
      // If the new solution is better, accept it
      // If the new solution is worse, calculate an acceptance probability
      return newEnergy < energy 
        ? 1.0 
        : Math.Exp((energy - newEnergy) / temperature);
    }

    public static void Main(string[] args)
    {
      // Create and add our cities
      var city = new City(60, 200);
      TourManager.AddCity(city);
      var city2 = new City(180, 200);
      TourManager.AddCity(city2);
      var city3 = new City(80, 180);
      TourManager.AddCity(city3);
      var city4 = new City(140, 180);
      TourManager.AddCity(city4);
      var city5 = new City(20, 160);
      TourManager.AddCity(city5);
      var city6 = new City(100, 160);
      TourManager.AddCity(city6);
      var city7 = new City(200, 160);
      TourManager.AddCity(city7);
      var city8 = new City(140, 140);
      TourManager.AddCity(city8);
      var city9 = new City(40, 120);
      TourManager.AddCity(city9);
      var city10 = new City(100, 120);
      TourManager.AddCity(city10);
      var city11 = new City(180, 100);
      TourManager.AddCity(city11);
      var city12 = new City(60, 80);
      TourManager.AddCity(city12);
      var city13 = new City(120, 80);
      TourManager.AddCity(city13);
      var city14 = new City(180, 60);
      TourManager.AddCity(city14);
      var city15 = new City(20, 40);
      TourManager.AddCity(city15);
      var city16 = new City(100, 40);
      TourManager.AddCity(city16);
      var city17 = new City(200, 40);
      TourManager.AddCity(city17);
      var city18 = new City(20, 20);
      TourManager.AddCity(city18);
      var city19 = new City(60, 20);
      TourManager.AddCity(city19);
      var city20 = new City(160, 20);
      TourManager.AddCity(city20);

      double temp = 10000;

      // Cooling rate
      var coolingRate = 0.0015;

      // Initialize intial solution
      var currentSolution = new Tour();
      currentSolution.GenerateIndividual();

      Console.WriteLine("Initial solution distance: " + currentSolution.GetDistance());

      // Set as current best
      var best = new Tour(currentSolution.GetTour);
      var random = new Random();

      // Loop until system has cooled
      while (temp > 1)
      {
        // Create new neighbour tour
        Tour newSolution = new Tour(currentSolution.GetTour);

        // Get a random positions in the tour
        int tourPos1 = (int)(newSolution.TourSize() * random.NextDouble());
        int tourPos2 = (int)(newSolution.TourSize() * random.NextDouble());

        // Get the cities at selected positions in the tour
        City citySwap1 = newSolution.GetCity(tourPos1);
        City citySwap2 = newSolution.GetCity(tourPos2);

        // Swap them
        newSolution.SetCity(tourPos2, citySwap1);
        newSolution.SetCity(tourPos1, citySwap2);

        // Get energy of solutions
        var currentEnergy = currentSolution.GetDistance();
        var neighbourEnergy = newSolution.GetDistance();

        // Decide if we should accept the neighbour
        if (AcceptanceProbability(currentEnergy, neighbourEnergy, temp) > random.NextDouble())
        {
          currentSolution = new Tour(newSolution.GetTour);
        }

        // Keep track of the best solution found
        if (currentSolution.GetDistance() < best.GetDistance())
        {
          best = new Tour(currentSolution.GetTour);
        }

        // Cool system
        temp *= 1 - coolingRate;
      }

      Console.WriteLine("Final solution distance: " + best.GetDistance());
      Console.WriteLine("Tour: " + best);

      Console.ReadLine();
    }
  }
}
