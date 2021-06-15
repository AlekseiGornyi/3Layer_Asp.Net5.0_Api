using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Good
    {
        public long AvailablilityStatus_ID { get; set; } // Внешний ключ
        public long Manufacturer_ID { get; set; } // Внешний ключ
        public long Good_Specification_ID { get; set; } // Внешний ключ
        public long Good_ID { get; set; } 
        public string Good_Name { get; set; }
        public string Good_Description { get; set; }
        public DateTime Good_CreationDate { get; set; }
        public DateTime Good_ModifiedDate { get; set; }


        // Связи
        // Каждому товару присвоен определенному gроизводитель: Manufacturer_ID
        public Manufacturer Manufacturer { get; set; }

        // У каждого товара есть свои характеристики
        public Specification Specification { get; set; }

        // У каждого товара есть свой статус наличия предмета. Статус может быть изменен, но одновременно может быть присвоен только 1 статус
        public AvailablilityStatus AvailablilityStatus { get; set; }
    }
}
