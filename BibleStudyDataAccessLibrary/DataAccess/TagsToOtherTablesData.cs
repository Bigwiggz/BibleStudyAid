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
    public class TagsToOtherTablesData : IGenericInterface<TagsToOtherTables>, ITagsToOtherTablesData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<TagsToOtherTables> _logger;

        public TagsToOtherTablesData(ISqlDataAccess sql, ILogger<TagsToOtherTables> logger)
        {
            _sql = sql;
            _logger = logger;
        }
        public async Task<object> DeleteAsync(object Id)
        {
            var p = new { Id = Id };
            var result = await _sql.SaveData<object, dynamic>("spDeleteTagsToOtherTables", p);
            return result;
        }

        public Task<IEnumerable<TagsToOtherTables>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TagsToOtherTables> GetByForeignKey(TagsToOtherTables obj)
        {
            var p = new
            {
                TagsId = obj.TagsId,
                FKTableIdandName = obj.FKTableIdandName
            };

            var result = await _sql.LoadSingleRecord<TagsToOtherTables, dynamic>("spGetByFKTagsToTables", p);
            return result;
        }

        public Task<TagsToOtherTables> GetByIdAsync(object Id)
        {
            throw new NotImplementedException();
        }

        public async Task<object> InsertAsync(TagsToOtherTables obj)
        {
            var p = new
            {
                TagsId = obj.TagsId,
                FKTableIdandName = obj.FKTableIdandName
            };
            var result = await _sql.SaveData<object, dynamic>("spCreateTagsToOtherTables", p);
            return result;
        }

        public Task<object> UpdateAsync(TagsToOtherTables obj)
        {
            throw new NotImplementedException();
        }
    }
}
