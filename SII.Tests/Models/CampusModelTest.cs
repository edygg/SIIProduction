using System;
using NUnit.Framework;
using System.Linq;
using System.Text;
using SII.Models;
using Moq;
//using System.Web.Mvc;
//using System.Web.Http.ModelBinding;


namespace SII.Tests.Models 
{
    [TestFixture]
    public class CampusModelTest
    {
       
        [Test]
        public void UpdateAtSelectedCorrectlyWhenModifiedCampus()
        {
            var campus = new Campus { UpdatedAt = new DateTime (2013, 1, 1) };
            Assert.AreEqual(new DateTime ( 2013, 1, 1) , campus.UpdatedAt);
        }

        [Test]
        public void EnteringLessThan6CharacteresInCodeIsNotAllow()
        {
            Campus campus = new Campus {Id = 1, Name="Unitec Tegucigalpa",  Code = "UNITUG"};
          
           Assert.AreEqual(campus.Code.Length, 6);           
        }
            
         [Test]
         public void EnteringJustUpperCaseCharacteresInCode()
         {
            Campus campus = new Campus {Id = 1, Name="Unitec Tegucigalpa",  Code = "UNITUG"};
            Assert.IsTrue( hasLowerCase(campus.Code));
         }

        public bool hasLowerCase(String sr)
        {
            if (String.IsNullOrEmpty(sr))
                return false;
            for (int i = 0; i < sr.Length; i++)
            {
                if (char.IsLower(sr[i]))
                    return false;
            }
            return true;
        }
    }
}
