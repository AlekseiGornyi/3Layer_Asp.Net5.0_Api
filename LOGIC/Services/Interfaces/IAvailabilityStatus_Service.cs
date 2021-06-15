using LOGIC.Services.Models;
using LOGIC.Services.Models.AvailabilityStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IAvailabilityStatus_Service
    {
        Task<Generic_ResultSet<AvailabilityStatus_ResultSet>> AddSingleAvailabilityStatus(string name);
        Task<Generic_ResultSet<AvailabilityStatus_ResultSet>> GetAvailabilityStatusId(long availabilityStatus_id);
        Task<Generic_ResultSet<AvailabilityStatus_ResultSet>> UpdateAvailabilityStatus(long availabilityStatus_id, string name);
    }
}
