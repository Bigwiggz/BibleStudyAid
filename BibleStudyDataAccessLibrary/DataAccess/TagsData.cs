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
    public class TagsData : IGenericInterface<Tags>, IChildTableInterface<Tags>, ITagsData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<Tags> _logger;

        public TagsData(ISqlDataAccess sql, ILogger<Tags> logger)
        {
            _sql = sql;
            _logger = logger;
        }
        public async Task<object> DeleteAsync(object Id)
        {
            var p = new { Id = Id };
            var result = await _sql.SaveData<object, dynamic>("spDeleteTag", p);
            return result;
        }

        public async Task<IEnumerable<Tags>> GetAllAsync()
        {
            var result = await _sql.LoadData<Tags, dynamic>("spGetAllTag", new { });
            return result;
        }

        public async Task<IEnumerable<Tags>> GetByForeignKey(object obj)
        {
            var p = new { FK = obj };
            //FINISH THIS
            var result = await _sql.LoadData<Tags, dynamic>("spGetByFKTags", p);
            return result;
        }

        public async Task<Tags> GetByIdAsync(object Id)
        {
            var p = new { Id = Id };
            var result = await _sql.LoadSingleRecord<Tags, dynamic>("spGetByIdTag", p);
            return result;
        }

        public async Task<object> InsertAsync(Tags obj)
        {
            var p = new
            {
                TagName = obj.TagName,
                TagDescription = obj.TagDescription,
                TagColor=obj.TagColor, 
                IsDeleted = obj.IsDeleted
            };

            var result = await _sql.SaveData<object, dynamic>("spCreateTag", p);
            return result;
        }

        public async Task<object> UpdateAsync(Tags obj)
        {
            var p = new
            {
                Id = obj.Id,
                TagName = obj.TagName,
                TagDescription = obj.TagDescription,
                TagColor = obj.TagColor,
                IsDeleted = obj.IsDeleted
            };

            var result = await _sql.SaveData<object, dynamic>("spUpdateTag", p);
            return result;
        }
    }
}
