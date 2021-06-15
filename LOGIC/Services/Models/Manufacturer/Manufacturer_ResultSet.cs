using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Manufacturer
{

    // Поля не относящиеся к БД пишутся с прописной буквы.
    // Этот класс задает структуру полей для дальнейшей работы и обмена данных к БД(соответсвующим классом).
    public class Manufacturer_ResultSet
    {
        public long manufacturer_id { get; set; }
        public string manufacturer_name { get; set; }        
        public string manufacturer_description { get; set; }
        public DateTime manufacturer_creationdate { get; set; }
        public DateTime manufacturer_modifieddate { get; set; }
    }
}
