using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class ReferencesData : IGenericInterface<References>, IChildTableInterface<References>, IReferencesData
    {
        private readonly ISqlDataAccess _sql;

        public ReferencesData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<object> DeleteAsync(object Id)
        {
            var p = new { Id = Id };
            var result=await _sql.SaveData<object,dynamic>("spDeleteReferences", p);
            return result;
        }

        public async Task<IEnumerable<References>> GetAllAsync()
        {
            var result = await _sql.LoadData<References, dynamic>("spGetAllReferences", new { });

            return result;
        }

        public Task<IEnumerable<References>> GetByForeignKey(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<References> GetByIdAsync(object Id)
        {
            var p = new { Id = Id };
            var result = await _sql.LoadSingleRecord<References, dynamic>("spGetByIdReferences", p);
            return result;
        }

        public async Task<object> InsertAsync(References obj)
        {
            var p = new
            {
                FKProject = obj.FIKTableIdandName,
                DocumentName = obj.Reference,
                IsDeleted = obj.IsDeleted
            };

            var result=await _sql.SaveData<object,dynamic>("spCreateReferences", p);
            return result;
        }

        public async Task<object>UpdateAsync(References obj)
        {
            var p = new
            {
                FKProject = obj.FIKTableIdandName,
                DocumentName = obj.Reference,
                IsDeleted = obj.IsDeleted
            };
            var result=await _sql.SaveData<object,dynamic>("spUpdateReferences", p);
            return result;
        }
    }
}
