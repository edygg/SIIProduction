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
    public class CarnetControllerTest
    {
        [Test]
        public void Carnet_Create_Record()
        {
            //Arrange
            Carnet carnet = new Carnet { Id = 0, Number = 1 };
            Mock<ICarnetRepository> mock = new Mock<ICarnetRepository>();
            mock.Setup(mu => mu.save(carnet)).Returns(carnet);
            CarnetController controller = new CarnetController(mock.Object);

            //Act
            var result = controller.Create(carnet) as RedirectToRouteResult;
            var result1 = controller.Create(carnet);


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
            
        }

        [Test]
        public void Carnet_Delete_Record()
        {
            //Arrange          
            Mock<ICarnetRepository> mock = new Mock<ICarnetRepository>();
            mock.Setup(mu => mu.delete(1));
            CarnetController controller = new CarnetController(mock.Object);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Carnet_DeleteConfirmed_Record()
        {
            //Arrange          
            Mock<ICarnetRepository> mock = new Mock<ICarnetRepository>();
            mock.Setup(mu => mu.delete(1));
            CarnetController controller = new CarnetController(mock.Object);

            //Act
            var result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Carnet_Edit_Record()
        {
            //Arrange
            Carnet carnet = new Carnet { Id = 0, Number = 1 };
            Mock<ICarnetRepository> mock = new Mock<ICarnetRepository>();
            mock.Setup(mu => mu.save(carnet)).Returns(carnet);
            CarnetController controller = new CarnetController(mock.Object);


            //Act
            var result = controller.Create(carnet) as RedirectToRouteResult;


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Carnet_Index_View_Contains_ListOfCarntes_Model()
        {
            //Arrange
            Mock<ICarnetRepository> mock = new Mock<ICarnetRepository>();

            mock.Setup(b => b.Carnets).Returns(new Carnet[]
            {
                new Carnet { Id = 0, Number = 1 },
                new Carnet { Id = 0, Number = 2 },
                new Carnet { Id = 0, Number = 3 },
            }.AsQueryable());

            CarnetController controller = new CarnetController(mock.Object);


            //Act
            var result = (List<Carnet>)controller.Index().Model;


            //Assert
            Assert.IsInstanceOf<List<Carnet>>(result);

        }
       
    }
}
