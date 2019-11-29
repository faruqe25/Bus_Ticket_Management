using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlankSpace.Models;
using BlankSpace.ViewModels;
using BlankSpace.Database;
using Microsoft.AspNetCore.Http;

namespace BlankSpace.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserVm u)
        {
            var result = _context.Users.Where(s => s.UserName == u.UserName &&
                           s.Password == u.Password).FirstOrDefault();
            if(result!=null)
            {
                HttpContext.Session.SetString("UserName", result.UserName);
                HttpContext.Session.SetString("UserRole", result.RoleTypeId.ToString());
                if (result.RoleTypeId == 1)
                {
                    return RedirectToAction("Index", "Bus");
                }
                if (result.RoleTypeId == 2)
                {
                    return RedirectToAction("Index", "TicketBooking");
                }
            }

           
            return RedirectToAction("Index");

        }
       
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}
