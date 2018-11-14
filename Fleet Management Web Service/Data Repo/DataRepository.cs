using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagementWebService
{
    public class DataRepository: IDataRepository
    {
        private readonly Dictionary<Guid, Fleet> _dataStore = new Dictionary<Guid, Fleet>();
        private readonly List<Category> _categories = new List<Category>();

        public Dictionary<Guid, Fleet> GetFleets()
        {
            return _dataStore;
        }

        public Fleet AddFleet(Fleet fleet)
        {
            fleet.Id = Guid.NewGuid();
            _dataStore.Add(fleet.Id, fleet);
            return _dataStore.FirstOrDefault(d=>d.Key == fleet.Id).Value;
        }

        public bool RemoveFleet(Guid Id)
        {
           return _dataStore.Remove(Id);
        }

        public Fleet UpdateFleet(Fleet fleet)
        {
            _dataStore[fleet.Id] = fleet;
            return _dataStore[fleet.Id];
        }

        public Fleet GetFleetById(Guid Id)
        {
            return _dataStore[Id];
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
    }
}
