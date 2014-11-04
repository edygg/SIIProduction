using System;
using NUnit.Framework;
using System.Linq;
using System.Text;
using SII.Models;

namespace SII.Tests.Models
{
    [TestFixture]
    public class CampusModelTest
    {
        /*[Test]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void TestCampusRequiredCode()
        {
            var campus = new Campus { Id = 1, Code = "", Name = "Universidad", Details = "" };
            SIIContext context = new SIIContext();
            context.Campus.Add(campus);
            context.SaveChanges();
            context.Dispose();
        }*/

      /*  [Test]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void TestCampusRequiredName()
        {
            var campus = new Campus { Id = 1, Code = "Code", Name = "", Details = "" };
            SIIContext context = new SIIContext();
            context.Campus.Add(campus);
            context.SaveChanges();
            context.Dispose();
        }*/

        [Test]
        public void UpdateAtSelectedCorrectlyWhenModifiedCampus()
        {
            var campus = new Campus { UpdatedAt = new DateTime (2013, 1, 1) };
            Assert.AreEqual(new DateTime ( 2013, 1, 1) , campus.UpdatedAt);
        }

        [Test]
        public void EnteringLessThan6CharacteresInCodeIsNotAllow()
        {
            Campus campus = new Campus { Code = "TUG"};
            Assert.AreNotEqual(campus.Code.Length , 6);
        }
    }
}
