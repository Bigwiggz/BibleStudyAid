using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IDailyBibleReadingData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<DailyBibleReading>> GetAllAsync();
        Task<DailyBibleReading> GetByIdAsync(object Id);
        Task<DailyBibleReadingAll> GetParentAndAllChildrenRecordsAsync(int Id);
        Task<object> InsertAsync(DailyBibleReading dailyBibleReading);
        void SaveFullParentAndAllChildrenRecords(DailyBibleReading dailyBibleReading, List<References> references, List<Scriptures> scriptures, List<TagsToOtherTables> tagsToOtherTables, List<Documents> documents);
        Task<object> UpdateAsync(DailyBibleReading dailyBibleReading);
        Task<DailyBibleReadingAll> GetParentAndAllChildrenRecordsByForeignKeyAsync(string FK);
    }
}