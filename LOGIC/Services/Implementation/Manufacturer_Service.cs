using System;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Functions.CRUD;
using DAL.Functions.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models.Manufacturer;



namespace LOGIC.Services.Implementation
{
    // Этот сервис позволяет нам добавлять, находить и изменять Manufacturer Data
    public class Manufacturer_Service : IManufacturer_Service
    {
        // Ссылка на наши CRUD методы
        private ICRUD _crud = new CRUD();

        // Добавить одиночную запись о производителе (Бренде) в БД
        public async Task<Generic_ResultSet<Manufacturer_ResultSet>> AddSingleManufacturer(string name, string description)
        {
            // Создаем екземпляр дженерик класса Generic_ResultSet типа Manufacturer_ResultSet
            Generic_ResultSet<Manufacturer_ResultSet> result = new Generic_ResultSet<Manufacturer_ResultSet>();
            try
            {

                // Создаем новую запись DAL.ENTITY Manufacturer в БД
                Manufacturer Manufacturer = new Manufacturer
                {
                    Manufacturer_Name = name,
                    Manufacturer_Description = description,
                    Manufacturer_CreationDate = DateTime.UtcNow,
                    Manufacturer_ModifiedDate = DateTime.UtcNow
                };

                // Добавляем созданную экземпляр Manufacturer в БД, указывая что его тип будет Manufacturer
                Manufacturer = await _crud.Create<Manufacturer>(Manufacturer);

                // В ручную Мапим возвращенные Manufacturer значения в Manufacturer_ResultSet
                Manufacturer_ResultSet manufacturerAdded = new Manufacturer_ResultSet
                {
                    manufacturer_id = Manufacturer.Manufacturer_ID,
                    manufacturer_name = Manufacturer.Manufacturer_Name,
                    manufacturer_description = Manufacturer.Manufacturer_Description,
                    manufacturer_creationdate = Manufacturer.Manufacturer_CreationDate,
                    manufacturer_modifieddate = Manufacturer.Manufacturer_ModifiedDate
                };

                // Задаем значения для успешного выполнения операции (метода)
                result.userMessage = string.Format("Your Brand {0} was registered succesfully.", name);
                result.internalMessage = "LOGIC.Services.Implementation.Manufacturer_Services: AddSingleManufacturer() method executed succesfully.";
                result.result_set = manufacturerAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                // Задаем значения для неудачного выполнения операции (метода)
                result.exception = exception;
                result.userMessage = "We faild to register your Brand. Please try again.";
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Manufacturer_Services: AddSingleManufacturer(): {0} .", exception);
                // result.success у нас по умолчания задан как false, и это последнее значение которые мы задаем в блоке try. Мы не должны его когда либо изменять в блоке catch.
            }
            return result;
        }

        // метод поиска Бренда по id и возвращения его клиенту.
        public async Task<Generic_ResultSet<Manufacturer_ResultSet>> GetManufacturerById(long manufacturer_id)
        {
            Generic_ResultSet<Manufacturer_ResultSet> result = new Generic_ResultSet<Manufacturer_ResultSet>();
            try
            {
                // GET Manufacturer из БД
                Manufacturer Manufacturer = await _crud.Read<Manufacturer>(manufacturer_id);

                // В ручную Мапим возвращенные Manufacturer значения в Manufacturer_ResultSet
                Manufacturer_ResultSet manufacturerReturned = new Manufacturer_ResultSet
                {
                    manufacturer_id = Manufacturer.Manufacturer_ID,
                    manufacturer_name = Manufacturer.Manufacturer_Name,
                    manufacturer_description = Manufacturer.Manufacturer_Description,
                    manufacturer_creationdate = Manufacturer.Manufacturer_CreationDate,
                    manufacturer_modifieddate = Manufacturer.Manufacturer_ModifiedDate
                };

                result.userMessage = string.Format("Manufacturer {0} was succesfully found.", manufacturerReturned.manufacturer_name);
                result.internalMessage = "LOGIC.Services.Implementation.Manufacturer_Services: GetManufacturerById() method executed succesfully.";
                result.result_set = manufacturerReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We failed to find Brand by id: {0}", manufacturer_id);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Manufacturer_Services: GetManufacturerById(): {0}.", exception);
            }
            return result;
        }

        // метод для поиска и изменения полей данных по Бренду.
        public async Task<Generic_ResultSet<Manufacturer_ResultSet>> UpdateManufacturer(long manufacturer_id, string manufacturer_name, string manufacturer_description)
        {
            Generic_ResultSet<Manufacturer_ResultSet> result = new Generic_ResultSet<Manufacturer_ResultSet>();
            try
            {
                Manufacturer ManufacturerToUpdate = new Manufacturer
                {
                    Manufacturer_ID = manufacturer_id,
                    Manufacturer_Name = manufacturer_name,
                    Manufacturer_Description = manufacturer_description,
                    Manufacturer_ModifiedDate = DateTime.UtcNow
                };

                //Обновляем данные в БД по указанному ID
                ManufacturerToUpdate = await _crud.Update<Manufacturer>(ManufacturerToUpdate, manufacturer_id);

                Manufacturer_ResultSet manufacturerUpdated = new Manufacturer_ResultSet
                {
                    manufacturer_id = ManufacturerToUpdate.Manufacturer_ID,
                    manufacturer_name = ManufacturerToUpdate.Manufacturer_Name,
                    manufacturer_description = ManufacturerToUpdate.Manufacturer_Description,
                    manufacturer_creationdate = ManufacturerToUpdate.Manufacturer_CreationDate,
                    manufacturer_modifieddate = ManufacturerToUpdate.Manufacturer_ModifiedDate
                };

                result.userMessage = string.Format("Brand {0} was successfully updated", manufacturer_name);
                result.internalMessage = "LOGIC.Services.Implementation.Manufacturer_Services: UpdateManufacturer() method executed succesfully.";
                result.result_set = manufacturerUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We failed to update an {0} manufacturer", manufacturer_name);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Manufacturer_Services: UpdateManufacturer() {0}.", exception);
            }
            return result;
        }
    }
}