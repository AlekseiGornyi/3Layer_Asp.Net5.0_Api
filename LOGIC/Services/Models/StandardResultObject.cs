using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models
{
    // Все имена переменных не относящиеся к БД с маленькой буквы.
    // Это абстрактный класс который будут наследовать все ResultSet классы. В этом классе задаются вид/формат общих полей для всех ResultSet классов.
    public class StandardResultObject
    {
        public StandardResultObject()
        {
            success = false;
            userMessage = string.Empty;
            internalMessage = string.Empty;
            exception = null;
        }

        public bool success { get; set; }
        public string userMessage { get; set; }
        internal string internalMessage { get; set; } // Используем ключевое слово INTERNAL, эта строка будет использована для отчетов или логирования, пользователь ее не увидит
        internal Exception exception { get; set; } // Используем ключевое слово INTERNAL, эта строка будет использована для отчетов или логирования, пользователь ее не увидит

    }

}
