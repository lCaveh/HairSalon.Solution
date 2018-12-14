using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialityTests : IDisposable
  {
    public SpecialityTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kaveh_saleminejad_test;";
    }

    public void Dispose()
    {
      Client.ClearAll();
      Speciality.ClearAll();
    }

    [TestMethod]
    public void Speciality_DBstartsEmpty_Empty()
    {
      int count = Speciality.GetAll().Count;

      Assert.AreEqual(0,count);
    }

    [TestMethod]
    public void Speciality_HasSameValues_True()
    {
      //Arrange
      Speciality specialityOne = new Speciality("Hair colorist");
      Speciality specialityTwo = new Speciality("Hair colorist");

      //Assert
      Assert.AreEqual(specialityOne, specialityTwo);
    }

    [TestMethod]
    public void Speciality_FindMatchingSpeciality_True()
    {
      //Arrange
      Speciality specialityOne = new Speciality("Hair colorist");
      specialityOne.Save();
      int id = specialityOne.GetId();

      //Act
      Speciality foundSpeciality = Speciality.Find(id);

      //Assert
      Assert.AreEqual(specialityOne, foundSpeciality);
    }

    [TestMethod]
    public void Speciality_SpecialityDeletedFromDB_True()
    {
      //Arrange
      Speciality specialityOne = new Speciality("Hair colorist");
      specialityOne.Save();
      int id = specialityOne.GetId();
      Speciality defaultSpeciality = new Speciality("", 0);

      //Act
      Speciality.DeleteSpeciality(id);
      Speciality notFound = Speciality.Find(id);

      //Assert
      Assert.AreEqual(notFound, defaultSpeciality);
    }
  }
}
