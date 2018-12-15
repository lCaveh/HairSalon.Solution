using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kaveh_saleminejad_test;";
    }

    public void Dispose()
    {
      Client.ClearAll();
      Stylist.ClearAll();
      Speciality.ClearAll();
    }

    [TestMethod]
    public void Stylist_DBstartsEmpty_Empty()
    {
      int count = Stylist.GetAll().Count;

      Assert.AreEqual(0,count);
    }

    [TestMethod]
    public void Stylist_HasSameValues_True()
    {
      //Arrange
      Stylist stylistOne = new Stylist("Kaveh");
      Stylist stylistTwo = new Stylist("Kaveh");

      //Assert
      Assert.AreEqual(stylistOne, stylistTwo);
    }

    [TestMethod]
    public void Stylist_FindMatchingStylist_True()
    {
      //Arrange
      Stylist stylistOne = new Stylist("Kaveh");
      stylistOne.Save();
      int id = stylistOne.GetId();

      //Act
      Stylist foundStylist = Stylist.Find(id);

      //Assert
      Assert.AreEqual(stylistOne, foundStylist);
    }

    [TestMethod]
    public void Stylist_StylistDeletedFromDB_True()
    {
      //Arrange
      Stylist stylistOne = new Stylist("Kaveh");
      stylistOne.Save();
      int id = stylistOne.GetId();
      Stylist defaultStylist = new Stylist("", 0);

      //Act
      Stylist.DeleteStylist(id);
      Stylist notFound = Stylist.Find(id);

      //Assert
      Assert.AreEqual(notFound, defaultStylist);
    }

    [TestMethod]
    public void AddSpeciality_SpecialityIsAddedToJoinTable_True()
    {
      //Arrange
      Speciality specialityOne = new Speciality("HairCutting");
      specialityOne.Save();
      Stylist stylistOne = new Stylist("Kaveh");
      stylistOne.Save();

      //Act
      stylistOne.AddSpeciality(specialityOne.GetId());
      List<Speciality> allSpecialitys = stylistOne.GetSpecialities();
      int count = allSpecialitys.Count;

      //Assert
      Assert.AreEqual(1, count);
    }
  
    [TestMethod]
    public void Stylist_EditedStylistHasDifferentValue_True()
    {
      //Arrange
      Stylist stylistOne = new Stylist ("Kaveh");
      Stylist stylistTwo = new Stylist ("Afshin");
      stylistOne.Save();
      int id = stylistOne.GetId();

      //Act
      stylistOne.Edit("Afshin");
      Stylist foundStylist = Stylist.Find(id);

      //Assert
      Assert.AreEqual(stylistTwo.GetName(), foundStylist.GetName());
    }
  }
}
