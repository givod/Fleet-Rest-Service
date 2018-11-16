using System;
using System.Collections.Generic;

namespace FleetManagementWebService.Models
{
    public partial class FleetTable
    {
        public Guid Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public DateTime DateAcquired { get; set; }

        public Category Category { get; set; }
    }
}
