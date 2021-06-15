using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3layerproject.Models.Good
{
    public class Good_Pass_Object
    {
        //public long availablilityStatus_ID { get; set; } // Внешний ключ
        public long manufacturer_ID { get; set; } // Внешний ключ
        public long specification_ID { get; set; } // Внешний ключ       
        public string name { get; set; }
        public string description { get; set; }        
    }
}
