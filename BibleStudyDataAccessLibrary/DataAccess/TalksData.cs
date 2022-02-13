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
    public class TalksData : IGenericInterface<Talks>, ITalksData
    {
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<Talks> _logger;

        public TalksData(ISqlDataAccess sql, ILogger<Talks> logger)
        {
            _sql = sql;
            _logger = logger;
        }

        public async Task<object> DeleteAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            var result = await _sql.SaveData<object, dynamic>("spDeleteTalk", p);
            return result;
        }

        public async Task<IEnumerable<Talks>> GetAllAsync()
        {
            var result = await _sql.LoadData<Talks, dynamic>("spGetAllTalks", new { });

            return result;
        }

        public async Task<Talks> GetByIdAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            var result = await _sql.LoadSingleRecord<Talks, dynamic>("spGetByIdTalks", p);

            return result;
        }

        public async Task<object> InsertAsync(Talks obj)
        {
            var p = new
            {
                TalkTitle = obj.TalkTitle,
                DateGiven = obj.DateGiven,
                MeetingType = obj.MeetingType,
                Description = obj.Description,
                ThemeScripture = obj.ThemeScripture,
                IsDeleted = obj.IsDeleted
            };

            var result = await _sql.SaveData<object, dynamic>("spCreateTalk", p);

            return result;
        }

        public async Task<object> UpdateAsync(Talks obj)
        {
            var result = await _sql.SaveData<object, dynamic>("spUpdateTalks", obj);
            return result;
        }

        public async void SaveFullParentAndAllChildrenRecords(Talks talks,
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
                string tblId = await _sql.LoadSingleObjectInTransaction<string, dynamic>("spCreateTalks", talks);


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
                _logger.LogInformation("Insert Transaction of {TalksID} could not be inserted.", talks.Id);
                _sql.RollBackTransaction();
                throw;
            }

        }

        public async Task<TalksAll> GetParentAndAllChildrenRecordsAsync(int Id)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var talks = await _sql.LoadSingleObjectInTransaction<Talks, dynamic>("spGetByIdTalks", new { Id });
                //Step 2) Get Parent Key for all children tables
                var PKId = talks.PKIdtblTalks;
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
                TalksAll talksAll = new TalksAll
                {
                    Id = talks.Id,
                    TalkTitle = talks.TalkTitle,
                    CreatedDate = talks.CreatedDate,
                    DateGiven = talks.DateGiven,
                    Description = talks.Description,
                    ThemeScripture = talks.ThemeScripture,
                    PKIdtblTalks = talks.PKIdtblTalks,
                    IsDeleted = talks.IsDeleted,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    Tags = tagsList,
                    DocumentsList = documentsList
                };
                return talksAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Talks Record of {Id}.", Id);
                throw;
            }
        }
    }
}
