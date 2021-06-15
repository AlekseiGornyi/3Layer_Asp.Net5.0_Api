using DAL.Entities;
using DAL.Functions.CRUD;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Specification;
using System;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Specification_Service: ISpecification_Service
    {
        private ICRUD _crud = new CRUD();

        // Метод создания записи о характеристиках (SPECIFICATION) товара в БД
        public async Task<Generic_ResultSet<Specification_ResultSet>> AddSingleSpecification(string type, string size, 
            string color, bool isgaming)
        {
            Generic_ResultSet<Specification_ResultSet> result = new Generic_ResultSet<Specification_ResultSet>();
            try
            {
                Specification Spec = new Specification
                {
                    Good_Type = type,
                    Good_Size = size,
                    Good_Color = color,
                    Good_IsGaming = isgaming
                };

                Spec = await _crud.Create<Specification>(Spec);

                Specification_ResultSet specAdded = new Specification_ResultSet
                {
                    good_spec_id = Spec.Good_Spec_ID,
                    good_type = Spec.Good_Type,
                    good_size = Spec.Good_Size,
                    good_color = Spec.Good_Color,
                    good_isgaming = Spec.Good_IsGaming
                };

                result.userMessage = "The specification has been successfully created";
                result.internalMessage = "LOGIC.Services.Implementation.Specification_Service: AddSingleSpecification() executed successfully";
                result.result_set = specAdded;
                result.success = true;
            }
            catch (Exception exceprion)
            {
                result.exception = exceprion;
                result.userMessage = "The specification creationg is failed";
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Specification_Service: AddSingleSpecification(): " +
                    "{0}", exceprion);
            }
            return result;
        }

        // Метод поиска SPECIFICATION по ID и возврат клиенту
        public async Task<Generic_ResultSet<Specification_ResultSet>> GetSpecificationById(long specification_id)
        {
            Generic_ResultSet<Specification_ResultSet> result = new Generic_ResultSet<Specification_ResultSet>();
            try
            {
                Specification Spec = await _crud.Read<Specification>(specification_id);

                Specification_ResultSet specReturned = new Specification_ResultSet
                {
                    good_spec_id = Spec.Good_Spec_ID,
                    good_type = Spec.Good_Type,
                    good_size = Spec.Good_Size,
                    good_color = Spec.Good_Color,
                    good_isgaming = Spec.Good_IsGaming
                };

                result.userMessage = string.Format("Specification by Id: {0} is successfully finded", specification_id);
                result.internalMessage = "LOGIC.Services.Implementation.Specification_Service: GetSpecificationById() executed successfully";
                result.result_set = specReturned;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We failed to find specification by id: {0}", specification_id);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Specification_Service: GetSpecificationById(): {0}", exception);
            }
            return result;
        }

        // Метод изменения данных в записи характеристик товара (SPECIFICATION)
        public async Task<Generic_ResultSet<Specification_ResultSet>> UpdateSpecification(long specification_id, string type, 
            string size, string color, bool isgaming)
        {
            Generic_ResultSet<Specification_ResultSet> result = new Generic_ResultSet<Specification_ResultSet>();
            try
            {
                Specification specToUpdate = new Specification
                {
                    Good_Spec_ID = specification_id,
                    Good_Type = type,
                    Good_Size = size,
                    Good_Color = color,
                    Good_IsGaming = isgaming
                };

                specToUpdate = await _crud.Update<Specification>(specToUpdate, specification_id);

                Specification_ResultSet specUpdated = new Specification_ResultSet
                {
                    good_spec_id = specToUpdate.Good_Spec_ID,
                    good_type = specToUpdate.Good_Type,
                    good_size = specToUpdate.Good_Size,
                    good_color = specToUpdate.Good_Color,
                    good_isgaming = specToUpdate.Good_IsGaming
                };

                result.userMessage = string.Format("Specification: {0} has been updated successfully", specification_id);
                result.internalMessage = "LOGIC.Services.Implementation.Specification_Service: UpdateSpecification() executed successfully";
                result.result_set = specUpdated;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("We are failed to update specification: {0}", specification_id);
                result.internalMessage = string.Format("LOGIC.Services.Implementation.Specification_Service: UpdateSpecification(): {0}", exception);
            }
            return result;
        }
    }
}
