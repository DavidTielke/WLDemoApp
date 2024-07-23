using DavidTielke.DemoApp.CrossCutting.DataClasses;

namespace DavidTielke.DemoApp.Logic.Business.BookingWorkflows;

public interface IBookingWorkflow
{
    void MarkAsPayed(Booking booking);
}