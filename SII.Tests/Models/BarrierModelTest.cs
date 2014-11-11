using System;
using NUnit.Framework;
using System.Linq;
using System.Text;
using SII.Models;

namespace SII.Tests.Models
{
    [TestFixture]
    public class BarrierModelTest
    {
        [Test]
        public void EnteringLessThanOr16CharacteresInName()
        {
            var Barrier = new Barrier { Name = "testing 01" };
            Assert.IsTrue(Barrier.Name.Length <= 16);
            Assert.IsTrue(Barrier.Name.Length >= 3);
        }

        [Test]
        public void EnteringJustNumersCharacteresInName()
        {
            var announcement = new Announcement { Observations = "testing 01" };
            Assert.IsTrue(JustCharacteresAndNumbers(announcement.Observations));
        }

        [Test]
        public void EnteringLessThanOr28CharacteresInDescription()
        {
            var Barrier = new Barrier { Description = "testing aaaaaaaaaaaaaaaaaaa" };
            Assert.IsTrue(Barrier.Description.Length <= 28);
            Assert.IsTrue(Barrier.Description.Length >= 5);
        }

        [Test]
        public void EnteringJustNumersCharacteresInDescription()
        {
            var barrier = new Barrier { Description = "testing 01" };
            Assert.IsTrue(JustCharacteresAndNumbers(barrier.Description));
        }


        
        public bool JustCharacteresAndNumbers(String sr)
        {
            if (String.IsNullOrEmpty(sr))
                return false;
            for (int i = 0; i < sr.Length; i++)
            {
                if ( sr[i].Equals('*') || sr[i].Equals('-') || sr[i].Equals('+') || sr[i].Equals('/') || sr[i].Equals('.')
                  || sr[i].Equals('?') || sr[i].Equals('|') || sr[i].Equals('>') || sr[i].Equals('<') || sr[i].Equals(',') || sr[i].Equals(':')
                  || sr[i].Equals(';') || sr[i].Equals('!') || sr[i].Equals('@') || sr[i].Equals('#') || sr[i].Equals('$') || sr[i].Equals('%')
                  || sr[i].Equals('^') || sr[i].Equals('&') || sr[i].Equals('(') || sr[i].Equals(')') || sr[i].Equals('_') || sr[i].Equals('='))
                    return false;
            }
            return true;
        }
    }
}
