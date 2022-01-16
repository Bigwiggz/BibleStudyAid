using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IScripturesData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<Scriptures>> GetAllAsync();
        Task<IEnumerable<Scriptures>> GetByForeignKey(object obj);
        Task<Scriptures> GetByIdAsync(object Id);
        Task<object> InsertAsync(Scriptures obj);
        Task<object> UpdateAsync(Scriptures obj);
    }
}