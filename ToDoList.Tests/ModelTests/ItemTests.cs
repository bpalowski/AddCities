using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoList.Models;
using MySql.Data.MySqlClient;

namespace ToDoList.Tests
{

    [TestClass]
    public class ItemTests : IDisposable
     {
        public void Dispose()
        {
            City.DeleteAll();
        }
        public ItemTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
        }
//test list
        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
          //Arrange
          //Act

          int result = City.GetAll().Count;

          //Assert
          Assert.AreEqual(0, result);
        }
// test objects
        // [TestMethod]
        // public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
        // {
        //   // Arrange, Act
        //   City firstItem = new City(11);
        //   City secondItem = new City(11);
        //
        //   // Assert
        //   Assert.AreEqual(firstItem, secondItem);
        // }
        //test save()
        // [TestMethod]
        // public void Save_AssignsIdToObject_Id()
        // {
        //   //Arrange
        //   City testCity = new City(111);
        //
        //   //Act
        //   testCity.Save();
        //   City savedCity = City.GetAll()[0];
        //
        //   int result = savedCity.GetId();
        //   int testId = testCity.GetId();
        //
        //   //Assert
        //   Assert.AreEqual(testId, result);
        // }


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
