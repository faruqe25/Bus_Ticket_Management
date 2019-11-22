﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlankSpace.ViewModels
{
    public class DriverVm
    {
        public int DriverVmId { get; set; }
        public int DriverSerial { get; set; }
        [Required]
        [Display(Name="Driver Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Driver's Mobile")]
        public Int64 Mobile { get; set; }
        [Required]
        [Display(Name = "Current Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Driving License Number")]
        public string LicenseNumber { get; set; }

    }
}
