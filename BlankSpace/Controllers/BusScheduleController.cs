using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlankSpace.Database;
using BlankSpace.Models;
using BlankSpace.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlankSpace.Controllers
{
    public class BusScheduleController : Controller
    {
        private readonly DatabaseContext _context;

        public BusScheduleController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult AddSchedule()
        { 
            return View();
        } 
        [HttpPost]
        public IActionResult AddSchedule(ScheduleVm a)
        {
            Schedule s = new Schedule()
            {
                ScheduleId = 0,
                Destination = a.Destination,
                StartingFrom = a.StartingFrom,
                Time = a.Time,

            };
            _context.Schedules.Add(s);
            _context.SaveChanges();

            return RedirectToAction("ScheduleList");
        }
        public IActionResult ScheduleList()
        {
            var s = _context.Schedules.AsNoTracking().ToList();
            var sent = new List<ScheduleVm>();
            int c = 1;
            foreach (var item in s)
            {
                ScheduleVm sp = new ScheduleVm()
                {
                    ScheduleId = item.ScheduleId,
                    Destination = item.Destination,
                    StartingFrom = item.StartingFrom,
                    Time = item.Time,
                    Serial = c

                };
                sent.Add(sp);
                  c++;
            }
           
           

            return View(sent);
        }
    }
}