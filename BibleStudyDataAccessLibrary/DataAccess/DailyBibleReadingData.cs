﻿using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class DailyBibleReadingData : IGenericInterface<DailyBibleReading>, IDailyBibleReadingData
    {
        private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<DailyBibleReadingData> _logger;

        public DailyBibleReadingData(IConfiguration config, ISqlDataAccess sql, ILogger<DailyBibleReadingData> logger)
        {
            _config = config;
            _sql = sql;
            _logger = logger;
        }

        public async void InsertAsync(DailyBibleReading dailyBibleReading)
        {
            var p = new
            {
                ScriptureStartPoint=dailyBibleReading.ScriptureStartPoint,
                ScriptureEndPoint=dailyBibleReading.ScriptureEndPoint,
                LessonLearnedDescription=dailyBibleReading.LessonLearnedDescription,
                DateRead=dailyBibleReading.DateRead
            };

            await _sql.SaveData("spCreateDailyBibleReading", p);

        }

        public async void UpdateAsync(DailyBibleReading dailyBibleReading)
        {


            await _sql.SaveData("spUpdateDailyBibleReading", dailyBibleReading);
        }

        public async void DeleteAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            await _sql.SaveData("spDeleteDailyBibleReading", p);
        }

        public async Task<IEnumerable<DailyBibleReading>> GetAllAsync()
        {

            var result = await _sql.LoadData<DailyBibleReading, dynamic>("spGetAllDailyBibleReading", new { });

            return result;
        }

        public async Task<DailyBibleReading> GetByIdAsync(object Id)
        {

            var p = new
            {
                Id = Id
            };

            var result = await _sql.LoadSingleRecord<DailyBibleReading, dynamic>("spGetByIdDailyBibleReading", p);

            return result;
        }

        public async void SaveFullParentAndAllChildrenRecords(DailyBibleReading dailyBibleReading,
            List<References> references,
            List<Scriptures> scriptures,
            List<TagsToOtherTables> tagsToOtherTables,
            List<Documents> documents)
        {
            //TODO: Make this SOLID/DRY/BETTER
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1: Save to Master Table dailyBibleReading
                //Step 2: Get the Id from the Master Table
                string tblId = await _sql.LoadSingleObjectInTransaction<string, dynamic>("spCreateDailyBibleReading", dailyBibleReading);


                //Step 3: add Id to references and add in all references
                foreach (var item in references)
                {
                    item.FIKTableIdandName = tblId;
                    _sql.SaveDataInTransaction("spCreateReferences", item);
                }

                //Step 4: add Id to all scriptures and add in all scriptures
                foreach (var item in scriptures)
                {
                    item.FKTableIdandName = tblId;
                    _sql.SaveDataInTransaction("spCreateScriptures", item);
                }

                //Step 5: add Id to all tagsToOtherTables
                foreach (var item in tagsToOtherTables)
                {
                    item.FKTableIdandName = tblId;
                    _sql.SaveDataInTransaction("spCreateTagsToOtherTables", item);
                }

                //Step6 add in all documents
                foreach (var item in documents)
                {
                    item.FKProject = tblId;
                    _sql.SaveDataInTransaction("spCreateDocuments", item);
                }


                _sql.CommitTransaction();
            }
            catch
            {
                _logger.LogInformation("Insert Transaction of {DailyBibleReadingID} could not be inserted.", dailyBibleReading.Id);
                _sql.RollBackTransaction();
                throw;
            }

        }

        public async Task<DailyBibleReadingAll> GetParentAndAllChildrenRecordsAsync(int Id)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var dailyBibleReading = await _sql.LoadSingleObjectInTransaction<DailyBibleReading, dynamic>("spGetByIdDailyBibleReading", new { Id });
                //Step 2) Get Parent Key for all children tables
                var PKId = dailyBibleReading.PKIdtblDailyBibleReadings;
                //Step 3) Get all children table info: References

                var referencesList = await _sql.LoadDataInTransaction<References, dynamic>("spGetByFKReferences", new { FK = PKId });
                //Step 4) Get all children table info: Scriptures
                var scripturesList = await _sql.LoadDataInTransaction<Scriptures, dynamic>("spGetByFKScriptures", new { FK = PKId });
                //Step 5) Get all children table info: Tags to Other Tables
                var tagsToOtherTablesList = await _sql.LoadDataInTransaction<TagsToOtherTables, dynamic>("spGetByFKTagsToOtherScriptures", new { FK = PKId });
                //Step 6) Get all children documents
                var documentsList = await _sql.LoadDataInTransaction<Documents, dynamic>("spGetByFKDocuments", new { FK = PKId });

                _sql.CommitTransaction();

                //Build return model
                DailyBibleReadingAll dailyBibleReadingAll = new DailyBibleReadingAll
                {
                    Id = dailyBibleReading.Id,
                    DateRead = dailyBibleReading.DateRead,
                    LessonLearnedDescription = dailyBibleReading.LessonLearnedDescription,
                    PKIdtblDailyBibleReadings = dailyBibleReading.PKIdtblDailyBibleReadings,
                    ScriptureStartPoint = dailyBibleReading.ScriptureStartPoint,
                    ScriptureEndPoint = dailyBibleReading.ScriptureEndPoint,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    TagsToOtherTables = tagsToOtherTablesList,
                    DocumentsList= documentsList
                };
                return dailyBibleReadingAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Daily Bible Reading Record of {Id}.", Id);
                throw;
            }
        }
    }
}
