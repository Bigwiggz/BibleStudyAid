using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IMeetingAssembliesData
    {
        void DeleteAsync(object Id);
        Task<IEnumerable<MeetingAssemblies>> GetAllAsync();
        Task<MeetingAssemblies> GetByIdAsync(object Id);
        Task<MeetingAssembliesAll> GetParentAndAllChildrenRecordsAsync(int Id);
        void InsertAsync(MeetingAssemblies obj);
        void SaveFullParentAndAllChildrenRecords(MeetingAssemblies meetingAssemblies, List<References> references, List<Scriptures> scriptures, List<TagsToOtherTables> tagsToOtherTables, List<Documents> documents);
        void UpdateAsync(MeetingAssemblies obj);
    }
}