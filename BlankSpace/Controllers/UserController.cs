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
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;
        public UserController(DatabaseContext context)
        {
            _context = context;
        }

      

        public IActionResult AddNewAgent()
        {
            return View();
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
            ModelState.Clear();
            return View();
        }
        public IActionResult AgentList()
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
        public IActionResult AgentDetails(int id)
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
        public IActionResult DeleteAgent(int id)
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


            return View();
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
            var item1 = _context.RoleTypes.AsNoTracking().ToList();
            var sent = new List<RoleTypeVm>();
            int c = 1;
            foreach (var item in item1)
            {
                RoleTypeVm b = new RoleTypeVm()
                {
                    RoleName = item.RoleName,
                    RoleTypeId = item.RoleTypeId,
                    Serial=c

                };
                sent.Add(b);
                c++;
            }


            return View(sent);


        }
         public IActionResult UpdateRole(int id) 
        {
            var item = _context.RoleTypes.AsNoTracking().Where(a => a.RoleTypeId == id).FirstOrDefault();

            
                RoleTypeVm b = new RoleTypeVm()
                {
                    RoleName = item.RoleName,
                    RoleTypeId = item.RoleTypeId,
                    

                };
               
               

            return View(b);


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
            var item = _context.RoleTypes.AsNoTracking().Where(a => a.RoleTypeId == id).FirstOrDefault();
            _context.RoleTypes.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("RoleList");
        }



    }
}