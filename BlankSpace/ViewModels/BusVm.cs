using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlankSpace.ViewModels
{
    public class BusVm
    {
        public int BusId { get; set; }
        public int BusSerial { get; set; }
        [Required]
        [Display(Name ="Coach Name")]
        public string CoachName { get; set; }
        [Required]
        [Display(Name = "Total Seat")]
        public int TotalSeat { get; set; }
        [Required]
        [Display(Name = "Bus Number")]
        public int BusNumber { get; set; }
    }
}
