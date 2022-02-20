using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IWorldMapItemData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<WorldMapItem>> GetAllAsync();
        Task<IEnumerable<WorldMapItem>> GetByForeignKey(object obj);
        Task<WorldMapItem> GetByIdAsync(object Id);
        Task<object> InsertAsync(WorldMapItem obj);
        Task<object> UpdateAsync(WorldMapItem obj);
    }
}