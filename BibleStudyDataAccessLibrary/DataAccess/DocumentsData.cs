using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class DocumentsData : IGenericInterface<Documents>, IChildTableInterface<Documents>, IDocumentsData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<Documents> _logger;

        public DocumentsData(ISqlDataAccess sql, ILogger<Documents> logger)
        {
            _sql = sql;
            _logger = logger;
        }
        public async Task<object> DeleteAsync(object Id)
        {
            var p = new { Id = Id };
            var result=await _sql.SaveData<object,dynamic>("spDeleteDocuments", p);
            return result;
        }

        public async Task<IEnumerable<Documents>> GetAllAsync()
        {
            var result = await _sql.LoadData<Documents, dynamic>("spGetAllDocuments", new { });
            return result;
        }

        public async Task<IEnumerable<Documents>> GetByForeignKey(object obj)
        {
            var p = new
            {
                FK = obj
            };

            var result = await _sql.LoadData<Documents, dynamic>("spGetByFKDocuments", p);
            return result;
        }

        public async Task<Documents> GetByIdAsync(object Id)
        {
            var p = new { Id = Id };
            var result = await _sql.LoadSingleRecord<Documents, dynamic>("spGetByIdDocuments", p);
            return result;
        }

        public async Task<object> InsertAsync(Documents obj)
        {
            var p = new
            {
                FKTableIdandName = obj.FKTableIdandName,
                ContentType=obj.ContentType,
                ContextDisposition=obj.ContentDisposition,
                ContentSize=obj.ContentSize,
                FileName=obj.FileName,
                UniqueGUIDId=obj.UniqueGUIDId,
                Name=obj.Name,
                DocumentDescription=obj.DocumentDescription,
                IsDeleted=obj.IsDeleted
            };

            var result=await _sql.SaveData<object,dynamic>("spCreateDocuments", p);
            return result;
        }

        public async Task<object>UpdateAsync(Documents obj)
        {
            var p = new
            {
                Id=obj.Id,
                FKTableIdandName = obj.FKTableIdandName,
                ContentType = obj.ContentType,
                ContextDisposition = obj.ContentDisposition,
                ContentSize = obj.ContentSize,
                FileName = obj.FileName,
                UniqueGUIDId = obj.UniqueGUIDId,
                Name = obj.Name,
                DocumentDescription = obj.DocumentDescription,
                IsDeleted = obj.IsDeleted
            };

            var result=await _sql.SaveData<object,dynamic>("spUpdateDocuments", p);
            return result;
        }
    }
}
