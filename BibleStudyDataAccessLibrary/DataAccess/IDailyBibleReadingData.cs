using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IDailyBibleReadingData
    {
        void DeleteAsync(object Id);
        Task<IEnumerable<DailyBibleReading>> GetAllAsync();
        Task<DailyBibleReading> GetByIdAsync(object Id);
        Task<DailyBibleReadingAll> GetParentAndAllChildrenRecords(int Id);
        void InsertAsync(DailyBibleReading dailyBibleReading);
        void SaveFullParentAndAllChildrenRecords(DailyBibleReading dailyBibleReading, List<References> references, List<Scriptures> scriptures, List<TagsToOtherTables> tagsToOtherTables);
        void UpdateAsync(DailyBibleReading dailyBibleReading);
    }
}