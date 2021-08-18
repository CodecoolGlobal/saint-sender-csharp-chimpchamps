using NUnit.Framework;
using SaintSender.Core.Models;

namespace SaintSender.Core.Tests
{
    [TestFixture]
    public class EmailConnectionTests
    {
        [Test]
        public void SetUp_UserNamePasswordAdded_ReturnTrue()
        {
            // Arrange
            var connection = new EmailConnection();
            // Act
            var connected = connection.SetUp("charly.lombardy@gmail.com", "bkhscuykgdupwiuh")
            // Assert
            Assert.AreEqual(true, connected);
        }
    }
}
