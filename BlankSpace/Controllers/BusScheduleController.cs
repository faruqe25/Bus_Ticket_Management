﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlankSpace.Database;
using BlankSpace.Models;
using BlankSpace.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var bus = _context.Buses.AsNoTracking().ToList();
            ViewBag.Bus = new SelectList(bus, "BusId", "CoachName");
            return View();
        } 
        [HttpPost]
        public IActionResult AddSchedule(BusScheduleVm a)
        {
            BusSchedule s = new BusSchedule()
            {
                BusScheduleId = 0,
                Destination = a.Destination,
                StartingFrom = a.StartingFrom,
                Time = a.Time,
                BusId=a.BusId,
                TicketPrice=a.TicketPrice


            };
            _context.BusSchedules.Add(s);
            _context.SaveChanges();

            return RedirectToAction("ScheduleList");
        }
        public IActionResult ScheduleList()
        {
            var s = _context.BusSchedules.AsNoTracking().Include(sp=>sp.Bus).ToList();
            var sent = new List<BusScheduleVm>();
            int c = 1;
            foreach (var item in s)
            {
                BusScheduleVm sp = new BusScheduleVm()
                {
                    BusScheduleId = item.BusScheduleId,
                    Destination = item.Destination,
                    StartingFrom = item.StartingFrom,
                    Time = item.Time,
                    Serial = c,
                    CoachName=item.Bus.CoachName,
                    TicketPrice=item.TicketPrice

                };
                sent.Add(sp);
                  c++;
            }
           
           

            return View(sent);
        } 
        public IActionResult DetailsSchedule(int id)
        {
            var s = _context.BusSchedules.AsNoTracking().Where(sa => sa.BusScheduleId == id).Include(p=>p.Bus).FirstOrDefault();

            BusScheduleVm sp = new BusScheduleVm()
                {
                    BusScheduleId = s.BusScheduleId,
                    Destination = s.Destination,
                    StartingFrom = s.StartingFrom,
                    Time = s.Time,
                    TicketPrice=s.TicketPrice,
                    CoachName=s.Bus.CoachName
                };
            return View(sp);
        }
        public IActionResult DeleteSchedule(int id)
        {
            var s = _context.BusSchedules.AsNoTracking().Where(sa => sa.BusScheduleId == id).Include(a=>a.Bus).FirstOrDefault();

            BusScheduleVm sp = new BusScheduleVm()
            {
                BusScheduleId = s.BusScheduleId,
                Destination = s.Destination,
                StartingFrom = s.StartingFrom,
                Time = s.Time,
                TicketPrice = s.TicketPrice,
                CoachName = s.Bus.CoachName
            };
            return View(sp); 
        }
        [HttpPost]
        public IActionResult DeleteSchedule(BusScheduleVm a)
        {
            var s = _context.BusSchedules.AsNoTracking().Where(sa => sa.BusScheduleId == a.BusScheduleId).FirstOrDefault();

            _context.BusSchedules.Remove(s);
            _context.SaveChanges();
            return RedirectToAction("ScheduleList");
        } 
        public IActionResult UpdateSchedule(int  id) 
        {
            var bus = _context.Buses.AsNoTracking().ToList();
            ViewBag.Bus = new SelectList(bus, "BusId", "CoachName");
            var s = _context.BusSchedules.AsNoTracking().Where(sa => sa.BusScheduleId == id).FirstOrDefault();

            BusScheduleVm sp = new BusScheduleVm()
            {
                BusScheduleId = s.BusScheduleId,
                Destination = s.Destination,
                StartingFrom = s.StartingFrom,
                Time = s.Time,
                BusId=s.BusId,
                TicketPrice=s.TicketPrice
            };
            return View(sp);
        }
        [HttpPost]
        public IActionResult UpdateSchedule(BusScheduleVm a)
        {
            BusSchedule s = new BusSchedule()
            {
                BusScheduleId = a.BusScheduleId,
                Destination = a.Destination,
                StartingFrom = a.StartingFrom,
                Time = a.Time,
                BusId = a.BusId,
                TicketPrice = a.TicketPrice


            };
            _context.BusSchedules.Update(s);
            _context.SaveChanges();
            return RedirectToAction("ScheduleList");
        }
      
    }
}