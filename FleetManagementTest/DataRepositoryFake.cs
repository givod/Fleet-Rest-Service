using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FleetManagementWebService;

namespace FleetManagementTest
{
    public class DataRepositoryFake:IDataRepository
    {
        private readonly Dictionary<Guid, Fleet> _dataStore;
        private readonly List<Category> _categories;
        public DataRepositoryFake()
        {
            Category cat = new Category()
            {
                Id = 1,
                Name = "Truck"
            };

            Fleet fleet = new Fleet()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Category = 1,
                Description = "XXX123TX",
                DateAcquired = DateTime.UtcNow
            };

            _dataStore = new Dictionary<Guid, Fleet>()
            {
                { fleet.Id, fleet}
            };
        }


        public Dictionary<Guid, Fleet> GetFleets()
        {
            return _dataStore;
        }

        public Fleet AddFleet(Fleet fleet)
        {
            fleet.Id = Guid.NewGuid();
            _dataStore.Add(fleet.Id, fleet);
            return _dataStore.FirstOrDefault(d => d.Key == fleet.Id).Value;
        }

        public bool RemoveFleet(Guid fleetId)
        {
            return _dataStore.Remove(fleetId);
        }

        public Fleet UpdateFleet(Fleet fleet)
        {
            _dataStore[fleet.Id] = fleet;
            return _dataStore[fleet.Id];
        }

        public List<Category> GetCategories()
        {
            return _categories;
        }

        public List<Category> AddCategory(Category category)
        {
            _categories.Add(category);
            return _categories;
        }

        public List<Category> RemoveCategory(int Id)
        {
            try
            {
                var category = _categories.FirstOrDefault(r => r.Id == Id);
                _categories.Remove(category);
                return _categories;
            }
            catch (Exception e)
            {
                return new List<Category>();
            }
        }

        public Fleet GetFleetById(Guid Id)
        {
            return _dataStore[Id];
        }
    }
}
