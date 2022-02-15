using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models.HelperModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.HelperMethods
{
    public class DataAccessHelperMethods : IDataAccessHelperMethods
    {
        private readonly IDailyBibleReadingData _dailyBibleReadingData;
        private readonly IFamilyStudyProjectsData _familyStudyProjectsData;
        private readonly IMeetingAssembliesData _meetingAssembliesData;
        private readonly IPersonalStudyProjectsData _personalStudyProjectsData;
        private readonly ITalksData _talksData;

        public DataAccessHelperMethods(
            IDailyBibleReadingData dailyBibleReadingData,
            IFamilyStudyProjectsData familyStudyProjectsData,
            IMeetingAssembliesData meetingAssembliesData,
            IPersonalStudyProjectsData personalStudyProjectsData,
            ITalksData talksData)
        {
            _dailyBibleReadingData = dailyBibleReadingData;
            _familyStudyProjectsData = familyStudyProjectsData;
            _meetingAssembliesData = meetingAssembliesData;
            _personalStudyProjectsData = personalStudyProjectsData;
            _talksData = talksData;
        }
        public async Task<TopLevelTablesSelector> SelectTopLevelTableGivenForiegnKey(string foreignKey)
        {
            string controllerName="";
            object dataObject=null;

            if (foreignKey.Contains("DailyBibleReading"))
            {
                controllerName = "DailyBibleReading";
                dataObject = await _dailyBibleReadingData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
            }
            else if (foreignKey.Contains("FamilyStudyProjects"))
            {
                controllerName = "FamilyStudyProjects";
                dataObject = await _familyStudyProjectsData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
            }
            else if (foreignKey.Contains("MeetingAssemblies"))
            {
                controllerName = "MeetingAssemblies";
                dataObject = await _meetingAssembliesData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
            }
            else if (foreignKey.Contains("PersonalStudyProjects"))
            {
                controllerName = "PersonalStudyProjects";
                dataObject = await _personalStudyProjectsData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
            }
            else if (foreignKey.Contains("Talks"))
            {
                controllerName = "Talks";
                dataObject = await _talksData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
            }
            else
            {
                controllerName = "Talks";
                dataObject = Task.FromResult<object>(null);
            }

            TopLevelTablesSelector topLevelTableSelector = new TopLevelTablesSelector
            {
                ControllerName=controllerName,
                ReturnedObject=dataObject
            };

            return topLevelTableSelector;

        }

    }
}
