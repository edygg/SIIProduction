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
    public class CampusControllerTest
    {
      
        [Test]
        public void Campus_Index_View_Contains_ListOfCampus_Model()
        {
            //Arrange
            Mock<ICampusRepository> mock = new Mock<ICampusRepository>();
           
            mock.Setup(b => b.Campus).Returns(new Campus[]
            {
                new Campus {Id = 0, Name="Unitec test0", Code = "test0"},
                new Campus {Id = 1, Name="Unitec test1", Code = "test1"},
                new Campus {Id = 2, Name="Unitec test2", Code = "test2"}
            }.AsQueryable());

            CampusController controller = new CampusController(mock.Object);

            //Act
            var result = (List<Campus>)controller.Index().Model; 
          

            //Assert
            Assert.IsInstanceOf <List<Campus>> (result);

        }


        [Test]
        public void Campus_Index_View_Contains_3_Campuses()
        {
            //Arrange
            Mock<ICampusRepository> mock = new Mock<ICampusRepository>();

            mock.Setup(b => b.Campus).Returns(new Campus[]
            {
                new Campus {Id = 0, Name="Unitec test0", Code = "test0"},
                new Campus {Id = 1, Name="Unitec test1", Code = "test1"},
                new Campus {Id = 2, Name="Unitec test2", Code = "test2"}
            }.AsQueryable());

            CampusController controller = new CampusController(mock.Object);

            //Act
            var result = (List<Campus>)controller.Index().Model;


            //Assert
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void Delete_Invalid_Campus_Returns_Http_404()
        {  
            //Arrange
            Mock<ICampusRepository> mock = new Mock<ICampusRepository>();

            
            CampusController controller = new CampusController(mock.Object);
            //CampusCreate  

            //Act
            var result = controller.Delete(27) as HttpNotFoundResult;


            //Assert
            Assert.AreEqual(404, result.StatusCode);
        }
        [Test]
        public void Create_ViewState_is_Invalid_Returns_Correct_View()
        {
            //Arrange
            Mock<ICampusRepository> mock = new Mock<ICampusRepository>();


            CampusController controller = new CampusController(mock.Object);
            controller.ModelState.AddModelError("Code","Code is required");
            //CampusCreate  

            //Act
            var result = controller.Create(new Campus { Code ="TGU"} ) as ViewResult;


            //Assert
            Assert.AreEqual("", result.ViewName);
        }
    }
}
