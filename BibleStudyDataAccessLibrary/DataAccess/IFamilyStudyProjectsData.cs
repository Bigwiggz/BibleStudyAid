using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IFamilyStudyProjectsData
    {
        Task<object> DeleteAsync(object Id);
        Task<IEnumerable<FamilyStudyProjects>> GetAllAsync();
        Task<FamilyStudyProjects> GetByIdAsync(object Id);
        Task<object> InsertAsync(FamilyStudyProjects obj);
        Task<object> UpdateAsync(FamilyStudyProjects obj);
        void SaveFullParentAndAllChildrenRecords(
            FamilyStudyProjects familyStudyProjects,
            List<References> references,
            List<Scriptures> scriptures,
            List<TagsToOtherTables> tagsToOtherTables,
            List<Documents> documents);
        
            Task<FamilyStudyProjectsAll> GetParentAndAllChildrenRecordsAsync(int Id);
    }
}