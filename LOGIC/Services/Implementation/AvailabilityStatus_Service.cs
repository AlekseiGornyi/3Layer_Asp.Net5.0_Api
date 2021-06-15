using DAL.Entities;
using DAL.Functions.CRUD;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.AvailabilityStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class AvailabilityStatus_Service: IAvailabilityStatus_Service
    {
        private ICRUD _crud = new CRUD();

        // Метод создания записи о статусе наличия товара (AVAILABILITY STATUS)
        public async Task<Generic_ResultSet<AvailabilityStatus_ResultSet>> AddSingleAvailabilityStatus(string name)
        {
            Generic_ResultSet<AvailabilityStatus_ResultSet> result = new Generic_ResultSet<AvailabilityStatus_ResultSet>();
            try
            {
                AvailablilityStatus avas = new AvailablilityStatus
                {
                    AvailabilityStatus_Name = name,
                    AvailabilityStatus_CreationDate = DateTime.UtcNow,
                    AvailabilityStatus_ModifiedDate = DateTime.UtcNow
                    
                };

                avas = await _crud.Create<AvailablilityStatus>(avas);

                AvailabilityStatus_ResultSet avasAdded = new AvailabilityStatus_ResultSet
                {
                    availabilityStatus_iD = avas.AvailabilityStatus_ID,
                    availabilityStatus_name = avas.AvailabilityStatus_Name,
                    availabilityStatus_creationDate = avas.AvailabilityStatus_CreationDate,
                    availabilityStatus_modifiedDate = avas.AvailabilityStatus_ModifiedDate
                };

                result.userMessage = "Availability status is successfully created";
                result.internalMessage = "LOGIC.Services.Implementation.AvailabilityStatus_Services:" +
                    " AddSingleAvailabilityStatus() method executed succesfully.";
                result.result_set = avasAdded;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We are failed to create Availability Status: {0}");
                result.internalMessage = string.Format("LOGIC.Services.Implementation.AvailabilityStatus_Services():" +
                    "AddSingleAvailabilityStatus(): {0}", exception);
            }
            return result;
        }

        //Метод поиска записи о статусе наличия товара (AVAILABILITY STATUS) по ID
        public async Task<Generic_ResultSet<AvailabilityStatus_ResultSet>> GetAvailabilityStatusId(long availabilityStatus_id)
        {
            Generic_ResultSet<AvailabilityStatus_ResultSet> result = new Generic_ResultSet<AvailabilityStatus_ResultSet>();
            try
            {
                AvailablilityStatus avas = await _crud.Read<AvailablilityStatus>(availabilityStatus_id);

                AvailabilityStatus_ResultSet avasReturned = new AvailabilityStatus_ResultSet
                {
                    availabilityStatus_iD = avas.AvailabilityStatus_ID,
                    availabilityStatus_name = avas.AvailabilityStatus_Name,
                    availabilityStatus_creationDate = avas.AvailabilityStatus_CreationDate,
                    availabilityStatus_modifiedDate = avas.AvailabilityStatus_ModifiedDate
                };

                result.userMessage = string.Format("We have found your Availability Status id: {0}", availabilityStatus_id);
                result.internalMessage = "LOGIC.Services.Implementation.AvailabilityStatus_Services: " +
                    "GetAvailabilityStatusId() is executed succesfully";
                result.result_set = avasReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We are failed to find Availability Status by id: {0}", availabilityStatus_id);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.AvailabilityStatus_Services:" +
                    " GetAvailabilityStatusId(): {0}", exception);
            }
            return result;
        }

        // Метод измения данных в записи о статусе наличия товара (AVAILABILITY STATUS) по ID
        public async Task<Generic_ResultSet<AvailabilityStatus_ResultSet>> UpdateAvailabilityStatus(long availabilityStatus_id, 
            string name)
        {
            Generic_ResultSet<AvailabilityStatus_ResultSet> result = new Generic_ResultSet<AvailabilityStatus_ResultSet>();
            try
            {
                AvailablilityStatus avasToUpdate = new AvailablilityStatus
                {
                    AvailabilityStatus_ID = availabilityStatus_id,
                    AvailabilityStatus_Name = name,
                    AvailabilityStatus_ModifiedDate = DateTime.UtcNow
                };

                avasToUpdate = await _crud.Update<AvailablilityStatus>(avasToUpdate, availabilityStatus_id);

                AvailabilityStatus_ResultSet avasUpdated = new AvailabilityStatus_ResultSet
                {
                    availabilityStatus_iD = avasToUpdate.AvailabilityStatus_ID,
                    availabilityStatus_name = avasToUpdate.AvailabilityStatus_Name,
                    availabilityStatus_creationDate = avasToUpdate.AvailabilityStatus_CreationDate,
                    availabilityStatus_modifiedDate = avasToUpdate.AvailabilityStatus_ModifiedDate
                };

                result.userMessage = string.Format("We have update Availablility Status: {0}", availabilityStatus_id);
                result.internalMessage = "LOGIC.Services.Implementation.AvailabilityStatus_Services: " +
                    "UpdateAvailabilityStatus() is executed succesfully";
                result.result_set = avasUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We failed to update a Availablility Status: {0}", availabilityStatus_id);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.AvailabilityStatus_Services:" +
                    " UpdateAvailabilityStatus(): {0}", exception);

            }
            return result;
        }

    }
}
