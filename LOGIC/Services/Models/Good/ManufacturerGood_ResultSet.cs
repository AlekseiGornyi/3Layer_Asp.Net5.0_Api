using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models.Manufacturer;

namespace LOGIC.Services.Models.Good
{
    public class ManufacturerGood_ResultSet
    {
        public Good_ResultSet good_ResultSet { get; set; }
        public Manufacturer_ResultSet manufacturer_ResultSet { get; set; }
    }
}
