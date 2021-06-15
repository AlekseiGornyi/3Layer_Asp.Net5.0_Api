using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Specification
    {
        public long Good_Spec_ID { get; set; }
        public string Good_Type { get; set; }
        public string Good_Size { get; set; }
        public string Good_Color { get; set; }
        public bool Good_IsGaming { get; set; }

    }
}
