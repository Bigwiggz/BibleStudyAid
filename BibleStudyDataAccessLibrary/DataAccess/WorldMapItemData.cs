using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class WorldMapItemData : IGenericInterface<WorldMapItem>, IChildTableInterface<WorldMapItem>, IWorldMapItemData
    {
        private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<WorldMapItem> _logger;

        public WorldMapItemData(IConfiguration config, ISqlDataAccess sql, ILogger<WorldMapItem> logger)
        {
            _config = config;
            _sql = sql;
            _logger = logger;
        }

        public async Task<object> DeleteAsync(object Id)
        {
            var p = new { Id = Id };
            var result = await _sql.SaveData<object, dynamic>("spDeleteWorldMapItem", p);
            return result;
        }
    

        public async Task<IEnumerable<WorldMapItem>> GetAllAsync()
        {
            var result = await _sql.LoadData<WorldMapItem, dynamic>("spGetAllWorldMapItems", new { });
            return result;
        }

        public async Task<IEnumerable<WorldMapItem>> GetByForeignKey(object obj)
        {
            var p = new
            {
                FK = obj
            };

            var result = await _sql.LoadData<WorldMapItem, dynamic>("spGetByFKWorldMapItem", p);
            return result;
        }

        public async Task<WorldMapItem> GetByIdAsync(object Id)
        {
            var p = new { Id = Id };
            var result = await _sql.LoadSingleRecord<WorldMapItem, dynamic>("spGetByIdWorldMapItem", p);
            return result;
        }

        public async Task<object> InsertAsync(WorldMapItem obj)
        {
            var p = new
            {
                FKTableIdandName = obj.FKTableIdandName,
                Color=obj.Color,
                Description = obj.Description,
                GeographyType=obj.GeographyType,
                GeographyData=obj.GeographyData,
                //Guid=obj.Guid,
                Title=obj.Title,
                IsDeleted = obj.IsDeleted
            };

            var result = await _sql.SaveData<object, dynamic>("spCreateWorldMapItem", p);
            return result;
        }

        public async Task<object> UpdateAsync(WorldMapItem obj)
        {
            var p = new
            {
                Id = obj.Id,
                FKTableIdandName = obj.FKTableIdandName,
                Color = obj.Color,
                Description = obj.Description,
                GeographyType = obj.GeographyType,
                GeographyData = obj.GeographyData,
                Guid = obj.Guid,
                Title = obj.Title,
                IsDeleted = obj.IsDeleted
            };

            var result = await _sql.SaveData<object, dynamic>("spUpdateWorldMapItem", p);
            return result;
        }
    }
}
