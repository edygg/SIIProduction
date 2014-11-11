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
    public class BarrierControllerTest
    {
        [Test]
        public void Barrier_Index_View_Contains_ListOfBarrier_Model()
        {
            //Arrange
            Mock<IBarrierRepository> mock = new Mock<IBarrierRepository>();

            mock.Setup(b => b.Barriers).Returns(new Barrier[]
            {
                new Barrier {Id = 0, Name="Testing name 1" },
                new Barrier {Id = 1, Name="Testing name 2" },
                new Barrier {Id = 0, Name="Testing name 1" }
            }.AsQueryable());

            BarrierController controller = new BarrierController(mock.Object);

            //Act
            var result = (List<Barrier>)controller.Index().Model;


            //Assert
            Assert.IsInstanceOf<List<Barrier>>(result);

        }

        [Test]
        public void Barriers_Create_Record()
        {
            //Arrange
            Barrier barrier = new Barrier { Id = 0, Name = "Testing name 1" };
            Mock<IBarrierRepository> mock = new Mock<IBarrierRepository>();
            mock.Setup(mu => mu.save(barrier)).Returns(barrier);
            BarrierController controller = new BarrierController(mock.Object);


            //Act
            var result = controller.Create(barrier) as RedirectToRouteResult;


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Barrier_Delete_Record()
        {
            //Arrange          
            Mock<IBarrierRepository> mock = new Mock<IBarrierRepository>();
            mock.Setup(mu => mu.delete(1));
            BarrierController controller = new BarrierController(mock.Object);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.IsNotNull(result);          
        }

        [Test]
        public void Barrier_DeleteConfirmed_Record()
        {
            //Arrange          
            Mock<IBarrierRepository> mock = new Mock<IBarrierRepository>();
            mock.Setup(mu => mu.delete(1));
            BarrierController controller = new BarrierController(mock.Object);

            //Act
            var result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Barrier_Edit_Record()
        {
            //Arrange
            Barrier barrier = new Barrier { Id = 0, Name = "Testing name 1" };
            Mock<IBarrierRepository> mock = new Mock<IBarrierRepository>();
            mock.Setup(mu => mu.save(barrier)).Returns(barrier);
            BarrierController controller = new BarrierController(mock.Object);

            //Act
            var result = controller.Edit(barrier) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }
    }
}
