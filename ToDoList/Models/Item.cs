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

    public City(string Name, string Code, string District, int Population, int Id = 0)
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
      cmd.CommandText = @"INSERT INTO city (Name, CountryCode, District, Population) VALUES (@City, @CountryCode, @District, @Population);";

      //  @"INSERT INTO city (`Name`) VALUES (@CityName);";

      MySqlParameter city = new MySqlParameter("@City", _name);
      MySqlParameter code = new MySqlParameter("@CountryCode", _code);
      MySqlParameter district = new MySqlParameter("@District", _district);
      MySqlParameter pop = new MySqlParameter("@Population", _population);
      cmd.Parameters.Add(city);
      cmd.Parameters.Add(code);
      cmd.Parameters.Add(district);
      cmd.Parameters.Add(pop);
      cmd.ExecuteNonQuery();    // This line is new!
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    //test object
    public override bool Equals(System.Object otherCity)
    {
      if (!(otherCity is City))
      {
        return false;
      }
      else
      {
        City newCity = (City) otherCity;
        bool idCity = (this.GetId() == newCity.GetId());
        bool descriptionEquality = (this.GetName() == newCity.GetName());
        return (idCity && descriptionEquality);
      }
    }

    //list all cities
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
        City newCity = new City(cityName, cityCode, cityDistrict, cityPopulation, cityId);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
    //search by city
    public static List<City> SearchByCity(string newcity)
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = cmd.CommandText = @"SELECT * FROM city" + " WHERE name LIKE \'" + newcity + "%\'" + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCode = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityCode, cityDistrict, cityPopulation, cityId);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
    //order by population

    public static List<City> OrderByPopulation()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city ORDER BY population" + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCode = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityCode, cityDistrict, cityPopulation, cityId);

        allCities.Add(newCity);
        

      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    //delete all
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
