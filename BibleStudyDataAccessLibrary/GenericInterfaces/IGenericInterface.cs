using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.GenericInterfaces
{
    public interface IGenericInterface<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object Id);
        Task<object> InsertAsync(T obj);
        Task<object> UpdateAsync(T obj);
        Task<object> DeleteAsync(object Id);
    }
}
