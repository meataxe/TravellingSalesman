namespace TravellingSalesman
{
  using System;
  using System.Collections.Generic;

  public static class Helpers
  {
    private static readonly Random Random = new Random();

    public static void Shuffle<T>(this List<T> list)
    {
      var n = list.Count;
      for (var i = 0; i < n; i++)
      {
        // NextDouble returns a random number between 0 and 1.
        // ... It is equivalent to Math.random() in Java.
        var r = i + (int)(Random.NextDouble() * (n - i));
        var t = list[r];
        list[r] = list[i];
        list[i] = t;
      }
    }
  }
}
