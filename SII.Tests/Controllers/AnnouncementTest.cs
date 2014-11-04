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
    public class AnnouncementTest
    {
        [Test]
        public void Announcement_Index_View_Contains_ListOfAnnouncement_Model()
        {
            //Arrange
            Mock<IAnnouncementRepository> mock = new Mock<IAnnouncementRepository>();

            mock.Setup(b => b.Announcements).Returns(new Announcement[]
            {
                new Announcement {Id = 0, Observations="Testing" },
                new Announcement {Id = 1, Observations="Testing2"},
                new Announcement {Id = 2, Observations="Testing3"}
            }.AsQueryable());

            AnnouncementController controller = new AnnouncementController(mock.Object);

            //Act
            var result = (List<Announcement>)controller.Index().Model;


            //Assert
            Assert.IsInstanceOf<List<Announcement>>(result);

        }

        [Test]
        public void Announcement_Create_Record()
        {
            //Arrange
            Announcement announcement = new Announcement { Id = 0, Observations = "Testing" };
            Mock<IAnnouncementRepository> mock = new Mock<IAnnouncementRepository>();
            mock.Setup(mu => mu.save(announcement)).Returns(announcement);
            AnnouncementController controller = new AnnouncementController(mock.Object);


            //Act
            var result = controller.Create(announcement) as RedirectToRouteResult;


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Announcement_Delete_Record()
        {
            //Arrange          
            Mock<IAnnouncementRepository> mock = new Mock<IAnnouncementRepository>();
            mock.Setup(mu => mu.delete(1));
            AnnouncementController controller = new AnnouncementController(mock.Object);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Announcement_DeleteConfirmed_Record()
        {
            //Arrange          
            Mock<IAnnouncementRepository> mock = new Mock<IAnnouncementRepository>();
            mock.Setup(mu => mu.delete(1));
            AnnouncementController controller = new AnnouncementController(mock.Object);

            //Act
            var result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Announcement_Edit_Record()
        {
            //Arrange
            Announcement announcement = new Announcement { Id = 0, Observations = "Testing" };
            Mock<IAnnouncementRepository> mock = new Mock<IAnnouncementRepository>();
            mock.Setup(mu => mu.save(announcement)).Returns(announcement);
            AnnouncementController controller = new AnnouncementController(mock.Object);

            //Act
            var result = controller.Edit(announcement) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }
    }
}
