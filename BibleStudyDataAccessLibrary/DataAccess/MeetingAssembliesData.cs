﻿using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class MeetingAssembliesData : IGenericInterface<MeetingAssemblies>, IMeetingAssembliesData
    {
        //TODO: Finish wiring up the ISqlDataAccess for Meeting Assemblies
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<MeetingAssemblies> _logger;

        public MeetingAssembliesData(ISqlDataAccess sql, ILogger<MeetingAssemblies> Logger)
        {
            _sql = sql;
            _logger = Logger;
        }

        public async void DeleteAsync(object Id)
        {
            await _sql.SaveData("spDeleteMeetingAssembliesData", Id);
            _logger.LogInformation("Family Study Project Record {Id} was deleted", Id);
        }

        public async Task<IEnumerable<MeetingAssemblies>> GetAllAsync()
        {
            var result = await _sql.LoadData<MeetingAssemblies, dynamic>("spGetAllMeetingAssemblies", new { });

            return result;
        }

        public async Task<MeetingAssemblies> GetByIdAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            var result = await _sql.LoadSingleRecord<MeetingAssemblies, dynamic>("spGetByIdMeetingAssemblies", p);

            return result;
        }

        public async void InsertAsync(MeetingAssemblies obj)
        {
            var p = new
            {
                LessonLearnedDescription = obj.LessonLearnedDescription,
                MeetingTypeId = obj.MeetingTypeId,
                PartTitle = obj.PartTitle,
                Scripture = obj.Scripture,
                DateofMeeting = obj.DateofMeeting
            };

            await _sql.SaveData("spCreateMeetingAssemblies", p);
        }

        public async void UpdateAsync(MeetingAssemblies obj)
        {
            var p = new
            {
                LessonLearnedDescription = obj.LessonLearnedDescription,
                MeetingTypeId = obj.MeetingTypeId,
                PartTitle = obj.PartTitle,
                Scripture = obj.Scripture,
                DateofMeeting = obj.DateofMeeting
            };

            await _sql.SaveData("spUpdateMeetingAssemblies", p);
        }

        public async void SaveFullParentAndAllChildrenRecords(MeetingAssemblies meetingAssemblies,
        List<References> references,
        List<Scriptures> scriptures,
        List<TagsToOtherTables> tagsToOtherTables,
        List<Documents> documents)
        {
            //TODO: Make this SOLID/DRY/BETTER
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1: Save to Master Table MeetingAssemblies
                //Step 2: Get the Id from the Master Table
                string tblId = await _sql.LoadSingleObjectInTransaction<string, dynamic>("spCreateMeetingAssemblies", meetingAssemblies);


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
                _logger.LogInformation("Insert Transaction of {MeetingAssembliesID} could not be inserted.", meetingAssemblies.Id);
                _sql.RollBackTransaction();
                throw;
            }

        }

        public async Task<MeetingAssembliesAll> GetParentAndAllChildrenRecordsAsync(int Id)
        {
            try
            {

                //Step 1) Get Parent Record Info
                var meetingAssemblies = await _sql.LoadSingleObjectInTransaction<MeetingAssemblies, dynamic>("spGetByIdMeetingAssembliess", new { Id });
                //Step 2) Get Parent Key for all children tables
                var PKId = meetingAssemblies.PKldtblMeetingAssemblies;
                //Step 3) Get all children table info: References

                var referencesList = await _sql.LoadDataInTransaction<References, dynamic>("spGetByFKReferences", new { FK = PKId });
                //Step 4) Get all children table info: Scriptures
                var scripturesList = await _sql.LoadDataInTransaction<Scriptures, dynamic>("spGetByFKScriptures", new { FK = PKId });
                //Step 5) Get all children table info: Tags to Other Tables
                var tagsToOtherTablesList = await _sql.LoadDataInTransaction<TagsToOtherTables, dynamic>("spGetByFKTagsToOtherScriptures", new { FK = PKId });
                //Step 6) Get all children documents
                var documentsList = await _sql.LoadDataInTransaction<Documents, dynamic>("spGetByFKDocuments", new { FK = PKId });

                //Build return model
                MeetingAssembliesAll meetingAssembliesAll = new MeetingAssembliesAll
                {
                    Id = meetingAssemblies.Id,
                    LessonLearnedDescription = meetingAssemblies.LessonLearnedDescription,
                    MeetingTypeId = meetingAssemblies.MeetingTypeId,
                    PartTitle = meetingAssemblies.PartTitle,
                    PKldtblMeetingAssemblies = meetingAssemblies.PKldtblMeetingAssemblies,
                    Scripture = meetingAssemblies.Scripture,
                    CreatedDate = meetingAssemblies.CreatedDate,
                    DateofMeeting = meetingAssemblies.DateofMeeting,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    TagsToOtherTables = tagsToOtherTablesList,
                    DocumentsList = documentsList
                };
                return meetingAssembliesAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Daily Bible Reading Record of {Id}.", Id);
                throw;
            }
        }
    }
}
