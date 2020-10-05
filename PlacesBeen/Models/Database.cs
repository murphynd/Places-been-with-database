using System;
using MySql.Data.MySqlClient;
using PlacesBeen;

namespace PlacesBeen.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}