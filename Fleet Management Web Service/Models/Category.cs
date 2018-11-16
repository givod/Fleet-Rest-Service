using System;
using System.Collections.Generic;

namespace FleetManagementWebService.Models
{
    public partial class Category
    {
        public Category()
        {
            FleetTable = new HashSet<FleetTable>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<FleetTable> FleetTable { get; set; }
    }
}
