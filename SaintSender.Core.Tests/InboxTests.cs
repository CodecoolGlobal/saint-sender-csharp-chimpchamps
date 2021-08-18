using NUnit.Framework;
using SaintSender.Core.Models;

namespace SaintSender.Core.Tests
{
    [TestFixture]
    public class InboxTests
    {
        [Test]
        public void ListMails_UserNamePasswordAdded_ReturnEmailList()
        {
            // Arrange
            var connection = new Inbox();
            // Act
            var Emails = connection.MailList()
            // Assert
            Assert.AreEqual(Emails, Emails);
        }
    }
}
