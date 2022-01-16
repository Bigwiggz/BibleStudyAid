using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IReferencesData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<References>> GetAllAsync();
        Task<IEnumerable<References>> GetByForeignKey(object obj);
        Task<References> GetByIdAsync(object Id);
        Task<object> InsertAsync(References obj);
        Task<object> UpdateAsync(References obj);
    }
}