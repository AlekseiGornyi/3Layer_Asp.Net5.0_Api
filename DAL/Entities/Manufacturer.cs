using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Manufacturer
    {
        public long Manufacturer_ID { get; set; }
        public string Manufacturer_Name { get; set; }        
        public string Manufacturer_Description { get; set; }
        public DateTime Manufacturer_CreationDate { get; set; }
        public DateTime Manufacturer_ModifiedDate { get; set; }

        // Связь
        // У производителя может быть множество предметов в каталоге, при этом у каждого предмета можно быть только 1 производитель
        // Для возможности добавления фильтра по производителям (Брендам, компаниям)
        public ICollection<Good> Goods { get; set; }
    }
}
