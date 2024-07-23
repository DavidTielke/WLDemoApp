using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.DemoApp.CrossCutting.DataClasses;
using DavidTielke.DemoApp.Logic.Domain.BookingManagement;
using DavidTielke.DemoApp.Logic.Domain.EmailManagement;

namespace DavidTielke.DemoApp.Logic.Business.BookingWorkflows
{
    public class BookingWorkflow : IBookingWorkflow
    {
        private readonly IBookingManager _bookingManager;
        private readonly IMailSender _mailSender;

        public BookingWorkflow(IBookingManager bookingManager, 
            IMailSender mailSender)
        {
            _bookingManager = bookingManager;
            _mailSender = mailSender;
        }

        public void MarkAsPayed(Booking booking)
        {
            _bookingManager.Add(booking);
            _mailSender.Send($"Buchung {booking.Id} durchgeführt!");
        }
    }
}
