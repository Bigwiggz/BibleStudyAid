﻿using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
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
        private readonly IMeetingsAssembliesData _MeetingsAssembliesData;
        private readonly IPersonalStudyProjectsData _personalStudyProjectsData;
        private readonly ITalksData _talksData;

        public DataAccessHelperMethods(
            IDailyBibleReadingData dailyBibleReadingData,
            IFamilyStudyProjectsData familyStudyProjectsData,
            IMeetingsAssembliesData MeetingsAssembliesData,
            IPersonalStudyProjectsData personalStudyProjectsData,
            ITalksData talksData)
        {
            _dailyBibleReadingData = dailyBibleReadingData;
            _familyStudyProjectsData = familyStudyProjectsData;
            _MeetingsAssembliesData = MeetingsAssembliesData;
            _personalStudyProjectsData = personalStudyProjectsData;
            _talksData = talksData;
        }
        public async Task<TopLevelTablesSelector> SelectTopLevelTableGivenForiegnKey(string foreignKey)
        {
            string controllerName="";
            object dataObject=null;
            int? Id = null;

            if (foreignKey.Contains("DailyBibleReading"))
            {
                controllerName = "DailyBibleReading";
                DailyBibleReading dailyBibleReading = await _dailyBibleReadingData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
                dataObject = dailyBibleReading;
                Id = dailyBibleReading.Id;
                
            }
            else if (foreignKey.Contains("FamilyStudyProjects"))
            {
                controllerName = "FamilyStudyProjects";
                FamilyStudyProjects familyStudyProjects = await _familyStudyProjectsData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
                dataObject= familyStudyProjects;
                Id = familyStudyProjects.Id;
            }
            else if (foreignKey.Contains("MeetingsAssemblies"))
            {
                controllerName = "MeetingsAssemblies";
                MeetingsAssemblies MeetingsAssemblies = await _MeetingsAssembliesData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
                dataObject = MeetingsAssemblies;
                Id = MeetingsAssemblies.Id;
            }
            else if (foreignKey.Contains("PersonalStudyProjects"))
            {
                controllerName = "PersonalStudyProjects";
                PersonalStudyProjects personalStudyProjects = await _personalStudyProjectsData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
                dataObject = personalStudyProjects;
                Id= personalStudyProjects.Id;
            }
            else if (foreignKey.Contains("Talks"))
            {
                controllerName = "Talks";
                Talks talks = await _talksData.GetParentAndAllChildrenRecordsByForeignKeyAsync(foreignKey);
                dataObject= talks;
                Id = talks.Id;
            }
            else
            {
                controllerName = "Talks";
                dataObject = Task.FromResult<object>(null);
                Id = null;
            }

            TopLevelTablesSelector topLevelTableSelector = new TopLevelTablesSelector
            {
                ControllerName = controllerName,
                ReturnedObject = dataObject,
                Id = Id
            };

            return topLevelTableSelector;

        }

    }
}
