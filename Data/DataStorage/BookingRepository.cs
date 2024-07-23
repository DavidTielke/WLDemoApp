using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.DemoApp.CrossCutting.DataClasses;

namespace DavidTielke.DemoApp.Data.DataStorage
{
    public class BookingRepository : IBookingRepository
    {
        public void Insert(Booking booking)
        {
            var csvDataLine = $"{booking.Id},{booking.Start},{booking.End},{booking.RoomNumber},{booking.ContactId}";
            File.AppendAllLines("bookings.csv", new []{csvDataLine});
        }

        public IQueryable<Booking> Query
        {
            get
            {
                var bookings = File
                    .ReadAllLines("bookings.csv")
                    .Select(l => l.Split(","))
                    .Select(p => new Booking
                    {
                        Id = int.Parse(p[0]),
                        Start = DateTime.Parse(p[1]),
                        End = DateTime.Parse(p[2]),
                        RoomNumber = int.Parse(p[3]),
                        ContactId = int.Parse(p[4])
                    }).AsQueryable();
                return bookings;
            }
        }
    }
}
