using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
namespace ToDoList.Models
{
  public class City
  {
    private int _id;
    private string _name;
    private string _code;
    private string _district;
    private int _population;
    public string _userInput;
//    private static List<City> _instances = new List<City> {};
    public City(int Id = 0, string Name="", string Code = "", string District="", int Population=0) //string userInput = ""
    {
      _id = Id;
      _name = Name;
      _code = Code;
      _district = District;
      _population = Population;
    //  _userInput = userInput;
    }

    // public void SetUserInput(string newInput)
    // {
    //   _userInput = newInput;
    // }
    //
    // public string GetUserInput()
    // {
    //   return _userInput;
    // }


    public string GetName()
    {
      return _name;
    }
    public string GetCode()
    {
      return _code;
    }
    public string GetDistrict()
    {
      return _district;
    }
    public int GetPopulation()
    {
      return _population;
    }
    // public void (string newDescription)
    // {
    //   _description = newDescription;
    // }
    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO `City` (`name`) VALUES (@CityName);";

        // more logic will go here in a moment


         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
    }

    public override bool Equals(System.Object otherCity)
    {
      if (!(otherCity is City))
      {
        return false;
      }
      else
      {
        City newCity = (City) otherCity;
        bool descriptionEquality = (this.GetName() == newCity.GetName());
        return (descriptionEquality);
      }
    }


    public static List<City> GetAll()
  {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city" + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCode = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityId, cityName, cityCode, cityDistrict, cityPopulation);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allCities;
  }
     // public static List<City> SearchByCity(string newcity)
     // {
     //     List<City> allCities = new List<City> {};
     //     MySqlConnection conn = DB.Connection();
     //     conn.Open();
     //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     //     cmd.CommandText = cmd.CommandText = @"SELECT * FROM city" + " WHERE name LIKE \'" + newcity + "%\'" + ";";
     //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
     //     while(rdr.Read())
     //     {
     //       int cityId = rdr.GetInt32(0);
     //       string cityName = rdr.GetString(1);
     //       string cityCode = rdr.GetString(2);
     //       string cityDistrict = rdr.GetString(3);
     //       int cityPopulation = rdr.GetInt32(4);
     //       City newCity = new City(cityId, cityName, cityCode, cityDistrict, cityPopulation);
     //       allCities.Add(newCity);
     //     }
     //     conn.Close();
     //     if (conn != null)
     //     {
     //         conn.Dispose();
     //     }
     //     return allCities;
     // }


  public static void DeleteAll()
  {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM city;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
 }
}
}
