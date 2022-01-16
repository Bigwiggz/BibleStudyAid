using BibleStudyDataAccessLibrary.Models;
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
    }
}