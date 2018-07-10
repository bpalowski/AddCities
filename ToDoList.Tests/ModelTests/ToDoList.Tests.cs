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
public void GetAll_DbStartsEmpty_0()
{
  //Arrange
  //Act

  int result = City.GetAll().Count;

  //Assert
  Assert.AreEqual(0, result);
}
[TestMethod]
public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
{
  // Arrange, Act
  City firstItem = new City(11);
  City secondItem = new City(11);

  // Assert
  Assert.AreEqual(firstItem, secondItem);
}

[TestMethod]
public void Save_SavesToDatabase_ItemList()
{
  //Arrange
  City testCity = new City(1);

  //Act
  testCity.Save();
  List<City> result = City.GetAll();
  List<City> testList = new List<City>{testCity};

  //Assert
  CollectionAssert.AreEqual(testList, result);
}


}
}
