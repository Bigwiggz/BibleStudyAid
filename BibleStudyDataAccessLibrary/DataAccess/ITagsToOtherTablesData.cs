using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface ITagsToOtherTablesData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<TagsToOtherTables>> GetAllAsync();
        Task<TagsToOtherTables> GetByIdAsync(object Id);
        Task<object> InsertAsync(TagsToOtherTables obj);
        Task<object> UpdateAsync(TagsToOtherTables obj);
        Task<TagsToOtherTables> GetByForeignKey(TagsToOtherTables obj);
    }
}