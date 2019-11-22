using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlankSpace.ViewModels
{
    public class ScheduleVm
    {
        public int ScheduleId { get; set; }
        public int Serial { get; set; }
        [Display(Name ="Journey Start From")]
        public string StartingFrom { get; set; }
        public string Destination { get; set; }
        public string Time { get; set; }

    }
}
