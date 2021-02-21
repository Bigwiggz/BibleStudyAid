using BibleStudyDataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IFamilyStudyProjectsData
    {
        void DeleteAsync(object Id);
        Task<IEnumerable<FamilyStudyProjects>> GetAllAsync();
        Task<FamilyStudyProjects> GetByIdAsync(object Id);
        void InsertAsync(FamilyStudyProjects obj);
        void UpdateAsync(FamilyStudyProjects obj);
    }
}