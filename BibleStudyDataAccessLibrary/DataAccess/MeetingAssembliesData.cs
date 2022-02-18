using BibleStudyDataAccessLibrary.GenericInterfaces;
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
    public class MeetingsAssembliesData : IGenericInterface<MeetingsAssemblies>, IMeetingsAssembliesData
    {
        //TODO: Finish wiring up the ISqlDataAccess for Meeting Assemblies
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<MeetingsAssemblies> _logger;

        public MeetingsAssembliesData(ISqlDataAccess sql, ILogger<MeetingsAssemblies> Logger)
        {
            _sql = sql;
            _logger = Logger;
        }

        public async Task<object> DeleteAsync(object Id)
        {
            var result=await _sql.SaveData<object,dynamic>("spDeleteMeetingsAssembliesData", Id);
            _logger.LogInformation("Family Study Project Record {Id} was deleted", Id);
            return result;
        }

        public async Task<IEnumerable<MeetingsAssemblies>> GetAllAsync()
        {
            var result = await _sql.LoadData<MeetingsAssemblies, dynamic>("spGetAllMeetingsAssemblies", new { });

            return result;
        }

        public async Task<MeetingsAssemblies> GetByIdAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            var result = await _sql.LoadSingleRecord<MeetingsAssemblies, dynamic>("spGetByIdMeetingsAssemblies", p);

            return result;
        }

        public async Task<object> InsertAsync(MeetingsAssemblies obj)
        {
            var p = new
            {
                LessonLearnedDescription = obj.LessonLearnedDescription,
                MeetingType = obj.MeetingType,
                PartTitle = obj.PartTitle,
                Scripture = obj.Scripture,
                DateofMeeting = obj.DateofMeeting,
                IsDeleted=obj.IsDeleted
            };

            var result=await _sql.SaveData<object,dynamic>("spCreateMeetingsAssemblies", p);
            return result;
        }

        public async Task<object>UpdateAsync(MeetingsAssemblies obj)
        {
            var p = new
            {
                Id=obj.Id,
                LessonLearnedDescription = obj.LessonLearnedDescription,
                MeetingType = obj.MeetingType,
                PartTitle = obj.PartTitle,
                Scripture = obj.Scripture,
                DateofMeeting = obj.DateofMeeting,
                IsDeleted = obj.IsDeleted
            };

            var result=await _sql.SaveData<object,dynamic>("spUpdateMeetingsAssemblies", p);
            return result;
        }

        public async void SaveFullParentAndAllChildrenRecords(MeetingsAssemblies MeetingsAssemblies,
        List<References> references,
        List<Scriptures> scriptures,
        List<TagsToOtherTables> tagsToOtherTables,
        List<Documents> documents)
        {
            //TODO: Make this SOLID/DRY/BETTER
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1: Save to Master Table MeetingsAssemblies
                //Step 2: Get the Id from the Master Table
                string tblId = await _sql.LoadSingleObjectInTransaction<string, dynamic>("spCreateMeetingsAssemblies", MeetingsAssemblies);


                //Step 3: add Id to references and add in all references
                foreach (var item in references)
                {
                    item.FKTableIdandName = tblId;
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
                    item.FKTableIdandName = tblId;
                    _sql.SaveDataInTransaction("spCreateDocuments", item);
                }


                _sql.CommitTransaction();
            }
            catch
            {
                _logger.LogInformation("Insert Transaction of {MeetingsAssembliesID} could not be inserted.", MeetingsAssemblies.Id);
                _sql.RollBackTransaction();
                throw;
            }

        }

        public async Task<MeetingsAssembliesAll> GetParentAndAllChildrenRecordsAsync(int Id)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var MeetingsAssemblies = await _sql.LoadSingleObjectInTransaction<MeetingsAssemblies, dynamic>("spGetByIdMeetingsAssemblies", new { Id });
                //Step 2) Get Parent Key for all children tables
                var PKId = MeetingsAssemblies.PKldtblMeetingsAssemblies;
                //Step 3) Get all children table info: References

                var referencesList = await _sql.LoadDataInTransaction<References, dynamic>("spGetByFKReferences", new { FK = PKId });
                //Step 4) Get all children table info: Scriptures
                var scripturesList = await _sql.LoadDataInTransaction<Scriptures, dynamic>("spGetByFKScriptures", new { FK = PKId });
                //Step 5) Get all children table info: Tags to Other Tables
                var tagsList = await _sql.LoadDataInTransaction<Tags, dynamic>("spGetByFKTags", new { FK = PKId });
                //Step 6) Get all children documents
                var documentsList = await _sql.LoadDataInTransaction<Documents, dynamic>("spGetByFKDocuments", new { FK = PKId });

                _sql.CommitTransaction();

                //Build return model
                MeetingsAssembliesAll MeetingsAssembliesAll = new MeetingsAssembliesAll
                {
                    Id = MeetingsAssemblies.Id,
                    LessonLearnedDescription = MeetingsAssemblies.LessonLearnedDescription,
                    MeetingType = MeetingsAssemblies.MeetingType,
                    PartTitle = MeetingsAssemblies.PartTitle,
                    PKldtblMeetingsAssemblies = MeetingsAssemblies.PKldtblMeetingsAssemblies,
                    Scripture = MeetingsAssemblies.Scripture,
                    CreatedDate = MeetingsAssemblies.CreatedDate,
                    DateofMeeting = MeetingsAssemblies.DateofMeeting,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    Tags = tagsList,
                    DocumentsList = documentsList
                };
                return MeetingsAssembliesAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Daily Bible Reading Record of {Id}.", Id);
                throw;
            }
        }

        public async Task<MeetingsAssembliesAll> GetParentAndAllChildrenRecordsByForeignKeyAsync(string FK)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var MeetingsAssemblies = await _sql.LoadSingleObjectInTransaction<MeetingsAssemblies, dynamic>("spGetByFKMeetingsAssemblies", new { PKldtblMeetingsAssemblies=FK });
                //Step 2) Get Parent Key for all children tables
                var PKId = MeetingsAssemblies.PKldtblMeetingsAssemblies;
                //Step 3) Get all children table info: References

                var referencesList = await _sql.LoadDataInTransaction<References, dynamic>("spGetByFKReferences", new { FK = PKId });
                //Step 4) Get all children table info: Scriptures
                var scripturesList = await _sql.LoadDataInTransaction<Scriptures, dynamic>("spGetByFKScriptures", new { FK = PKId });
                //Step 5) Get all children table info: Tags to Other Tables
                var tagsList = await _sql.LoadDataInTransaction<Tags, dynamic>("spGetByFKTags", new { FK = PKId });
                //Step 6) Get all children documents
                var documentsList = await _sql.LoadDataInTransaction<Documents, dynamic>("spGetByFKDocuments", new { FK = PKId });

                _sql.CommitTransaction();

                //Build return model
                MeetingsAssembliesAll MeetingsAssembliesAll = new MeetingsAssembliesAll
                {
                    Id = MeetingsAssemblies.Id,
                    LessonLearnedDescription = MeetingsAssemblies.LessonLearnedDescription,
                    MeetingType = MeetingsAssemblies.MeetingType,
                    PartTitle = MeetingsAssemblies.PartTitle,
                    PKldtblMeetingsAssemblies = MeetingsAssemblies.PKldtblMeetingsAssemblies,
                    Scripture = MeetingsAssemblies.Scripture,
                    CreatedDate = MeetingsAssemblies.CreatedDate,
                    DateofMeeting = MeetingsAssemblies.DateofMeeting,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    Tags = tagsList,
                    DocumentsList = documentsList
                };
                return MeetingsAssembliesAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Daily Bible Reading Record of {ForeignKey}.", FK);
                throw;
            }
        }
    }
}
