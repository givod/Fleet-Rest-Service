using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagementWebService
{
   public interface IDataRepository
   {
        Dictionary<Guid, Fleet> GetFleets();
        Fleet AddFleet(Fleet fleet);
        bool RemoveFleet(Guid fleetId);
        Fleet UpdateFleet(Fleet fleet);
        List<Category> GetCategories();
       List<Category> AddCategory(Category category);
       List<Category> RemoveCategory(int Id);
       Fleet GetFleetById(Guid Id);
   }
}
