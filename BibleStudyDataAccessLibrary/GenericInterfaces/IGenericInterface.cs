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
        void InsertAsync(T obj);
        void UpdateAsync(T obj);
        void DeleteAsync(object Id);
    }
}
