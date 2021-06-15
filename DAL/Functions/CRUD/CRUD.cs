using DAL.Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.DataContext;

namespace DAL.Functions.CRUD
{
    /// <summary>
    /// Дженерик CRUD методы: Создание, чтение, изменение и удаление
    /// </summary>
    public class CRUD : ICRUD
    {
        // Создание новую запись типа Т и записываем в БД
        public async Task<T> Create<T> (T objectForDb)where T:class
        {
            try 
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<T>(objectForDb);
                    await context.SaveChangesAsync();
                    return objectForDb;
                }
            }
            catch
            {
                throw;
            }
        }

        // Ищем конкретную запись типа Т в БД и возвращаем ее
        public async Task<T> Read<T>(long entityId) where T: class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T result = await context.FindAsync<T>(entityId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }


        // Считываем все записи типа Т из БД
        public async Task<List<T>> ReadAll<T>() where T : class 
        {
            try 
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<T>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }

        }

        // Ищем запись типа Т в БД, и если находим запись изменяем ее согласное objectToUpdate
        public async Task<T> Update<T>(T objectToUpdate, long entityId) where T: class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<T>(entityId);
                    if(objectFound != null)
                    {
                        context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return objectFound;
                }
            }
            catch
            {
                throw;
            }
        }

        // Ищем запись типа Т в БД, и если находим ее, удаляем из БД
        public async Task<bool> Delete<T>(long entityId) where T: class
        {
            try
            {
                using(DatabaseContext context = new (DatabaseContext.Options.DatabaseOptions))
                {
                    T objectToDelete = await context.FindAsync<T>(entityId);
                    if(objectToDelete != null)
                    {
                        context.Remove(objectToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
