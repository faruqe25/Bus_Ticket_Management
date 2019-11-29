using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlankSpace.Database;
using BlankSpace.Models;
using BlankSpace.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlankSpace.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;
        public UserController(DatabaseContext context)
        {
            _context = context;
        }

      

        public IActionResult AddNewAgent()
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
        public IActionResult AddNewAgent(AgentVm a)
        {
            Agent b = new Agent()
            {
                AgentId = a.AgentId,
                Address = a.Address,
                DOB = a.DOB,
                Mobile = a.Mobile,
                Name = a.Name
            };
            _context.Agents.Add(b);
            _context.SaveChanges();

            User us = new User()
            {
                Password = b.Name + (b.Mobile % 100).ToString(),
                RoleTypeId = 2,
                UserName = b.Name + (b.Mobile % 100).ToString() + "@whitespace.com",
                UserId = 0,
            };
            _context.Users.Add(us);
            _context.SaveChanges();



            ModelState.Clear();
            return View();
        }
        public IActionResult AgentList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                var a = _context.Agents.AsNoTracking().ToList();
                var sent = new List<AgentVm>();
                int c = 1;
                foreach (var item in a)
                {
                    AgentVm o = new AgentVm()
                    {

                        Address = item.Address,
                        Name = item.Name,
                        Mobile = item.Mobile,
                        DOB = item.DOB,
                        AgentId = item.AgentId,
                        Serial = c
                    };
                    sent.Add(o);

                    c++;
                }
                return View(sent);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
        public IActionResult AgentDetails(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                var item = _context.Agents.AsNoTracking().Where(s => s.AgentId == id).FirstOrDefault();

                AgentVm o = new AgentVm()
                {

                    Address = item.Address,
                    Name = item.Name,
                    Mobile = item.Mobile,
                    DOB = item.DOB,
                    AgentId = item.AgentId,

                };


                return View(o);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        public IActionResult DeleteAgent(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                var item = _context.Agents.AsNoTracking().Where(s => s.AgentId == id).FirstOrDefault();

                AgentVm o = new AgentVm()
                {
                    Address = item.Address,
                    Name = item.Name,
                    Mobile = item.Mobile,
                    DOB = item.DOB,
                    AgentId = item.AgentId,
                };


                return View(o);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
        [HttpPost]
        public IActionResult DeleteAgent(AgentVm a) 
        {
            var item = _context.Agents.Where(s=>s.AgentId==a.AgentId).FirstOrDefault();

            _context.Agents.Remove(item);
            _context.SaveChanges();


            return RedirectToAction("AgentList");
        }
        public IActionResult UpdateAgent(int id) 
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                var item = _context.Agents.AsNoTracking().Where(s => s.AgentId == id).FirstOrDefault();

                AgentVm o = new AgentVm()
                {
                    Address = item.Address,
                    Name = item.Name,
                    Mobile = item.Mobile,
                    DOB = item.DOB,
                    AgentId = item.AgentId,
                };


                return View(o);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
        [HttpPost]
        public IActionResult UpdateAgent(AgentVm item) 
        {
          

            Agent o = new Agent()
            {
                Address = item.Address,
                Name = item.Name,
                Mobile = item.Mobile,
                DOB = item.DOB,
                AgentId = item.AgentId,
            };
            _context.Agents.Update(o);
            _context.SaveChanges();



            return RedirectToAction("AgentList");
        }
        public IActionResult AddRole()
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
        public IActionResult AddRole(RoleTypeVm a)
        {

            RoleType b=new RoleType()
            { RoleName=a.RoleName,
            RoleTypeId=a.RoleTypeId
            
            };
            _context.RoleTypes.Add(b);
            _context.SaveChanges();
            ModelState.Clear();
            return View();


        }
         public IActionResult RoleList()
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                var item1 = _context.RoleTypes.AsNoTracking().ToList();
                var sent = new List<RoleTypeVm>();
                int c = 1;
                foreach (var item in item1)
                {
                    RoleTypeVm b = new RoleTypeVm()
                    {
                        RoleName = item.RoleName,
                        RoleTypeId = item.RoleTypeId,
                        Serial = c

                    };
                    sent.Add(b);
                    c++;
                }


                return View(sent);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           


        }
         public IActionResult UpdateRole(int id) 
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                var item = _context.RoleTypes.AsNoTracking().Where(a => a.RoleTypeId == id).FirstOrDefault();


                RoleTypeVm b = new RoleTypeVm()
                {
                    RoleName = item.RoleName,
                    RoleTypeId = item.RoleTypeId,


                };



                return View(b);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           

        }
        [HttpPost]
        public IActionResult UpdateRole(RoleTypeVm item)  
        {
            
            
                RoleType b = new RoleType()
                {
                    RoleName = item.RoleName,
                    RoleTypeId = item.RoleTypeId,
                };
            _context.RoleTypes.Update(b);
            _context.SaveChanges();
            return RedirectToAction("RoleList");


        }

        public IActionResult DeleteRole(int id)
        {
            if (HttpContext.Session.GetString("UserRole") == "1")
            {
                var item = _context.RoleTypes.AsNoTracking().Where(a => a.RoleTypeId == id).FirstOrDefault();
                _context.RoleTypes.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("RoleList");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }



    }
}