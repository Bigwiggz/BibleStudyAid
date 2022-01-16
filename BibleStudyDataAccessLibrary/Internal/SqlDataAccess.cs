using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.Internal
{
    public class SqlDataAccess : ISqlDataAccess, IDisposable
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters)
        {
            string connectionString = _config.GetConnectionString("DBBibleStudyAid");

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return data.ToList();
            }
        }

        public async Task<T> LoadSingleRecord<T, U>(string storedProcedure, U parameters)
        {
            string connectionString = _config.GetConnectionString("DBBibleStudyAid");

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return data;
            }
        }

        public async Task<T> SaveData<T,U>(string storedProcedure, U parameters)
        {
            string connectionString = _config.GetConnectionString("DBBibleStudyAid");

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data=await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<T> LoadSingleObjectInTransaction<T, U>(string storedProcedure, U parameters)
        {
            var data= await _connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);

            return data;
        }

        public async Task<List<T>> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {

            List<T> rows = (List<T>)await _connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);

            return rows.ToList();

        }

        public async void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {

            await _connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public void StartTransaction(string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            isTransactionClosed = false;
        }

        private bool isTransactionClosed = false;

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();

            isTransactionClosed = true;
        }

        public void RollBackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();

            isTransactionClosed = true;
        }

        public void Dispose()
        {
            if (isTransactionClosed == false)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {

                    //TODO: Log this Issue
                }
            }

            _transaction = null;
            _connection = null;
        }

    }
}
