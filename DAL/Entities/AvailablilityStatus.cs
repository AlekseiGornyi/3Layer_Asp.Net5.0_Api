using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AvailablilityStatus
    {
        public long AvailabilityStatus_ID { get; set; }
        public string AvailabilityStatus_Name { get; set; }
        public DateTime AvailabilityStatus_CreationDate { get; set; }
        public DateTime AvailabilityStatus_ModifiedDate { get; set; }


        // Статус доступности может быть присвоен множеству предметов, но предмет может иметь только 1 стату доступности одновременно
        public ICollection<Good> Goods { get; set; }
    }
}
