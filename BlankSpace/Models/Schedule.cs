using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlankSpace.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public string StartingFrom { get; set; }
        public string Destination { get; set; }
        public string Time { get; set; }

    }
}
