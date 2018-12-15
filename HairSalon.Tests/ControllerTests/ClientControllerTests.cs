using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientsControllerTest
    {
        [TestMethod]
        public void New_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            ClientsController controller = new ClientsController();

            //Act
            IActionResult view = controller.New(1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Show_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            ClientsController controller = new ClientsController();

            //Act
            IActionResult view = controller.Show(1,1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Edit_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            ClientsController controller = new ClientsController();

            //Act
            IActionResult view = controller.Edit(1,1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Index_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            ClientsController controller = new ClientsController();

            //Act
            IActionResult view = controller.Index(1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Update_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            ClientsController controller = new ClientsController();

            //Act
            IActionResult view = controller.Update(1,1,"Kaveh","2062060206");

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        public void DeleteAll_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            ClientsController controller = new ClientsController();

            //Act
            IActionResult view = controller.DeleteAll();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
    }
}
