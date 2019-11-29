using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlankSpace.Repository;
using BlankSpace.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlankSpace.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusRepository _context;

        public BusController(IBusRepository context)
        {
            _context = context;
        }
        public IActionResult Index() 
        {
            return View();
        }public IActionResult NewBus()
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public IActionResult NewBus(BusVm v)
        {
            _context.AddNewBus(v);
            ModelState.Clear();
            return View();
        }
        public IActionResult BusList()
        {
            if (HttpContext.Session.GetString("UserRole")!=null)
            {
                var s = _context.GetAllBuses();
                var busList = new List<BusVm>();
                int c = 1;
                foreach (var item in s)
                {
                    BusVm a = new BusVm
                    {
                        BusId = item.BusId,
                        BusNumber = item.BusNumber,
                        TotalSeat = item.TotalSeat,
                        CoachName = item.CoachName,


                    };
                    a.BusSerial = c;
                    c++;
                    busList.Add(a);



                }
                return View(busList);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        public IActionResult DeleteBus(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                return View(_context.GetBus(id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          
        }
        [HttpPost]
        public IActionResult DeleteBus(BusVm a)
        {
            _context.DeleteBus(a);
            return RedirectToAction("BusList");
        }
        
        public IActionResult UpdateBus(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                return View(_context.GetBus(id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        [HttpPost]
        public IActionResult UpdateBus(BusVm v)
        {
            _context.UpdateBus(v);
            return RedirectToAction("BusList");
        }

        public IActionResult BusDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                return View(_context.GetBus(id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           

        }


    }
}