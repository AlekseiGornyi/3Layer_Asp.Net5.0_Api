using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Good
{
    public class Good_ResultSet
    {
        public long availablilityStatus_id { get; set; } // Внешний ключ
        public long manufacturer_id { get; set; } // Внешний ключ
        public long good_specification_id { get; set; } // Внешний ключ
        public long good_id { get; set; }
        public string good_name { get; set; }
        public string good_description { get; set; }
        public DateTime good_creationDate { get; set; }
        public DateTime good_modifiedDate { get; set; }
    }
}
