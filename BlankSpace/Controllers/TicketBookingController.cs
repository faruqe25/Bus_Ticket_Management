using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlankSpace.Database;
using BlankSpace.Helper;
using BlankSpace.ViewModels;
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
        //[HttpGet]
        //[HttpPost]
        //public JsonResult CheckDes(int id)
        //{
        //    var d = _context.BusSchedules.AsNoTracking().Where(s => s.BusScheduleId == id).FirstOrDefault();


        //    return Json(d.Destination);
        //}
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
        public JsonResult checktime(int id,int id2)
        {
            var d = _context.BusSchedules.AsNoTracking().Where(s => s.StartingFrom == id && s.Destination==id2).FirstOrDefault();

            return Json(d.Time);
        }
        public JsonResult checkid(int id, int id2) 
        {
            var d = _context.BusSchedules.AsNoTracking().Where(s => s.StartingFrom == id && s.Destination == id2).FirstOrDefault();

            return Json(d.BusScheduleId);
        }

        public IActionResult Index()
        {
            var start = _context.Places.AsNoTracking().ToList();
            ViewBag.Start = new SelectList(start, "PlaceId", "PlaceName");

            return View();
        }

        [HttpPost]
        public IActionResult Booking(BookingVm b) 
        {
            var TicketList = _context.TicketReservations.
                 AsNoTracking().Include(a => a.BusSchedule).
                 Where(s => s.BusSchedule.BusId == b.BusId && s.BusSchedule.StartingFrom == b.StartingFrom
                 && s.BusSchedule.Destination == b.Destination && s.Date == b.Date).ToList();
            if(TicketList.Count()==0)
            {
                var Seat = _context.Buses.Where(s => s.BusId == b.BusId).FirstOrDefault();
                var Tickets = GenarateTicket.Ticket(Seat.TotalSeat, b.BookingVmId, b.Date);

                var SeatSent=new List<TicketReservationVm>();
                foreach (var item in Tickets )
                {
                    _context.TicketReservations.Add(item);
                    _context.SaveChanges();
                    TicketReservationVm a = new TicketReservationVm()
                    { 
                        TicketReservationId=item.TicketReservationId,
                        ConfirmStatus=item.ConfirmStatus,
                        Date=item.Date,
                        AgentId=item.AgentId,
                        PassengerId=item.PassengerId,
                        BusScheduleId=item.BusScheduleId,
                        SeatNumber=item.SeatNumber
                    
                    };
                    if (item.ConfirmStatus == false)
                    {
                        a.MightBeReserve = true;
                    }
                    else
                    {
                        a.MightBeReserve = false;
                    }
                    SeatSent.Add(a);






                }

                return View(SeatSent);
            }
            else
            {
                var Ticket = _context.TicketReservations.
                 AsNoTracking().Include(a => a.BusSchedule).
                 Where(s => s.BusSchedule.BusId == b.BusId && s.BusSchedule.StartingFrom == b.StartingFrom
                 && s.BusSchedule.Destination == b.Destination 
                 && s.Date.Month == b.Date.Month
                 && s.Date.Year == b.Date.Year
                 && s.Date.Day == b.Date.Day).ToList();

                var SeatSent = new List<TicketReservationVm>();
                foreach (var item in Ticket)
                    {
                        
                        TicketReservationVm a = new TicketReservationVm()
                        {
                            TicketReservationId = item.TicketReservationId,
                            ConfirmStatus = item.ConfirmStatus,
                            Date = item.Date,
                            AgentId = item.AgentId,
                            PassengerId = item.PassengerId,
                            BusScheduleId = item.BusScheduleId,
                            SeatNumber=item.SeatNumber


                        };
                        if (item.ConfirmStatus == false)
                        {
                            a.MightBeReserve = true;
                        }
                        SeatSent.Add(a);
                    }

                    return View(SeatSent);
                }


           
        }
    }
}