using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacesBeen.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace PlacesBeen.Tests
{
  [TestClass]
  public class PlaceTests : IDisposable
  {
    public void Dispose()
    {
      Place.ClearAll();
    }
    public PlaceTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=places_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_PlaceList()
    {
      //Arrange
      List<Place> newList = new List<Place> { };

      //Act
      List<Place> result = Place.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_Place()
    {
      // Arrange, Act
      Place firstPlace = new Place("Portland", "Rip City", "https://www.gonext.com/wp-content/uploads/2019/10/Portland-Oregon_iS_994318522_web.jpg");
      Place secondPlace = new Place("Portland", "Rip City", "https://www.gonext.com/wp-content/uploads/2019/10/Portland-Oregon_iS_994318522_web.jpg");

      // Assert
      Assert.AreEqual(firstPlace, secondPlace);
    }
    [TestMethod]
    public void Save_SavesToDatabase_PlaceList()
    {
      //Arrange
      Place testPlace = new Place("Portland", "Rip City", "https://www.gonext.com/wp-content/uploads/2019/10/Portland-Oregon_iS_994318522_web.jpg");

      //Act
      testPlace.Save();
      List<Place> result = Place.GetAll();
      List<Place> testList = new List<Place> { testPlace };

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }


    // [TestMethod]
    // public void Place_InstantiateAnInstanceOfPlace_Place()
    // {
    //   Place newPlace = new Place("test");
    //   Assert.AreEqual(typeof(Place), newPlace.GetType());
    // }
    // [TestMethod]
    // public void Place_InstantiateAnInstanceOfPlace_newPlace()
    // {
    //   //Arrange
    //   string cityName = "Amsterdam";
    //   //Act
    //   Place newPLace = new Place(cityName);
    //   string result = newPLace.CityName;
    //   // Assert
    //   Assert.AreEqual("Amsterdam", result);
    // }
    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_PlaceList()
    // {
    //   // Arrange
    //   List<Place> newList = new List<Place> { };

    //   // Act
    //   List<Place> result = Place.GetAll();


    //   // Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }
    [TestMethod]
    public void GetAll_ReturnsListOfPlaces_PlaceList()
    {
      // Arrange
      string cityName1 = "Amsterdam";
      string cityName2 = "Berlin";
      Place newPlace1 = new Place(cityName1, "test", "test");
      newPlace1.Save();
      Place newPlace2 = new Place(cityName2, "test", "test");
      newPlace2.Save();
      List<Place> newList3 = new List<Place> { newPlace1, newPlace2 };

      // Act
      List<Place> result = Place.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList3, result);
    }

    [TestMethod]
    public void Find_FindItemsInList_Place()
    {
      // Arrange
      string cityName1 = "Amsterdam";
      string cityName2 = "Berlin";
      Place newPlace1 = new Place(cityName1, "test", "test");
      newPlace1.Save();
      Place newPlace2 = new Place(cityName2, "test", "test");
      newPlace2.Save();

      // Act
      Place result = Place.Find(2);

      // Assert
      Assert.AreEqual(newPlace2, result);
    }
  }
}