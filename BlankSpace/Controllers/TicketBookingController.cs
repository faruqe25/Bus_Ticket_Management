using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlankSpace.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlankSpace.Controllers
{
    public class TicketBookingController : Controller
    {
        private readonly DatabaseContext _context;

        public TicketBookingController(DatabaseContext context)
        {
            _context = context;
        }
        public JsonResult CheckRoute(int StartingFrom)
        {

            var n = _context.BusSchedules.AsNoTracking().Where(s => s.StartingFrom == StartingFrom).FirstOrDefault();
            if (n == null)
            {
                return Json(data: false);
            }
            else
            {

                return Json(data: true);
            }



        }
        [HttpGet]
        [HttpPost]
        public JsonResult CheckDes(int id)
        {
            var d = _context.BusSchedules.AsNoTracking().Where(s => s.BusScheduleId == id).FirstOrDefault();


            return Json(d.Destination);
        }
        [HttpGet]
        [HttpPost]
        public JsonResult checkboth(int id, int id2)
        {
            var d = _context.BusSchedules.AsNoTracking().Where(s => s.StartingFrom == id && s.Destination == id2).ToList();

            var bus = _context.Buses.ToList();


            var de = from i in d
                     join b in bus on i.BusId equals b.BusId
                     select new
                     {
                         BusId = i.BusId,
                         CoachName = b.CoachName
                     };

            var slist = new SelectList(de, "BusId", "CoachName");

            return Json(slist);
        
   
           
        } 
        [HttpGet]
        [HttpPost]
        public JsonResult CheckTime(int id)
        {
            var d = _context.BusSchedules.AsNoTracking().Where(s => s.BusScheduleId == id).FirstOrDefault();

            return Json(d.Time);
        }
       
        public IActionResult Index()
        {
            var start = _context.Places.AsNoTracking().ToList();
            ViewBag.Start = new SelectList(start, "PlaceId", "PlaceName");

            return View();
        }
        [HttpPost]



























































        public IActionResult Booking() 
        {
            var start = _context.BusSchedules.AsNoTracking().ToList();
            ViewBag.Start = new SelectList(start, "BusScheduleId", "StartingFrom");

            return View();
        }
    }
}