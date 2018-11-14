using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagementWebService
{
    public class Fleet
    {
        public Guid Id { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
        public DateTime DateAcquired { get; set; }
    }
}
