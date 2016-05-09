namespace TravellingSalesman
{
  using System;

  public class City
  {
    // City's x coordinate
    public int X { get; set; }

    // City's y coordinate
    public int Y { get; set; }

    // Constructs a randomly placed city
    public City()
    {
      var r = new Random();
      this.X = r.Next(0, 200);
      this.Y = r.Next(0, 200);
    }

    // Constructs a city at chosen x, y location
    public City(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    // Gets the distance to given city
    public double DistanceTo(City city)
    {
      var xDistance = Math.Abs(this.X - city.X);
      var yDistance = Math.Abs(this.Y - city.Y);
      var distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);

      return distance;
    }

    public override string ToString()
    {
      return this.X + ", " + this.Y;
    }
  }
}
