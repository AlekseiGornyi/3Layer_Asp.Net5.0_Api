using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3layerproject.Models.Good
{
    public class GoodUpdate_Pass_Object : Good_Pass_Object
    {
        public long id { get; set; }
        public long availablilityStatus_ID { get; set; } // Внешний ключ
    }
}
