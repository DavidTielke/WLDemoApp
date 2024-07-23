using System.Diagnostics;
using DavidTielke.DemoApp.CrossCutting.DataClasses;
using DavidTielke.DemoApp.Logic.Business.BookingWorkflows;
using DavidTielke.DemoApp.Logic.Domain.BookingManagement;
using DavidTielke.DemoApp.Logic.Domain.ContactManagement;
using DavidTielke.DemoApp.UI.MvcClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace DavidTielke.DemoApp.UI.MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookingManager _bookingManager;
        private readonly IContactManager _contactManager;
        private readonly IBookingWorkflow _workflow;


        public HomeController(ILogger<HomeController> logger, 
            IBookingManager bookingManager, 
            IContactManager contactManager, 
            IBookingWorkflow workflow)
        {
            _logger = logger;
            _bookingManager = bookingManager;
            _contactManager = contactManager;
            _workflow = workflow;
        }

        public IActionResult Index()
        {
            var bookings = _bookingManager.GetAll();
            var contactIds = bookings.Select(b => b.ContactId).ToArray();
            var contacts = _contactManager
                .GetByIds(contactIds)
                .ToDictionary(c => c.Id, c => c);

            var viewModel = new HomeIndexViewModel
            {
                Bookings = bookings,
                Contacts = contacts
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(Booking booking)
        {
            _workflow.MarkAsPayed(booking);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
