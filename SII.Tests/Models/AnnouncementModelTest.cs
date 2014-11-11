using System;
using NUnit.Framework;
using System.Linq;
using System.Text;
using SII.Models;

namespace SII.Tests.Models
{
    [TestFixture]
    public class AnnouncementModelTest
    {
        [Test]
        public void UpdateAtSelectedCorrectlyWhenModifiedAnnouncement()
        {
            var announcement = new Announcement { UpdatedAt = new DateTime(2013, 1, 1) };
            Assert.AreEqual(new DateTime(2013, 1, 1), announcement.UpdatedAt);
        }

        [Test]
        public void EnteringJust16CharacteresInObservations()
        {
            var announcement = new Announcement { Observations = "testing 01"};
            Assert.IsTrue(announcement.Observations.Length <= 16 );
        }

        [Test]
        public void EnteringJustNumersCharacteresInObservations()
        {
            var announcement = new Announcement { Observations = "testing 01" };
            Assert.IsTrue(JustCharacteresAndNumbers(announcement.Observations));
        }

        public bool JustCharacteresAndNumbers(String sr)
        {
            if (String.IsNullOrEmpty(sr))
                return false;
            for (int i = 0; i < sr.Length; i++)
            {
                if (sr[i].Equals('*') || sr[i].Equals('-') || sr[i].Equals('+') || sr[i].Equals('/') 
                   || sr[i].Equals('|') || sr[i].Equals('>') || sr[i].Equals('<') || sr[i].Equals(':')
                   | sr[i].Equals('@') || sr[i].Equals('#') || sr[i].Equals('$') || sr[i].Equals('%')
                   || sr[i].Equals('^') || sr[i].Equals('&') || sr[i].Equals('(') || sr[i].Equals(')') || sr[i].Equals('_') || sr[i].Equals('='))
                    return false;
            }
            return true;
        }

        
    }
}
