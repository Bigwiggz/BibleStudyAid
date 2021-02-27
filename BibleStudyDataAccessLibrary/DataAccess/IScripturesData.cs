using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IScripturesData
    {
        void DeleteAsync(object Id);
        Task<IEnumerable<Scriptures>> GetAllAsync();
        Task<IEnumerable<Scriptures>> GetByForeignKey(object obj);
        Task<Scriptures> GetByIdAsync(object Id);
        void InsertAsync(Scriptures obj);
        void UpdateAsync(Scriptures obj);
    }
}