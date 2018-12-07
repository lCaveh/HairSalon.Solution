using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kaveh_saleminejad_test;";
    }

    public void Dispose()
    {
      Client.ClearAll();
      Stylist.ClearAll();
    }

    [TestMethod]
    public void Client_DBStartsEmpty_Empty()
    {
      //Arrange
      int count = Client.GetAll().Count;

      //Assert
      Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void Save_SavedClientHasSameValues_True()
    {
      //Arrange
      Client clientOne = new Client("Kaveh","2062060206", 1, 1);
      clientOne.Save();
      int id = clientOne.GetId();

      //Act
      Client savedClient = Client.Find(id);

      //Assert
      Assert.AreEqual(clientOne, savedClient);
    }

    [TestMethod]
    public void Edit_EditedItemHasDifferentValue_True()
    {
      //Arrange
      Client clientOne = new Client("Kaveh","2062060206", 1, 1);
      clientOne.Save();
      Client editClient = new Client("Afshin","2062060206", 1, 1);

      //Act
      clientOne.Edit("Afshin");

      //Assert
      Assert.AreEqual(clientOne, editClient);
    }

    [TestMethod]
    public void Delete_ClientIsDeletedFromDB_True()
    {
      //Arrange
      Client clientOne = new Client("Kaveh","2062060206", 1, 1);
      clientOne.Save();
      int id = clientOne.GetId();
      Client defaultValues = new Client ("","", 0);

      //Act
      Client.DeleteClients(id);
      Client notFound = Client.Find(id);

      //Assert
      Assert.AreEqual(notFound, defaultValues);
    }
  }
}
