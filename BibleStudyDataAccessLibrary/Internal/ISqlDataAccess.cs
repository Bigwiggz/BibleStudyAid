using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.Internal
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task SaveData<T>(string storedProcedure, T parameters);
    }
}