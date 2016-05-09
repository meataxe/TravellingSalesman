namespace TravellingSalesman
{
  using System;

  public class GeneticAlgorithm
  {
    /* GA parameters */
    private readonly double mutationRate;
    private readonly int tournamentSize;
    private readonly bool elitism;

    private readonly Random random = new Random();

    public GeneticAlgorithm()
      : this(0.015, 10, true)
    {
    }

    public GeneticAlgorithm(double mutationRate, int tournamentSize, bool elitism)
    {
      this.mutationRate = mutationRate;
      this.tournamentSize = tournamentSize;
      this.elitism = elitism;
    }

    // Evolves a population over one generation
    public Population EvolvePopulation(Population pop)
    {
      var newPopulation = new Population(pop.PopulationSize(), false);

      // Keep our best individual if elitism is enabled
      var elitismOffset = 0;
      if (this.elitism)
      {
        newPopulation.SaveTour(0, pop.GetFittest());
        elitismOffset = 1;
      }

      // Crossover population
      // Loop over the new population's size and create individuals from
      // Current population
      for (var i = elitismOffset; i < newPopulation.PopulationSize(); i++)
      {
        // Select parents
        var parent1 = this.TournamentSelection(pop);
        var parent2 = this.TournamentSelection(pop);

        // Crossover parents
        var child = Crossover(parent1, parent2);
        
        // Add child to new population
        newPopulation.SaveTour(i, child);
      }

      // Mutate the new population a bit to add some new genetic material
      for (var i = elitismOffset; i < newPopulation.PopulationSize(); i++)
      {
        this.Mutate(newPopulation.GetTour(i));
      }

      return newPopulation;
    }

    // Applies crossover to a set of parents and creates offspring
    private Tour Crossover(Tour parent1, Tour parent2)
    {
      // Create new child tour
      var child = new Tour();

      // Get start and end sub tour positions for parent1's tour
      var startPos = (int)(this.random.NextDouble() * parent1.TourSize());
      var endPos = (int)(this.random.NextDouble() * parent1.TourSize());

      // Loop and add the sub tour from parent1 to our child
      for (var i = 0; i < child.TourSize(); i++)
      {
        // If our start position is less than the end position
        if (startPos < endPos && i > startPos && i < endPos)
        {
          child.SetCity(i, parent1.GetCity(i));
        } // If our start position is larger
        else if (startPos > endPos)
        {
          if (!(i < startPos && i > endPos))
          {
            child.SetCity(i, parent1.GetCity(i));
          }
        }
      }

      // Loop through parent2's city tour
      for (var i = 0; i < parent2.TourSize(); i++)
      {
        // If child doesn't have the city add it
        if (!child.ContainsCity(parent2.GetCity(i)))
        {
          // Loop to find a spare position in the child's tour
          for (var ii = 0; ii < child.TourSize(); ii++)
          {
            // Spare position found, add city
            if (child.GetCity(ii) == null)
            {
              child.SetCity(ii, parent2.GetCity(i));
              break;
            }
          }
        }
      }
      return child;
    }

    // Mutate a tour using swap mutation
    private void Mutate(Tour tour)
    {
      // Loop through tour cities
      for (var tourPos1 = 0; tourPos1 < tour.TourSize(); tourPos1++)
      {
        // Apply mutation rate
        if (this.random.NextDouble() < this.mutationRate)
        {
          // Get a second random position in the tour
          var tourPos2 = (int)(this.random.NextDouble() * tour.TourSize());

          // Get the cities at target position in tour
          var city1 = tour.GetCity(tourPos1);
          var city2 = tour.GetCity(tourPos2);

          // Swap them around
          tour.SetCity(tourPos2, city1);
          tour.SetCity(tourPos1, city2);
        }
      }
    }

    // Selects candidate tour for crossover
    private Tour TournamentSelection(Population pop)
    {
      // Create a tournament population
      var tournament = new Population(this.tournamentSize, false);
      // For each place in the tournament get a random candidate tour and
      // add it
      for (var i = 0; i < this.tournamentSize; i++)
      {
        var randomId = (int)(this.random.NextDouble() * pop.PopulationSize());
        tournament.SaveTour(i, pop.GetTour(randomId));
      }
      // Get the fittest tour
      var fittest = tournament.GetFittest();
      return fittest;
    }
  }
}
