using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IPersonalStudyProjectsData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<PersonalStudyProjects>> GetAllAsync();
        Task<PersonalStudyProjects> GetByIdAsync(object Id);
        Task<PersonalStudyProjectsAll> GetParentAndAllChildrenRecordsAsync(int Id);
        Task<PersonalStudyProjectsAll> GetParentAndAllChildrenRecordsByForeignKeyAsync(string FK);
        Task<object> InsertAsync(PersonalStudyProjects obj);
        void SaveFullParentAndAllChildrenRecords(PersonalStudyProjects personalStudyProjects, List<References> references, List<Scriptures> scriptures, List<TagsToOtherTables> tagsToOtherTables, List<Documents> documents);
        Task<object> UpdateAsync(PersonalStudyProjects obj);
    }
}