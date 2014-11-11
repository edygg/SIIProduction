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

        
    }
}
