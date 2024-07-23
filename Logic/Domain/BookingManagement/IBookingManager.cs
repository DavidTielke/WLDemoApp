using DavidTielke.DemoApp.CrossCutting.DataClasses;

namespace DavidTielke.DemoApp.Logic.Domain.BookingManagement;

public interface IBookingManager
{
    void Add(Booking booking);
    IQueryable<Booking> GetAll();
}