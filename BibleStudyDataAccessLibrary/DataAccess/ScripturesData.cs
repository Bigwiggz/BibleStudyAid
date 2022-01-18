using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class ScripturesData : IGenericInterface<Scriptures>, IChildTableInterface<Scriptures>, IScripturesData
    {
        private readonly ISqlDataAccess _sql;

        public ScripturesData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<object> DeleteAsync(object Id)
        {
            var p = new { Id = Id };
            var result=await _sql.SaveData<object,dynamic>("spDeleteScriptures", p);
            return result;
        }

        public async Task<IEnumerable<Scriptures>> GetAllAsync()
        {
            var result = await _sql.LoadData<Scriptures, dynamic>("spGetAllScriptures", new { });
            return result;
        }

        public async Task<IEnumerable<Scriptures>> GetByForeignKey(object obj)
        {
            var p = new
            {
                FK = obj
            };

            var result = await _sql.LoadData<Scriptures, dynamic>("spGetByFKScriptures", p);
            return result;
        }

        public async Task<Scriptures> GetByIdAsync(object Id)
        {
            var p = new { Id = Id };
            var result = await _sql.LoadSingleRecord<Scriptures, dynamic>("spGetByIdScriptures", p);
            return result;
        }

        public async Task<object> InsertAsync(Scriptures obj)
        {
            var p = new
            {
                FKTableIdandName = obj.FKTableIdandName,
                Scripture = obj.Scripture,
                Book=obj.Book,
                Chapter=obj.Chapter,
                Verse=obj.Verse,
                Description = obj.Description,
                IsDeleted = obj.IsDeleted

            };

            var result=await _sql.SaveData<object,dynamic>("spCreateScriptures", p);
            return result;
        }

        public async Task<object>UpdateAsync(Scriptures obj)
        {
            var p = new
            {
                FKTableIdandName = obj.FKTableIdandName,
                Scripture = obj.Scripture,
                Book = obj.Book,
                Chapter = obj.Chapter,
                Verse = obj.Verse,
                Description = obj.Description,
                IsDeleted = obj.IsDeleted
            };

            var result=await _sql.SaveData<object,dynamic>("spUpdateScriptures", p);
            return result;
        }
    }
}
