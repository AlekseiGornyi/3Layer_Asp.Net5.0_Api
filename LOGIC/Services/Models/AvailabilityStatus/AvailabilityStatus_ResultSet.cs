using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.AvailabilityStatus
{
    public class AvailabilityStatus_ResultSet
    {
        public long availabilityStatus_iD { get; set; }
        public string availabilityStatus_name { get; set; }
        public DateTime availabilityStatus_creationDate { get; set; }
        public DateTime availabilityStatus_modifiedDate { get; set; }
    }
}
