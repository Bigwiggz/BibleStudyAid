using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.Internal
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task SaveData<T>(string storedProcedure, T parameters);

        Task<T> LoadSingleRecord<T, U>(string storedProcedure, U parameters);

        Task<T> LoadSingleObjectInTransaction<T, U>(string storedProcedure, U parameters);

        Task<List<T>> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);

        void SaveDataInTransaction<T>(string storedProcedure, T parameters);

        void StartTransaction(string connectionStringName);

        void CommitTransaction();

        void RollBackTransaction();

        void Dispose();
    }
}