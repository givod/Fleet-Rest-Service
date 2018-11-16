using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagementWebService.Models;

namespace FleetManagementWebService
{
   public interface IDataRepository
   {
        List<FleetTable> GetFleets();
        FleetTable AddFleet(FleetTable fleet);
        Task<bool> RemoveFleet(Guid Id);
        Task<bool> UpdateFleet(FleetTable fleet);
        List<Category> GetCategories();
        List<Category> AddCategory(Category category);
        Task<bool> RemoveCategory(int Id);
        Task<FleetTable> GetFleetById(Guid Id);
   }
}
