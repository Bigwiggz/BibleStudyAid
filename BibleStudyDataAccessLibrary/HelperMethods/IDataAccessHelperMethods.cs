using BibleStudyDataAccessLibrary.Models.HelperModels;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.HelperMethods
{
    public interface IDataAccessHelperMethods
    {
        Task<TopLevelTablesSelector> SelectTopLevelTableGivenForiegnKey(string foreignKey);
    }
}