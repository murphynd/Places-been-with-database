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
    public int Id { get; set; }
    // public static List<Place> _instances = new List<Place> { };
    // public string Description { get; set; }
    // public int Id { get; }
    public Place(string cityName, string description, string image) //Main constructor for when form is submitted
    {
      CityName = cityName;
      Description = description;
      Image = image;

    }

    public Place(string cityName, string description, string image, int id) //Overloaded constructor which accepts id as well. To be used when retrieved from database.
    {
      CityName = cityName;
      Description = description;
      Image = image;
      Id = id;
    }
    public override bool Equals(System.Object otherPlace)
    {
      if (!(otherPlace is Place))
      {
        return false;
      }
      else
      {
        Place newPlace = (Place)otherPlace;
        bool idEquality = (this.Id == newPlace.Id);
        bool cityNameEquality = (this.CityName == newPlace.CityName);
        bool descriptionEquality = (this.Description == newPlace.Description);
        bool imageEquality = (this.Image == newPlace.Image);
        return (cityNameEquality && descriptionEquality && imageEquality);
      }
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
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM places;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static Place Find(int id)
    {
      // We open a connection.
      MySqlConnection conn = DB.Connection();
      conn.Open();

      // We create MySqlCommand object and add a query to its CommandText property. We always need to do this to make a SQL query.
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `places` WHERE idplaces = @thisId;";

      // We have to use parameter placeholders (@thisId) and a `MySqlParameter` object to prevent SQL injection attacks. This is only necessary when we are passing parameters into a query. We also did this with our Save() method.
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      // We use the ExecuteReader() method because our query will be returning results and we need this method to read these results. This is in contrast to the ExecuteNonQuery() method, which we use for SQL commands that don't return results like our Save() method.
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int placeId = 0;
      string placeCityName = "";
      string placeDescription = "";
      string placeImage = "";
      while (rdr.Read())
      {
        placeId = rdr.GetInt32(0);
        placeCityName = rdr.GetString(1);
        placeDescription = rdr.GetString(2);
        placeImage = rdr.GetString(3);

      }
      Place foundPlace = new Place(placeCityName, placeDescription, placeImage, placeId);


      // We close the connection.
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundPlace;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO places (CityName, Description, Image) VALUES (@PlaceCityName, @PlaceDescription, @PlaceImage);";
      MySqlParameter cityName = new MySqlParameter();
      MySqlParameter description = new MySqlParameter();
      MySqlParameter image = new MySqlParameter();
      cityName.ParameterName = "@PlaceCityName";
      description.ParameterName = "@PlaceDescription";
      image.ParameterName = "@PlaceImage";
      cityName.Value = this.CityName;
      description.Value = this.Description;
      image.Value = this.Image;
      cmd.Parameters.Add(cityName);
      cmd.Parameters.Add(description);
      cmd.Parameters.Add(image);
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}