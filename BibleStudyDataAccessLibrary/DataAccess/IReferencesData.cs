using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IReferencesData
    {
        void DeleteAsync(object Id);
        Task<IEnumerable<References>> GetAllAsync();
        Task<IEnumerable<References>> GetByForeignKey(object obj);
        Task<References> GetByIdAsync(object Id);
        void InsertAsync(References obj);
        void UpdateAsync(References obj);
    }
}