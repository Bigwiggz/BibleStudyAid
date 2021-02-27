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
        public async void DeleteAsync(object Id)
        {
            var p = new { Id = Id };
            await _sql.SaveData("spDeleteDocuments", p);
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

        public async void InsertAsync(Documents obj)
        {
            var p = new
            {
                FKProject = obj.FKProject,
                DocumentName = obj.DocumentName,
                Document = obj.Document,
                DocumentType = obj.DocumentType
            };

            await _sql.SaveData("spCreateDocuments", p);
        }

        public async void UpdateAsync(Documents obj)
        {
            var p = new
            {
                FKProject = obj.FKProject,
                DocumentName = obj.DocumentName,
                Document = obj.Document,
                DocumentType = obj.DocumentType
            };

            await _sql.SaveData("spUpdateDocuments", p);
        }
    }
}
