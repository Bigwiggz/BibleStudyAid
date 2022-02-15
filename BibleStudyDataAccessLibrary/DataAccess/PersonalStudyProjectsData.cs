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
    public class PersonalStudyProjectsData : IGenericInterface<PersonalStudyProjects>, IPersonalStudyProjectsData
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
                PersonalStudyTitle = obj.PersonalStudyTitle,
                PersonalStudyDescription = obj.PersonalStudyDescription,
                PersonalStudyQuestionAssignment = obj.PersonalStudyQuestionAssignment,
                DateFinished = obj.DateFinished,
                BaseScripture = obj.BaseScripture,
                IsDeleted = obj.IsDeleted

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
            //TODO: Make this SOLID/DRY/BETTER
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1: Save to Master Table dailyBibleReading
                //Step 2: Get the Id from the Master Table
                string tblId = await _sql.LoadSingleObjectInTransaction<string, dynamic>("spCreatePersonalStudyProjects", personalStudyProjects);


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
                _logger.LogInformation("Insert Transaction of {PersonalStudyProjectsId} could not be inserted.", personalStudyProjects.Id);
                _sql.RollBackTransaction();
                throw;
            }
        }

        public async Task<PersonalStudyProjectsAll> GetParentAndAllChildrenRecordsAsync(int Id)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var personalStudyProjects = await _sql.LoadSingleObjectInTransaction<PersonalStudyProjects, dynamic>("spGetByIdPersonalStudyProjects", new { Id });
                //Step 2) Get Parent Key for all children tables
                var PKId = personalStudyProjects.PKIdtblPersonalStudyProjects;
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
                PersonalStudyProjectsAll personalStudyProjectsAll = new PersonalStudyProjectsAll
                {
                    Id = personalStudyProjects.Id,
                    CreatedDate = personalStudyProjects.CreatedDate,
                    PersonalStudyTitle = personalStudyProjects.PersonalStudyTitle,
                    PersonalStudyQuestionAssignment = personalStudyProjects.PersonalStudyQuestionAssignment,
                    DateFinished = personalStudyProjects.DateFinished,
                    BaseScripture = personalStudyProjects.BaseScripture,
                    PKIdtblPersonalStudyProjects = personalStudyProjects.PKIdtblPersonalStudyProjects,
                    IsDeleted = personalStudyProjects.IsDeleted,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    Tags = tagsList,
                    DocumentsList = documentsList
                };
                return personalStudyProjectsAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Personal Study Project Record of {Id}.", Id);
                throw;
            }
        }

        public async Task<PersonalStudyProjectsAll> GetParentAndAllChildrenRecordsByForeignKeyAsync(string FK)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var personalStudyProjects = await _sql.LoadSingleObjectInTransaction<PersonalStudyProjects, dynamic>("spGetByFKPersonalStudyProjects", new { PKIdtblPersonalStudyProjects = FK });
                //Step 2) Get Parent Key for all children tables
                var PKId = personalStudyProjects.PKIdtblPersonalStudyProjects;
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
                PersonalStudyProjectsAll personalStudyProjectsAll = new PersonalStudyProjectsAll
                {
                    Id = personalStudyProjects.Id,
                    CreatedDate = personalStudyProjects.CreatedDate,
                    PersonalStudyTitle = personalStudyProjects.PersonalStudyTitle,
                    PersonalStudyQuestionAssignment = personalStudyProjects.PersonalStudyQuestionAssignment,
                    DateFinished = personalStudyProjects.DateFinished,
                    BaseScripture = personalStudyProjects.BaseScripture,
                    PKIdtblPersonalStudyProjects = personalStudyProjects.PKIdtblPersonalStudyProjects,
                    IsDeleted = personalStudyProjects.IsDeleted,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    Tags = tagsList,
                    DocumentsList = documentsList
                };
                return personalStudyProjectsAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Personal Study Project Record of {ForeignKey}.", FK);
                throw;
            }
        }
    }
}
