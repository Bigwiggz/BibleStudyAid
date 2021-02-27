using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IDocumentsData
    {
        void DeleteAsync(object Id);
        Task<IEnumerable<Documents>> GetAllAsync();
        Task<IEnumerable<Documents>> GetByForeignKey(object obj);
        Task<Documents> GetByIdAsync(object Id);
        void InsertAsync(Documents obj);
        void UpdateAsync(Documents obj);
    }
}