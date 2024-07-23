using DavidTielke.DemoApp.CrossCutting.DataClasses;

namespace DavidTielke.DemoApp.Data.DataStorage;

public interface IBookingRepository
{
    void Insert(Booking booking);
    IQueryable<Booking> Query { get; }
}