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
    public class DeparmentControllerTest
    {
       
        [Test]
        public void Index_deparmet_listOfDeparmentsModel()
        {
            Mock<IDeparmentRepository> mock = new Mock<IDeparmentRepository>();
            
            mock.Setup(b => b.Departments).Returns(new Department[]
            {
                new Department { Id = 0, Name = "Testing 1" },
                new Department { Id = 0, Name = "Testing 2" },
                new Department { Id = 0, Name = "Testing 3" },
            }.AsQueryable());

            DepartmentController controller = new DepartmentController(mock.Object);

            var result = (List<Department>)controller.Index().Model;

            Assert.IsInstanceOf<List<Department>>(result);           
        }
        [Test]
        public void Deparment_Create_Record() 
        {
            Department dep = new Department{Id = 1, Name ="Testing 1" };
            Mock<IDeparmentRepository> mock = new Mock<IDeparmentRepository>();
            mock.Setup(um => um.save(dep)).Returns(dep);

            DepartmentController controller = new DepartmentController(mock.Object);
           
            var result = controller.Create(dep) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void Deparment_Edit_Record()
        {
            Department depart = new Department { Id = 1, Name = "testing_edit" };
            Mock<IDeparmentRepository> mock = new Mock<IDeparmentRepository>();
            mock.Setup(n => n.save(depart)).Returns(depart);

            DepartmentController controller = new DepartmentController(mock.Object);

            var result = controller.Edit(depart) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }
    }
}
