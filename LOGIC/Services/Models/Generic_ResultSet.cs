using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;

namespace LOGIC.Services.Models
{
    // этот класс будет использован как результирующий объект для любого Service метода.
    // Этот класс наледуется от StandardResultObject, и является Дженерик классом.
    // Мы будем приводить Т к нашим пользовательским типам (классам) в наших методах, и сможем использовать этот класс постоянно.
    public class Generic_ResultSet<T>: StandardResultObject
    {
        public T result_set { get; set; }
    }
}
