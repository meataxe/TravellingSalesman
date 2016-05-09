namespace TravellingSalesman
{
  public class Population
  {
    // Holds population of tours
    private readonly Tour[] tours;

    // Construct a population
    public Population(int populationSize, bool initialise)
    {
      this.tours = new Tour[populationSize];
      
      // If we need to initialise a population of tours do so
      if (initialise)
      {
        // Loop and create individuals
        for (var i = 0; i < this.PopulationSize(); i++)
        {
          var newTour = new Tour();
          newTour.GenerateIndividual();
          this.SaveTour(i, newTour);
        }
      }
    }

    // Saves a tour
    public void SaveTour(int index, Tour tour)
    {
      this.tours[index] = tour;
    }

    // Gets a tour from population
    public Tour GetTour(int index)
    {
      return this.tours[index];
    }

    // Gets the best tour in the population
    public Tour GetFittest()
    {
      var fittest = this.tours[0];
      
      // Loop through individuals to find fittest
      for (var i = 1; i < this.PopulationSize(); i++)
      {
        if (fittest.GetFitness() <= this.GetTour(i).GetFitness())
        {
          fittest = this.GetTour(i);
        }
      }

      return fittest;
    }

    // Gets population size
    public int PopulationSize()
    {
      return this.tours.Length;
    }
  }
}
