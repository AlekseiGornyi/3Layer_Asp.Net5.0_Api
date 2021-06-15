using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace DAL.DataContext
{
    public class AppConfiguration
    {

        public AppConfiguration() //конструктор класса AppConfiguration
        {
            // ConfigurationBuilder используется для получения настроек из config/settings файла для построения key/value структуры
            // работает по принципу словаря
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            // Устанавливаем path к месту расположения нашего appsettings.json файла
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            // Указываем фаил из переменной path как тот что будет использоваться для создания configurationBuilder
            configurationBuilder.AddJsonFile(path, false);

            // Построение configurationBuilder и присвоение результата (полученние структуры) в объект root
            IConfigurationRoot root = configurationBuilder.Build();

            // Передаем key для объекта root
            IConfigurationSection appSettings = root.GetSection("ConnectionStrings:DefaultConnection");

            // Добавление key value в sqlConnectionVarialbe чтобы мы могли получить к ним доступ после инициализации этого класса
            SqlConnectionString = appSettings.Value;
        }

        public string SqlConnectionString { get; set; }

    }
}
