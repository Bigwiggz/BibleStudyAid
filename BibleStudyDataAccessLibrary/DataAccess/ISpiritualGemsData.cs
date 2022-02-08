using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface ISpiritualGemsData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<SpiritualGems>> GetAllAsync();
        Task<SpiritualGems> GetByIdAsync(object Id);
        Task<SpiritualGemsAll> GetParentAndAllChildrenRecordsAsync(int Id);
        Task<object> InsertAsync(SpiritualGems obj);
        void SaveFullParentAndAllChildrenRecords(SpiritualGems spiritualGems, List<References> references, List<Scriptures> scriptures, List<TagsToOtherTables> tagsToOtherTables, List<Documents> documents);
        Task<object> UpdateAsync(SpiritualGems obj);
    }
}