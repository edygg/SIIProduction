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
       
        [Test]
        public void UpdateAtSelectedCorrectlyWhenModifiedCampus()
        {
            var campus = new Campus { UpdatedAt = new DateTime (2013, 1, 1) };
            Assert.AreEqual(new DateTime ( 2013, 1, 1) , campus.UpdatedAt);
        }

        [Test]
        public void EnteringLessThanOr6CharacteresInCodeIsNotAllow()
        {
            Campus campus = new Campus {Id = 1, Name="Unitec Tegucigalpa",  Code = "UNITUG"};
          
           Assert.IsTrue(campus.Code.Length == 6);           
        }

        [Test]
        public void EnteringLessThanOr50CharacteresInCodeIsNotAllow()
        {
            Campus campus = new Campus { Id = 1, Name = "Unitec Tegucigalpa", Code = "UNITUG" };

            Assert.IsTrue(campus.Name.Length <= 50);
        }
            
         [Test]
         public void EnteringJustUpperCaseCharacteresInCode()
         {
            Campus campus = new Campus {Id = 1, Name="Unitec Tegucigalpa",  Code = "UNITUG"};
            Assert.IsTrue( hasLowerCase(campus.Code));
         }

        [Test]
         public void EnteringJustCharacteresInCode()
         {
             Campus campus = new Campus { Id = 1, Name = "Unitec Tegucigalpa", Code = "UNITUG" };
             Assert.IsTrue( JustCharacteres(campus.Code));
         }

        [Test]
        public void EnteringJustCharacteresInName()
        {
            Campus campus = new Campus { Id = 1, Name = "Unitec Tegucigalpa", Code = "UNITUG" };
            Assert.IsTrue(JustCharacteres(campus.Name));
        }


         public bool JustCharacteres(String sr)
         {
             if (String.IsNullOrEmpty(sr))
                 return false;
             for (int i = 0; i < sr.Length; i++)
             {
                 if (char.IsNumber(sr[i]) || sr[i].Equals('*') || sr[i].Equals('-') || sr[i].Equals('+') || sr[i].Equals('/') || sr[i].Equals('.')
                    || sr[i].Equals('?') || sr[i].Equals('|') || sr[i].Equals('>') || sr[i].Equals('<') || sr[i].Equals(',') || sr[i].Equals(':') 
                    || sr[i].Equals(';') || sr[i].Equals('!') || sr[i].Equals('@') || sr[i].Equals('#') || sr[i].Equals('$') || sr[i].Equals('%')
                    || sr[i].Equals('^') || sr[i].Equals('&') || sr[i].Equals('(') || sr[i].Equals(')') || sr[i].Equals('_') || sr[i].Equals('=') )
                     return false;
             }
             return true;
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
