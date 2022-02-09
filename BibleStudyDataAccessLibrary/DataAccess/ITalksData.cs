using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface ITalksData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<Talks>> GetAllAsync();
        Task<Talks> GetByIdAsync(object Id);
        Task<TalksAll> GetParentAndAllChildrenRecordsAsync(int Id);
        Task<object> InsertAsync(Talks obj);
        void SaveFullParentAndAllChildrenRecords(Talks talks, List<References> references, List<Scriptures> scriptures, List<TagsToOtherTables> tagsToOtherTables, List<Documents> documents);
        Task<object> UpdateAsync(Talks obj);
    }
}