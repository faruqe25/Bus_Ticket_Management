using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlankSpace.Models
{
    public class BusSchedule
    {
        public BusSchedule()
        {
            TicketReservations = new HashSet<TicketReservation>();
        }
        [Key]
        public int BusScheduleId { get; set; }
        public int TicketPrice { get; set; }
        public string StartingFrom { get; set; }
        public string Destination { get; set; }
        public string Time { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public virtual ICollection<TicketReservation> TicketReservations { get; set; }

    }
}
