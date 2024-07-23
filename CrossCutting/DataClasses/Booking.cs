using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidTielke.DemoApp.CrossCutting.DataClasses
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int RoomNumber { get; set; }
        public int ContactId { get; set; }

        public Booking()
        {
            
        }

        public Booking(int id, DateTime start, DateTime end, int roomNumber)
        {
            Id = id;
            Start = start;
            End = end;
            RoomNumber = roomNumber;
        }
    }
}
