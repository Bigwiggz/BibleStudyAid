using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IMeetingsAssembliesData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<MeetingsAssemblies>> GetAllAsync();
        Task<MeetingsAssemblies> GetByIdAsync(object Id);
        Task<MeetingsAssembliesAll> GetParentAndAllChildrenRecordsAsync(int Id);
        Task<object> InsertAsync(MeetingsAssemblies obj);
        void SaveFullParentAndAllChildrenRecords(MeetingsAssemblies MeetingsAssemblies, List<References> references, List<Scriptures> scriptures, List<TagsToOtherTables> tagsToOtherTables, List<Documents> documents);
        Task<object> UpdateAsync(MeetingsAssemblies obj);

        Task<MeetingsAssembliesAll> GetParentAndAllChildrenRecordsByForeignKeyAsync(string FK);
    }
}