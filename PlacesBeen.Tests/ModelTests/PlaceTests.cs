using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacesBeen.Models;
using System.Collections.Generic;
using System;

namespace PlacesBeen.Tests
{
  [TestClass]
  public class PlaceTests : IDisposable
  {
    public void Dispose()
    {
      Place.ClearAll();
    }

    [TestMethod]
    public void Place_InstantiateAnInstanceOfPlace_Place()
    {
      Place newPlace = new Place("test");
      Assert.AreEqual(typeof(Place), newPlace.GetType());
    }
    [TestMethod]
    public void Place_InstantiateAnInstanceOfPlace_newPlace()
    {
      //Arrange
      string cityName = "Amsterdam";
      //Act
      Place newPLace = new Place(cityName);
      string result = newPLace.CityName;
      // Assert
      Assert.AreEqual("Amsterdam", result);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyList_PlaceList()
    {
      // Arrange
      List<Place> newList = new List<Place> { };

      // Act
      List<Place> result = Place.GetAll();
      

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetAll_ReturnsListOfItems_PlaceList()
    {
      // Arrange
      string cityName1 = "Amsterdam";
      string cityName2 = "Berlin";
      Place newPlace1 = new Place(cityName1);
      Place newPlace2 = new Place(cityName2);
      List<Place> newList3 = new List<Place> { newPlace1, newPlace2};

      // Act
      List<Place> result = Place.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList3, result);
    }


  }
}