using LOGIC.Services.Models;
using LOGIC.Services.Models.Good;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IGood_Service
    {
        Task<Generic_ResultSet<Good_ResultSet>> AddSingleGood(long availability_status_id, long manufacturer_id, long good_specification_id, string good_name,
            string good_description);
        Task<Generic_ResultSet<Good_ResultSet>> GetGoodById(long good_id);
        Task<Generic_ResultSet<Good_ResultSet>> UpdateGood(long good_id, long availability_status_id, long manufacturer_id, long good_specification_id, string good_name, 
            string good_description);
        //Task<Generic_ResultSet<List<Good_ResultSet>>> GetGoodsByManufacturerId(long manufacturer_id);
    }
}
