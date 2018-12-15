using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialiesControllerTest
    {
        [TestMethod]
        public void New_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            SpecialitiesController controller = new SpecialitiesController();

            //Act
            IActionResult view = controller.New();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Show_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            SpecialitiesController controller = new SpecialitiesController();

            //Act
            IActionResult view = controller.Show(1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        [TestMethod]
        public void Index_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            SpecialitiesController controller = new SpecialitiesController();

            //Act
            IActionResult view = controller.Index();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        public void SecondIndex_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            SpecialitiesController controller = new SpecialitiesController();

            //Act
            IActionResult view = controller.Index("Kaveh");

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
                [TestMethod]
        public void SecondShow_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            SpecialitiesController controller = new SpecialitiesController();

            //Act
            IActionResult view = controller.Show("Kaveh",1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
        public void Edit_ReturnsCorrectActionType_ViewResult()
        {
            //Arrange
            SpecialitiesController controller = new SpecialitiesController();

            //Act
            IActionResult view = controller.Edit(1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }
    }
}
