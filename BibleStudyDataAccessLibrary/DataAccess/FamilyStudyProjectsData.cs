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
    public class FamilyStudyProjectsData : IGenericInterface<FamilyStudyProjects>, IFamilyStudyProjectsData
    {
        private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<FamilyStudyProjectsData> _logger;

        public FamilyStudyProjectsData(IConfiguration config, ISqlDataAccess sql, ILogger<FamilyStudyProjectsData> logger)
        {
            _config = config;
            _sql = sql;
            _logger = logger;
        }

        public async void DeleteAsync(object Id)
        {
            await _sql.SaveData("spDeleteFamilyStudyProjectsData", Id);
        }

        public async Task<IEnumerable<FamilyStudyProjects>> GetAllAsync()
        {
            var result = await _sql.LoadData<FamilyStudyProjects, dynamic>("spGetAllFamilyStudyProjects", new { });

            return result;
        }

        public async Task<FamilyStudyProjects> GetByIdAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            var result = await _sql.LoadSingleRecord<FamilyStudyProjects, dynamic>("spGetByIdFamilyStudyProjects", p);

            return result;
        }

        public async void InsertAsync(FamilyStudyProjects obj)
        {
            var p = new
            {
                FamilyStudyDescription = obj.FamilyStudyDescription,
                FamilyStudyFindings = obj.FamilyStudyFindings,
                DateWhenCreated = obj.DateWhenCreated,
                FamilyStudyTitle = obj.FamilyStudyTitle
            };

            await _sql.SaveData("spCreateFamilyStudyProjects", p);
        }

        public async void UpdateAsync(FamilyStudyProjects obj)
        {
            var p = new
            {
                Id = obj.Id,
                FamilyStudyDescription = obj.FamilyStudyDescription,
                FamilyStudyFindings = obj.FamilyStudyFindings,
                DateWhenCreated = obj.DateWhenCreated,
                FamilyStudyTitle = obj.FamilyStudyTitle
            };

            await _sql.SaveData("spUpdateFamilyStudyProjects", p);
        }
    }
}
