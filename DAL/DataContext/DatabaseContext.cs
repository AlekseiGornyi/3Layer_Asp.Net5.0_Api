using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System;


namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            //Constructor
            public OptionsBuild()
            {
                // Создание объекта класса AppConfiguration к нашему connection string
                Settings = new AppConfiguration();

                // Инициализация класса который позволяет нам настроить связь с БД для DB Context
                // В нашем случае передает данные о месте расположения connection string для использования в DatabaseContext
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

                // Передача расположения connection string для связи с MC SQL DB
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);

                // Передача настроек для DbContext 
                DatabaseOptions = OptionsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }

        // Используем статик поле для того чтобы при создании класса DatabaseContext у нас уже было доступно поле DbContextOptions
        // Так как статические конструктор по умолчанию будет инициализирован до того как начнет собираться класс DatabaseContext
        public static OptionsBuild Options = new OptionsBuild();

        //DatabaseContext Constructor
        // Инициализирует новый экземпляр класса DbContext с определенными опциями
        // В нашем случае мы всегда будем использовать static OptionsBuild Options так как они всегда доступны и готовы к использованию
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        // Наши DdSets [данные]
        public DbSet<Manufacturer> Manufacturers { get; set; } 
        public DbSet<Good> Goods { get; set; } 
        public DbSet<Specification> Specifications { get; set; } 
        public DbSet<AvailablilityStatus> AvailablilityStatus { get; set; } 



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Задаем дефолтное значение для modified date
            DateTime modifiedDate = new DateTime(1900, 1, 1);

            #region Manufecturer
            modelBuilder.Entity<Manufacturer>().ToTable("manufacturer");
            // основной ключ + ID столбец
            modelBuilder.Entity<Manufacturer>().HasKey(manuf => manuf.Manufacturer_ID);
            modelBuilder.Entity<Manufacturer>().Property(manuf => manuf.Manufacturer_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("manufacturer_id");

            // Настройки столбцов
            modelBuilder.Entity<Manufacturer>().Property(manuf => manuf.Manufacturer_Name).IsRequired(true).HasMaxLength(100).HasColumnName("manufacturer_name");
            modelBuilder.Entity<Manufacturer>().Property(manuf => manuf.Manufacturer_Description).IsRequired(true).HasMaxLength(255).HasColumnName("manufacturer_description");
            modelBuilder.Entity<Manufacturer>().Property(manuf => manuf.Manufacturer_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("manufacturer_creation_date");
            modelBuilder.Entity<Manufacturer>().Property(manuf => manuf.Manufacturer_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("manufacturer_modified_date");

            //Связи
            modelBuilder.Entity<Manufacturer>()
                .HasMany<Good>(good => good.Goods)
                .WithOne(manuf => manuf.Manufacturer)
                .HasForeignKey(good => good.Good_ID)
                .OnDelete(DeleteBehavior.Restrict); // Не удаляем данные по Брендам, только модифицируем. Если хочется удалить Бренд, нужно удалить все его товары.
            #endregion

            #region AvailabilityStatus
            modelBuilder.Entity<AvailablilityStatus>().ToTable("availablility_status");

            // основной ключ + ID столбец
            modelBuilder.Entity<AvailablilityStatus>().HasKey(avas => avas.AvailabilityStatus_ID);
            modelBuilder.Entity<AvailablilityStatus>().Property(avas => avas.AvailabilityStatus_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("availability_status_id");

            // Настройки столбцов
            modelBuilder.Entity<AvailablilityStatus>().HasIndex(avas => avas.AvailabilityStatus_Name).IsUnique(); // Статус должен иметь уникальное имя
            modelBuilder.Entity<AvailablilityStatus>().Property(avas => avas.AvailabilityStatus_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow)
                .HasColumnName("availability_status_creation_date");
            modelBuilder.Entity<AvailablilityStatus>().Property(avas => avas.AvailabilityStatus_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate)
                .HasColumnName("availability_status_modified_date");

            //Связи
            modelBuilder.Entity<AvailablilityStatus>()
                .HasMany<Good>(good => good.Goods)
                .WithOne(avas => avas.AvailablilityStatus)
                .HasForeignKey(avas => avas.AvailablilityStatus_ID)
                .OnDelete(DeleteBehavior.Restrict); // Нельзя удалять Статусы, их можно только модицировать.
            #endregion

            #region Specification
            modelBuilder.Entity<Specification>().ToTable("specification");

            // основной ключ + ID столбец
            modelBuilder.Entity<Specification>().HasKey(spec => spec.Good_Spec_ID);
            modelBuilder.Entity<Specification>().Property(spec => spec.Good_Spec_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("specification");

            //Настройка столбцов
            modelBuilder.Entity<Specification>().Property(spec => spec.Good_Type).IsRequired(true).HasMaxLength(50).HasColumnName("good_type");
            modelBuilder.Entity<Specification>().Property(spec => spec.Good_Color).IsRequired(true).HasMaxLength(50).HasColumnName("good_color");
            modelBuilder.Entity<Specification>().Property(spec => spec.Good_Size).IsRequired(true).HasMaxLength(50).HasColumnName("good_size");
            modelBuilder.Entity<Specification>().Property(spec => spec.Good_IsGaming).IsRequired(true).HasMaxLength(50).HasColumnName("good_is_gaming");           
            #endregion

            #region Good
            modelBuilder.Entity<Good>().ToTable("good");

            modelBuilder.Entity<Good>().HasKey(good => good.Good_ID);
            modelBuilder.Entity<Good>().Property(good => good.Good_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("good");

            modelBuilder.Entity<Good>().Property(good => good.Good_Name).IsRequired(true).HasMaxLength(100).HasColumnName("good_name");
            modelBuilder.Entity<Good>().Property(good => good.Good_Description).IsRequired(true).HasMaxLength(150).HasColumnName("good_descript");
            modelBuilder.Entity<Good>().Property(good => good.Manufacturer_ID).IsRequired(true).HasColumnName("manufecturer_id");
            modelBuilder.Entity<Good>().Property(good => good.AvailablilityStatus_ID).IsRequired(true).HasColumnName("availability_status_id");
            modelBuilder.Entity<Good>().Property(good => good.Good_Specification_ID).IsRequired(true).HasColumnName("specification_id");
            modelBuilder.Entity<Good>().Property(good => good.Good_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creation_date");
            modelBuilder.Entity<Good>().Property(good => good.Good_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("modified_date");

            modelBuilder.Entity<Good>()
                .HasOne(manuf => manuf.Manufacturer) // Производитель должен быть один,
                .WithMany(good => good.Goods)  // но может иметь много товаров,
                .HasForeignKey(manuf => manuf.Manufacturer_ID) // сортирующихся по ID производителя
                .OnDelete(DeleteBehavior.NoAction); // еденица товара может быть удален

            modelBuilder.Entity<Good>()
                .HasOne(avas => avas.AvailablilityStatus)   // статус наличия должен быть один
                .WithMany(good => good.Goods)   // может быть присвоен множеству товаров
                .HasForeignKey(avas => avas.AvailablilityStatus_ID) // сортирующихся по ID статуса наличия
                .OnDelete(DeleteBehavior.NoAction); // еденица товара может быть удалена
            #endregion
        }
    }
}
