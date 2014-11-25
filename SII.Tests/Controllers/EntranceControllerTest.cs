using System;
using System.Linq;
using System.Text;
using SII.Controllers;
using System.Web.Mvc;
using NUnit.Framework;
using Moq;
using SII.Models;
using System.Collections.Generic;

namespace SII.Tests.Controllers
{
    [TestFixture]
    public class EntranceControllerTest
    {
        

        [Test]
        public void Entrance_Create_Record()
        {
            //Arrange
            Entrance entrance = new Entrance { Id = 0, State= "testing" };
            Mock<IEntranceRepository> mock = new Mock<IEntranceRepository>();
            mock.Setup(mu => mu.save(entrance)).Returns(entrance);
            EntranceController controller = new EntranceController(mock.Object);


            //Act
            var result = controller.Create(entrance) as RedirectToRouteResult;


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Entrance_Delete_Record()
        {
            //Arrange          
            Mock<IEntranceRepository> mock = new Mock<IEntranceRepository>();
            mock.Setup(mu => mu.delete(1));
            EntranceController controller = new EntranceController(mock.Object);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Entrance_DeleteConfirmed_Record()
        {
            //Arrange          
            Mock<IEntranceRepository> mock = new Mock<IEntranceRepository>();
            mock.Setup(mu => mu.delete(1));
            EntranceController controller = new EntranceController(mock.Object);

            //Act
            var result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Entrance_Edit_Record()
        {
            //Arrange
            Entrance entrance = new Entrance { Id = 0, State = "testing" };
            Mock<IEntranceRepository> mock = new Mock<IEntranceRepository>();
            mock.Setup(mu => mu.save(entrance)).Returns(entrance);
            EntranceController controller = new EntranceController(mock.Object);


            //Act
            var result = controller.Create(entrance) as RedirectToRouteResult;


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }
    }
}
