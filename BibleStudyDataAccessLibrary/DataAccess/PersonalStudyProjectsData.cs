using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class PersonalStudyProjectsData : IGenericInterface<PersonalStudyProjects>
    {
        private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<PersonalStudyProjects> _logger;

        public PersonalStudyProjectsData(IConfiguration config, ISqlDataAccess sql, ILogger<PersonalStudyProjects> logger)
        {
            _config = config;
            _sql = sql;
            _logger = logger;
        }
        public async Task<object> DeleteAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            var result = await _sql.SaveData<object, dynamic>("spDeletePersonalStudyProjects", p);
            return result;
        }

        public async Task<IEnumerable<PersonalStudyProjects>> GetAllAsync()
        {
            var result = await _sql.LoadData<PersonalStudyProjects, dynamic>("spGetAllPersonalStudyProjects", new { });

            return result;
        }

        public async Task<PersonalStudyProjects> GetByIdAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            var result = await _sql.LoadSingleRecord<PersonalStudyProjects, dynamic>("spGetByIdPersonalStudyProjects", p);

            return result;
        }

        public async Task<object> InsertAsync(PersonalStudyProjects obj)
        {
            var p = new
            {
                PersonalStudyTitle=obj.PersonalStudyTitle,
                PersonalStudyDescription=obj.PersonalStudyDescription,  
                PersonalStudyQuestionAssignment = obj.PersonalStudyQuestionAssignment,
                DateFinished=obj.DateFinished,
                BaseScripture=obj.BaseScripture,
                IsDeleted=obj.IsDeleted

            };

            var result = await _sql.SaveData<object, dynamic>("spCreatePersonalStudyProjects", p);

            return result;
        }

        public async Task<object> UpdateAsync(PersonalStudyProjects obj)
        {
            var result = await _sql.SaveData<object, dynamic>("spUpdatePersonalStudyProjects", obj);
            return result;
        }

        public async void SaveFullParentAndAllChildrenRecords(PersonalStudyProjects personalStudyProjects,
            List<References> references,
            List<Scriptures> scriptures,
            List<TagsToOtherTables> tagsToOtherTables,
            List<Documents> documents)
        {
            //TODO: Finish Implementation
            throw new NotImplementedException();
        }

        public async Task<PersonalStudyProjectsAll> GetParentAndAllChildrenRecordsAsync(int Id)
        {
            //TODO: Finish Implementation
            throw new NotImplementedException();
        }


    }
}
