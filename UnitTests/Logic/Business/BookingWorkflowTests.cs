using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.DemoApp.CrossCutting.DataClasses;
using DavidTielke.DemoApp.Logic.Business.BookingWorkflows;
using DavidTielke.DemoApp.Logic.Domain.BookingManagement;
using DavidTielke.DemoApp.Logic.Domain.EmailManagement;
using Moq;

namespace UnitTests.Logic.Business
{
    [TestFixture]
    public class BookingWorkflowTests
    {
        [Test]
        public void Test1()
        {
            // Arrange
            var bookingManagerMock = new Mock<IBookingManager>();
            var mailSenderMock = new Mock<IMailSender>();
            var workflow = new BookingWorkflow(bookingManagerMock.Object, mailSenderMock.Object);

            // Act
            workflow.MarkAsPayed(new Booking(){Id = 4711});

            // Assert
            bookingManagerMock.Verify(m => m.Add(It.IsAny<Booking>()), Times.Exactly(1));
            mailSenderMock.Verify(m => m.Send(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
