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
    public class SpiritualGemsData : IGenericInterface<SpiritualGems>, ISpiritualGemsData
    {
        private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sql;
        private readonly ILogger<SpiritualGems> _logger;

        public SpiritualGemsData(IConfiguration config, ISqlDataAccess sql, ILogger<SpiritualGems> logger)
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

            var result = await _sql.SaveData<object, dynamic>("spDeleteSpiritualGems", p);
            return result;
        }

        public async Task<IEnumerable<SpiritualGems>> GetAllAsync()
        {
            var result = await _sql.LoadData<SpiritualGems, dynamic>("spGetAllSpiritualGems", new { });

            return result;
        }

        public async Task<SpiritualGems> GetByIdAsync(object Id)
        {
            var p = new
            {
                Id = Id
            };

            var result = await _sql.LoadSingleRecord<SpiritualGems, dynamic>("spGetByIdSpiritualGems", p);

            return result;
        }

        public async Task<object> InsertAsync(SpiritualGems obj)
        {
            var p = new
            {
                Id = obj.Id,
                BriefDescription = obj.BriefDescription,
                LongDescription = obj.LongDescription,
                IsDeleted = obj.IsDeleted
            };

            var result = await _sql.SaveData<object, dynamic>("spCreateSpiritualGems", p);

            return result;
        }

        public async Task<object> UpdateAsync(SpiritualGems obj)
        {
            var result = await _sql.SaveData<object, dynamic>("spUpdateSpiritualGems", obj);
            return result;
        }

        public async void SaveFullParentAndAllChildrenRecords(SpiritualGems spiritualGems,
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
                string tblId = await _sql.LoadSingleObjectInTransaction<string, dynamic>("spCreateSpiritualGems", spiritualGems);


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
                _logger.LogInformation("Insert Transaction of {SpiritualGemsID} could not be inserted.", spiritualGems.Id);
                _sql.RollBackTransaction();
                throw;
            }

        }

        public async Task<SpiritualGemsAll> GetParentAndAllChildrenRecordsAsync(int Id)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var spiritualGems = await _sql.LoadSingleObjectInTransaction<SpiritualGems, dynamic>("spGetByIdSpiritualGems", new { Id });
                //Step 2) Get Parent Key for all children tables
                var PKId = spiritualGems.PKIdtblSpiritualGems;
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
                SpiritualGemsAll spiritualGemsAll = new SpiritualGemsAll
                {
                    Id = spiritualGems.Id,
                    BriefDescription = spiritualGems.BriefDescription,
                    LongDescription = spiritualGems.LongDescription,
                    DateUpdated = spiritualGems.DateUpdated,
                    PKIdtblSpiritualGems = spiritualGems.PKIdtblSpiritualGems,
                    IsDeleted = spiritualGems.IsDeleted,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    Tags = tagsList,
                    DocumentsList = documentsList
                };
                return spiritualGemsAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Spiritual Gems Record of {Id}.", Id);
                throw;
            }
        }
    }
}
