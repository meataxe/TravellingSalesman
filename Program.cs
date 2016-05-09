namespace TravellingSalesman
{
  using System;
  
  public class Program
  {
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

      // Initialize population
      var pop = new Population(50, true);
      Console.WriteLine("Initial distance: " + pop.GetFittest().GetDistance());

      // Evolve population for 100 generations
      var ga = new GeneticAlgorithm(0.015, 10, true);
      pop = ga.EvolvePopulation(pop);
      for (var i = 0; i < 100; i++)
      {
        pop = ga.EvolvePopulation(pop);
      }

      // Print final results
      Console.WriteLine("Finished");
      Console.WriteLine("Final distance: " + pop.GetFittest().GetDistance());
      Console.WriteLine("Solution:");
      Console.WriteLine(pop.GetFittest());

      Console.ReadLine();
    }
  }
}
