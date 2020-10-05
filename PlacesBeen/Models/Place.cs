using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace PlacesBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Id { get; }
    // public static List<Place> _instances = new List<Place> { };
    // public string Description { get; set; }
    // public int Id { get; }
    public Place(string cityName, string description, string image) //Main constructor for when form is submitted
    {
      CityName = cityName;
      Description = description;
      Image = image;

    }

    public Place(string cityName, string description, string image, int id) //Overloaded constructor which accepts id as well
    {
      CityName = cityName;
      Description = description;
      Image = image;
      Id = id;
    }

    public static List<Place> GetAll()
    {
      List<Place> allPlaces = new List<Place> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM places;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int placeId = rdr.GetInt32(0);
        string placeCityName = rdr.GetString(1);
        string placeDescription = rdr.GetString(2);
        string placeImage = rdr.GetString(3);
        Place newPlace = new Place(placeCityName, placeDescription, placeImage, placeId);
        allPlaces.Add(newPlace);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allPlaces;
    }
    public static void ClearAll()
    {

    }
    public static Place Find(int searchId)
    {
      // Temporarily returning placeholder place to get beyond compiler errors until we refactor to work with database.
      Place placeholderPlace = new Place("placeholder place", "test descrip", "test image");
      return placeholderPlace;
    }
  }
}