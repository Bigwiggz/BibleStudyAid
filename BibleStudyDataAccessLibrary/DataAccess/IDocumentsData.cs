using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IDocumentsData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<Documents>> GetAllAsync();
        Task<IEnumerable<Documents>> GetByForeignKey(object obj);
        Task<Documents> GetByIdAsync(object Id);
        Task<object> InsertAsync(Documents obj);
        Task<object> UpdateAsync(Documents obj);
    }
}