using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlankSpace.ViewModels
{
    public class BusScheduleVm
    {
        public int BusScheduleId { get; set; }
        [Display(Name = "Journey Start From")]
        public string StartingFrom { get; set; }
        public string Destination { get; set; }
        public string Time { get; set; }
        [Display(Name = "Ticket Price")]
        public int TicketPrice { get; set; }
        [Required]
        [Display(Name = "Coach Name ")]
        public int BusId { get; set; }
        public int Serial { get; set; }
        [Display(Name = "Coach Name ")]
        public string CoachName { get; set; } 


       
    }
}
