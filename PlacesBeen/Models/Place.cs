using System;
using System.Collections.Generic;

namespace PlacesBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }
    public static List<Place> _instances = new List<Place> { };
    // public string Description { get; set; }
    // public int Id { get; }
    public Place(string cityName)
    {
      CityName = cityName;
      _instances.Add(this);
    }
    public static List<Place> GetAll()
    {
      List<Place> some = new List<Place>();
      return some;
    }
  }
}