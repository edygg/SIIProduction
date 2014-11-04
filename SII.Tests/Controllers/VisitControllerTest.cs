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
    public class VisitControllerTest
    {
        [Test]
        public void Visit_Index_View_Contains_ListOfVisit_Model()
        {
            //Arrange
            Mock<IVisitRepository> mock = new Mock<IVisitRepository>();

            mock.Setup(b => b.Visits).Returns(new Visit[]
            {
                new Visit {Id = 0, FullName="Henry Acosta" },
                new Visit {Id = 1, FullName="Pedro Matamoros"},
                new Visit {Id = 2, FullName="Cleoplodo pluma"}
            }.AsQueryable());

            VisitController controller = new VisitController(mock.Object);

            //Act
            var result = (List<Visit>)controller.Index().Model;


            //Assert
            Assert.IsInstanceOf<List<Visit>>(result);

        }

        [Test]
        public void Visit_Create_Record()
        {
            //Arrange
            Visit visit = new Visit { Id = 0, FullName = "Henry Acosta" };
            Mock<IVisitRepository> mock = new Mock<IVisitRepository>();
            mock.Setup(mu => mu.save(visit)).Returns(visit);
            VisitController controller = new VisitController(mock.Object);


            //Act
            var result = controller.Create(visit) as RedirectToRouteResult;


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Visit_Delete_Record()
        {
            //Arrange          
            Mock<IVisitRepository> mock = new Mock<IVisitRepository>();
            mock.Setup(mu => mu.delete(1));
            VisitController controller = new VisitController(mock.Object);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Visit_DeleteConfirmed_Record()
        {
            //Arrange          
            Mock<IVisitRepository> mock = new Mock<IVisitRepository>();
            mock.Setup(mu => mu.delete(1));
            VisitController controller = new VisitController(mock.Object);

            //Act
            var result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Visit_Edit_Record()
        {
            //Arrange
            Visit visit = new Visit { Id = 0, FullName = "Henry Acosta" };
            Mock<IVisitRepository> mock = new Mock<IVisitRepository>();
            mock.Setup(mu => mu.save(visit)).Returns(visit);
            VisitController controller = new VisitController(mock.Object);

            //Act
            var result = controller.Edit(visit) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }
    }
}
