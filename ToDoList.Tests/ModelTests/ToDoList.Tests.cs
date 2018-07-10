using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;
using MySql.Data.MySqlClient;

namespace ToDoList.Tests
{

[TestClass]
public class ModelTest
  {


[TestMethod]
public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
{
  // Arrange, Act
  City firstCity = new City("London", "USA", "England", 2000);
  firstCity.Save();

  City recoveredCity = City.GetAll()[0];


  // Assert
  Assert.AreEqual(firstCity, recoveredCity);
}
//
// [TestMethod]
// public void Save_SavesToDatabase_ItemList()
// {
//   //Arrange
//   City testCity = new City(1);
//
//   //Act
//   testCity.Save();
//   List<City> result = City.GetAll();
//   List<City> testList = new List<City>{testCity};
//
//   //Assert
//   CollectionAssert.AreEqual(testList, result);
// }


}
}
