using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    // Разрешает Db Migration (Возможность переносить данные на другие платформы) и структура ДБ обновляется из DAL
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        // Передаем DatabaseContext для реализации Db Migration
        public DatabaseContext CreateDbContext(string[] args)
        {
            // Получение нашего connection string через AppConfiguration класс
            AppConfiguration Settings = new AppConfiguration();

            // Инициализация нового OptionsBuilder для передачи ему данные которые нужно использовать при работе с DB
            DbContextOptionsBuilder<DatabaseContext> OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            // Указываем OptionsBuilder с какой БД ему работать и какой connection string использовать
            OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);

            // Мы возвращаем новый экземпляр DatabaseContext со всей необходимой connection info, чтобы мы могли выполнить DB Migration
            return new DatabaseContext(OptionsBuilder.Options);
        }

    }

}
