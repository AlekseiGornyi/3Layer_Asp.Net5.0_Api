using LOGIC.Services.Models.Manufacturer;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IManufacturer_Service
    {
        Task<Generic_ResultSet<Manufacturer_ResultSet>> AddSingleManufacturer(string name, string description);
        Task<Generic_ResultSet<Manufacturer_ResultSet>> GetManufacturerById(long manufacturer_id);
        Task<Generic_ResultSet<Manufacturer_ResultSet>> UpdateManufacturer(long manufacturer_id, string name, string description);
    }
}
