using DAL.Entities;
using DAL.Functions.CRUD;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Good;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Good_Service : IGood_Service
    {
        private ICRUD _crud = new CRUD();
       
        // Метод создания записи товара пользователем для БД
        public async Task<Generic_ResultSet<Good_ResultSet>> AddSingleGood(long availability_status_id, long manufacturer_id, 
            long good_specification_id, string good_name, string good_description)
        {
            // Создаем екземпляр Дженерик класса Generic_ResultSet типа Good_ResultSet
            Generic_ResultSet<Good_ResultSet> result = new Generic_ResultSet<Good_ResultSet>();
            try
            {
                // Создаем новую запись DAL.ENTITY Good(товар) в БД
                Good Good = new Good
                {
                    AvailablilityStatus_ID = availability_status_id,
                    Manufacturer_ID = manufacturer_id,
                    Good_Specification_ID = good_specification_id,
                    Good_Name = good_name,
                    Good_Description = good_description,
                    Good_CreationDate = DateTime.UtcNow,
                    Good_ModifiedDate = DateTime.UtcNow
                };

                // Добавляем созданную экземпляр Good в БД, указывая что его тип будет Good
                Good = await _crud.Create<Good>(Good);

                Good_ResultSet goodAdded = new Good_ResultSet
                {
                    availablilityStatus_id = Good.AvailablilityStatus_ID,
                    manufacturer_id = Good.Manufacturer_ID,
                    good_specification_id = Good.Good_Specification_ID,
                    good_id = Good.Good_ID,
                    good_name = Good.Good_Name,
                    good_description = Good.Good_Description,
                    good_creationDate = Good.Good_CreationDate,
                    good_modifiedDate = Good.Good_ModifiedDate
                    /*good_creationDate = DateTime.UtcNow,
                    good_modifiedDate = DateTime.UtcNow*/
                };

                result.userMessage = string.Format("You good: {0} is succesfully created", good_name);
                result.internalMessage = "LOGIC.Services.Implementation.Good_Services: AddSingleGood() method executed succesfully.";
                result.result_set = goodAdded;
                result.success = true;

            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We are failed to create your Good: {0}", good_name);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Good_Services: AddSingleGood(): {0}", exception);
            }
            return result;
        }


        // Метод для поиска записи о товаре в Бд
        public async Task<Generic_ResultSet<Good_ResultSet>> GetGoodById(long good_id)
        {
            Generic_ResultSet<Good_ResultSet> result = new Generic_ResultSet<Good_ResultSet>();
            try
            {
                Good Good = await _crud.Read<Good>(good_id);

                Good_ResultSet goodReturned = new Good_ResultSet
                {
                    availablilityStatus_id = Good.AvailablilityStatus_ID,
                    manufacturer_id = Good.Manufacturer_ID,
                    good_specification_id = Good.Good_Specification_ID,
                    good_id = Good.Good_ID,
                    good_name = Good.Good_Name,
                    good_description = Good.Good_Description,
                    good_creationDate = Good.Good_CreationDate,
                    good_modifiedDate = Good.Good_ModifiedDate
                };

                result.userMessage = string.Format("We have found your Good by id: {0}", good_id);
                result.internalMessage = "LOGIC.Services.Implementation.Good_Services: GetGoodById() is executed succesfully";
                result.result_set = goodReturned;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We are failed to find Good by id: {0}", good_id);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Good_Services: GetGoodById(): {0}", exception);
            }
            return result;
        }   

        // Метод для изменения записи об еденице товара (GOOD) в БД
        public async Task<Generic_ResultSet<Good_ResultSet>> UpdateGood(long good_id, long availability_status_id, long manufacturer_id, long good_specification_id,
            string good_name, string good_description)
        {
            Generic_ResultSet<Good_ResultSet> result = new Generic_ResultSet<Good_ResultSet>();
            try
            {
                Good goodToUpdate = new Good
                {   
                    Good_ID = good_id,
                    AvailablilityStatus_ID = availability_status_id,
                    Manufacturer_ID = manufacturer_id,
                    Good_Specification_ID = good_specification_id,
                    Good_Name = good_name,
                    Good_Description = good_description,
                    Good_ModifiedDate = DateTime.UtcNow
                };

                goodToUpdate = await _crud.Update<Good>(goodToUpdate, good_id);

                Good_ResultSet goodUpdated = new Good_ResultSet
                {
                    availablilityStatus_id = goodToUpdate.AvailablilityStatus_ID,
                    manufacturer_id = goodToUpdate.Manufacturer_ID,
                    good_specification_id = goodToUpdate.Good_Specification_ID,
                    good_id = goodToUpdate.Good_ID,
                    good_name = goodToUpdate.Good_Name,
                    good_description = goodToUpdate.Good_Description,
                    good_creationDate = goodToUpdate.Good_CreationDate,
                    good_modifiedDate = goodToUpdate.Good_ModifiedDate
                };

                result.userMessage = string.Format("We have update good: {0}", good_id);
                result.internalMessage = "LOGIC.Services.Implementation.Good_Services: UpdateGood() is executed succesfully";
                result.result_set = goodUpdated;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We failed to update a Good: {0}", good_id);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Good_Services: UpdateGood(): {0}", exception);

            }
            return result;
        }

        // Метод для вывода всего товара (ALL GOODS) по указанному бренду (MANUFACTURER) из БД
       /* public async Task<Generic_ResultSet<List<Good_ResultSet>>> GetGoodsByManufacturerId(long manufacturer_id)
        {
            Generic_ResultSet<List<Good_ResultSet>> result = new Generic_ResultSet<List<Good_ResultSet>>();
            result.result_set = new List<Good_ResultSet>();
            try
            {
                List<Good> Goods = new List<Good>();
                Manufacturer Manufacturer = await _crud.Read<Manufacturer>(manufacturer_id);

                Goods.ForEach(good =>
                {
                    result.result_set.Add(new Good_ResultSet
                    {
                        manufacturer_id = good.Manufacturer_ID,
                        good_specification_id = good.Good_Specification_ID,
                        good_id = good.Good_ID,
                        availablilityStatus_id = good.AvailablilityStatus_ID,
                        good_name = good.Good_Name,
                        good_description = good.Good_Description,
                        good_creationDate = good.Good_CreationDate,
                        good_modifiedDate = good.Good_ModifiedDate
                    });
                });

                result.userMessage = "Your good are locates successfully";
                result.internalMessage = "LOGIC.Services.Implementation.Good_Services: GetGoodsByManufacturerId() executed successfully";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We are failed to locate you goods";
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Good_Services: GetGoodsByManufacturerId(): {0}", exception);
            }
            return result;
        }*/
    }
}
