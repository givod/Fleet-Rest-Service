using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagementWebService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagementWebService
{
    public class DataRepository: IDataRepository
    {
        private readonly Dictionary<Guid, Fleet> _dataStore = new Dictionary<Guid, Fleet>();
        private readonly List<Categories> _categories = new List<Categories>();
        private readonly FleetDatabaseContext _context;

        public DataRepository(FleetDatabaseContext context)
        {
            _context = context;
        }

        

        public List<FleetTable> GetFleets()
        {
            return _context.FleetTable.ToList();
        }

        public  FleetTable AddFleet(FleetTable fleet)
        {   
            try
            {
                _context.FleetTable.Add(fleet);
               var rs = _context.SaveChanges();
               return _context.FleetTable.FirstOrDefault(d => d.Id == fleet.Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private bool FleetExists(Guid id)
        {
          return _context.FleetTable.Any(e => e.Id == id);
        }

        public async Task<bool> RemoveFleet(Guid Id)
        {
            try
            {
                var fleet = await _context.FleetTable.SingleOrDefaultAsync(f => f.Id == Id);
                _context.FleetTable.Remove(fleet);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }    
        }

        public async Task<bool> UpdateFleet(FleetTable fleet)
        {
            try {
        
                _context.Entry(fleet).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<FleetTable> GetFleetById(Guid Id)
        {
            try
            {
                return await _context.FleetTable.SingleOrDefaultAsync(f => f.Id == Id);
            }
            catch (Exception e)
            {
                throw;
            }   
        }

        public List<Category> GetCategories()
        {
            try {
                return _context.Category.ToList();
            }
            catch (Exception e) {
                throw;
            }
        }

        public List<Category> AddCategory(Category category)
        {
            try {
                category.DateCreated = DateTime.Now;
                _context.Category.Add(category);
                _context.SaveChanges();
                return _context.Category.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> RemoveCategory(int Id)
        {
            try
            {
                var category = await _context.Category.SingleOrDefaultAsync(r => r.CategoryId == Id);
                _context.Category.Remove(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
