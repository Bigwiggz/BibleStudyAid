using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface ITagsData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<Tags>> GetAllAsync();
        Task<IEnumerable<Tags>> GetByForeignKey(object obj);
        Task<Tags> GetByIdAsync(object Id);
        Task<object> InsertAsync(Tags obj);
        Task<object> UpdateAsync(Tags obj);
    }
}