using DavidTielke.DemoApp.CrossCutting.DataClasses;

namespace DavidTielke.DemoApp.UI.MvcClient.Models
{
    public class HomeIndexViewModel
    {
        public IQueryable<Booking> Bookings { get; set; }
        public Dictionary<int, Contact> Contacts { get; set; }
    }
}
