using System;
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
    public class DriverController : Controller
    {
        private readonly DatabaseContext _context;

        public DriverController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult NewDriver()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDriver(DriverVm d)
        {
            Driver di = new Driver()
            { DriverId = d.DriverVmId,
                Name = d.Name,
                Address = d.Address,
                LicenseNumber = d.LicenseNumber,
                Mobile = d.Mobile


            };
            _context.Drivers.Add(di);
            _context.SaveChanges();



            return View();
        }
        public IActionResult DriverList()
        {
            var s = _context.Drivers.AsNoTracking().ToList();
            var dr = new List<DriverVm>();
            int c = 1;
            foreach (var item in s)
            {
                DriverVm se = new DriverVm()
                {
                    DriverVmId = item.DriverId,
                    Name = item.Name,
                    Address = item.Address,
                    Mobile = item.Mobile,
                    LicenseNumber = item.LicenseNumber,


                };
                se.DriverSerial = c;
                c++;
                dr.Add(se);
            }
            return View(dr);
        }
        public IActionResult UpdateDriver(int id)
        {
            var item = _context.Drivers.AsNoTracking().Where(s => s.DriverId == id).FirstOrDefault();
            DriverVm se = new DriverVm()
            {
                DriverVmId = item.DriverId,
                Name = item.Name,
                Address = item.Address,
                Mobile = item.Mobile,
                LicenseNumber = item.LicenseNumber,

            };
            return View(se);
        }
        [HttpPost]
        public IActionResult UpdateDriver(DriverVm d)
        {
            Driver di = new Driver()
            {
                DriverId = d.DriverVmId,
                Name = d.Name,
                Address = d.Address,
                LicenseNumber = d.LicenseNumber,
                Mobile = d.Mobile


            };
            _context.Drivers.Update(di);
            _context.SaveChanges();

            return View();
        }
        public IActionResult DeleteDriver(int id)
        {
            var item = _context.Drivers.AsNoTracking().Where(s => s.DriverId == id).FirstOrDefault();
            DriverVm se = new DriverVm()
            {
                DriverVmId = item.DriverId,
                Name = item.Name,
                Address = item.Address,
                Mobile = item.Mobile,
                LicenseNumber = item.LicenseNumber,

            };
            return View(se);
        }
        [HttpPost]
        public IActionResult DeleteDriver(DriverVm se)
        {
            _context.Drivers.Remove(_context.Drivers.AsNoTracking().Where(s => s.DriverId == se.DriverVmId).FirstOrDefault());
            _context.SaveChanges();
            return RedirectToAction("DriverList");
        }
        public IActionResult DriverDetails(int id)

        {
            var item = _context.Drivers.AsNoTracking().Where(s => s.DriverId == id).FirstOrDefault();
            DriverVm se = new DriverVm()
            {
                DriverVmId = item.DriverId,
                Name = item.Name,
                Address = item.Address,
                Mobile = item.Mobile,
                LicenseNumber = item.LicenseNumber,

            };
            return View(se);
        }
        public IActionResult AssignBus()
        {
            var driver = _context.Drivers.AsNoTracking().ToList();
            ViewBag.Driver = new SelectList(driver, "DriverId", "Name");
            var bus = _context.Buses.AsNoTracking().ToList();
            ViewBag.Bus = new SelectList(bus, "BusId", "CoachName");


            return View();
        }
        [HttpPost]
        public IActionResult AssignBus(AssignedDriverVm a)
        {
            AssignedDriver ab = new AssignedDriver() {
                AssignedDriverId = 0,
                BusId = a.BusId,
                DriverId = a.DriverId
            };
            _context.AssignedDrivers.Add(ab);
            _context.SaveChanges();
            return RedirectToAction("AssignBusList");
        }
        public IActionResult AssignBusList()
        {
            var assignDriverList = _context.AssignedDrivers.
                                AsNoTracking().Include(s => s.Bus).
                                Include(s => s.Driver).ToList();
            var sent = new List<AssignedDriverVm>();
            int c = 1;
            foreach (var item in assignDriverList)
            {
                AssignedDriverVm a = new AssignedDriverVm() {

                    DriverName = item.Driver.Name,
                    CoachName = item.Bus.CoachName,
                    AssignedDriverId = item.AssignedDriverId,
                    Serial = c

                };
                c++;
                sent.Add(a);

            }
            return View(sent);
        }
        public IActionResult DetailsAssignDriver(int id)
        {
            var assignDriver = _context.AssignedDrivers.
                                AsNoTracking().Include(s => s.Bus).
                                Include(s => s.Driver).Where(s => s.AssignedDriverId == id).
                                FirstOrDefault();


            AssignedDriverVm a = new AssignedDriverVm()
            {

                DriverName = assignDriver.Driver.Name,
                CoachName = assignDriver.Bus.CoachName,
                BusNumber= assignDriver.Bus.BusNumber,
                DriverMobile= assignDriver.Driver.Mobile,
                TotalSeat = assignDriver.Bus.TotalSeat
                

            };


            return View(a);
        }
        public IActionResult DeleteAssignedDriver(int id)
        {
            var assignDriver = _context.AssignedDrivers.
                                AsNoTracking().Include(s => s.Bus).
                                Include(s => s.Driver).Where(s => s.AssignedDriverId == id).
                                FirstOrDefault();


            AssignedDriverVm a = new AssignedDriverVm()
            {

                DriverName = assignDriver.Driver.Name,
                CoachName = assignDriver.Bus.CoachName,
                BusNumber= assignDriver.Bus.BusNumber,
                DriverMobile= assignDriver.Driver.Mobile,
                TotalSeat = assignDriver.Bus.TotalSeat,
                AssignedDriverId=assignDriver.AssignedDriverId

            };


            return View(a);
        } 
        [HttpPost]
        public IActionResult DeleteAssignedDriver(AssignedDriverVm id2)
        {
            var assignDriver = _context.AssignedDrivers.
                                AsNoTracking().Where(s => s.AssignedDriverId == id2.AssignedDriverId).
                                FirstOrDefault();
            _context.AssignedDrivers.Remove(assignDriver);
            _context.SaveChanges();
            return RedirectToAction("AssignBusList");
        }
           
    }


    }
