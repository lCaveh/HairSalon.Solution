using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsControllerTest
    {
        [TestMethod]
        public void New_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult view = controller.New();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Show_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult view = controller.Show(1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Index_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult view = controller.Index();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Delete_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult view = controller.Delete(1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        public void SecondDelete_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult view = controller.Delete(1,1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void SecondShow_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult view = controller.Show("Kaveh",1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Edit_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult view = controller.Edit(1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void DeleteAll_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult view = controller.DeleteAll();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }      
    }
}
