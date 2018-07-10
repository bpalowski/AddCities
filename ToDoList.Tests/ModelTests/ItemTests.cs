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
        //
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

    }

}
