using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlankSpace.Database;
using BlankSpace.Models;
using BlankSpace.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlankSpace.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly DatabaseContext _context;

        public BusRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddNewBus(BusVm BusVm)
        { 

            Bus bus = new Bus() { 
            BusId=BusVm.BusId,
            BusNumber=BusVm.BusNumber,
            CoachName=BusVm.CoachName,
            TotalSeat=BusVm.TotalSeat,
            };
             _context.Buses.Add(bus);
             _context.SaveChanges();
            
        }

        public BusVm GetBus(int id)
        {
            var i = _context.Buses.AsNoTracking().Where(s => s.BusId == id).FirstOrDefault();
            if (i == null)
            {
                i = new Bus();
            }
            BusVm sr = new BusVm { 
            BusId=i.BusId,
            BusNumber=i.BusNumber,
            TotalSeat=i.TotalSeat,
            CoachName=i.CoachName,
            };

            return sr;
        }

        public List<Bus> GetAllBuses()
        {
            return _context.Buses.AsNoTracking().ToList();
        }

       

        public void UpdateBus(BusVm BusVm)
        {
            Bus bus = new Bus()
            {
                BusId = BusVm.BusId,
                BusNumber = BusVm.BusNumber,
                CoachName = BusVm.CoachName,
                TotalSeat = BusVm.TotalSeat,
            };
            _context.Buses.Update(bus);
            _context.SaveChanges();
            
        }

        public void DeleteBus(BusVm id)
        {
            var i= _context.Buses.AsNoTracking().Where(s => s.BusId == id.BusId).FirstOrDefault();
            if(i!=null)
            {
                _context.Buses.Remove(i);
                _context.SaveChanges();
            }
           

        }
    }
}
