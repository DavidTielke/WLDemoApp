using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.DemoApp.CrossCutting.DataClasses;
using DavidTielke.DemoApp.Data.DataStorage;

namespace DavidTielke.DemoApp.Logic.Domain.BookingManagement
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _repository;
        public BookingManager(IBookingRepository repository)
        {
            _repository = repository;
        }

        public void Add(Booking booking)
        {
            _repository.Insert(booking);
        }

        public IQueryable<Booking> GetAll()
        {
            var bookings = _repository.Query;
            return bookings;
        }
    }
}
