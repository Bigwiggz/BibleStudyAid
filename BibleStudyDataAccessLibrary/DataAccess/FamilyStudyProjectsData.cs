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
    public class FamilyStudyProjectsData : IGenericInterface<FamilyStudyProjects>, IFamilyStudyProjectsData
    {

        private readonly ISqlDataAccess _sql;
        private readonly ILogger<FamilyStudyProjectsData> _logger;

        public FamilyStudyProjectsData( ISqlDataAccess sql, ILogger<FamilyStudyProjectsData> logger)
        {

            _sql = sql;
            _logger = logger;
        }

        public async Task<object> DeleteAsync(object Id)
        {
            var result=await _sql.SaveData<object,dynamic>("spDeleteFamilyStudyProjectsData", Id);
            _logger.LogInformation("Family Study Project Record {Id} was deleted", Id);
            return result;

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

        public async Task<object> InsertAsync(FamilyStudyProjects obj)
        {
            var p = new
            {
                FamilyStudyDescription = obj.FamilyStudyDescription,
                FamilyStudyFindings = obj.FamilyStudyFindings,
                DateWhenCreated = obj.DateWhenCreated,
                FamilyStudyTitle = obj.FamilyStudyTitle,
                IsDeleted=obj.IsDeleted
            };

            var result=await _sql.SaveData<object,dynamic>("spCreateFamilyStudyProjects", p);
            return result;
        }

        public async Task<object>UpdateAsync(FamilyStudyProjects obj)
        {
            var p = new
            {
                Id = obj.Id,
                FamilyStudyDescription = obj.FamilyStudyDescription,
                FamilyStudyFindings = obj.FamilyStudyFindings,
                DateWhenCreated = obj.DateWhenCreated,
                FamilyStudyTitle = obj.FamilyStudyTitle,
                IsDeleted = obj.IsDeleted
            };

            var result=await _sql.SaveData<object,dynamic>("spUpdateFamilyStudyProjects", p);
            return result;
        }

        public async void SaveFullParentAndAllChildrenRecords(
            FamilyStudyProjects familyStudyProjects, 
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
                string tblId = await _sql.LoadSingleObjectInTransaction<string, dynamic>("spCreateFamilyStudyProjects", familyStudyProjects);


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
                _logger.LogInformation("Insert Transaction of {FamilyStudyProjectsID} could not be inserted.", familyStudyProjects.Id);
                _sql.RollBackTransaction();
                throw;
            }

        }

        public async Task<FamilyStudyProjectsAll> GetParentAndAllChildrenRecordsAsync(int Id)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var familyStudyProjects = await _sql.LoadSingleObjectInTransaction<FamilyStudyProjects, dynamic>("spGetByIdFamilyStudyProjects", new { Id });
                //Step 2) Get Parent Key for all children tables
                var PKId = familyStudyProjects.PKIdtblFamilyStudyProjects;
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
                FamilyStudyProjectsAll familyStudyProjectsAll = new FamilyStudyProjectsAll
                {
                    Id = familyStudyProjects.Id,
                    DateCreated=familyStudyProjects.DateCreated,
                    DateWhenCreated=familyStudyProjects.DateWhenCreated,
                    FamilyStudyTitle=familyStudyProjects.FamilyStudyTitle,
                    FamilyStudyDescription=familyStudyProjects.FamilyStudyDescription,
                    FamilyStudyFindings=familyStudyProjects.FamilyStudyFindings,
                    PKIdtblFamilyStudyProjects=familyStudyProjects.PKIdtblFamilyStudyProjects,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    Tags = tagsList,
                    DocumentsList= documentsList
                };
                return familyStudyProjectsAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Family Study Prjects Record of {Id}.", Id);
                throw;
            }
        }

        public async Task<FamilyStudyProjectsAll> GetParentAndAllChildrenRecordsByForeignKeyAsync(string FK)
        {
            try
            {
                _sql.StartTransaction("DBBibleStudyAid");

                //Step 1) Get Parent Record Info
                var familyStudyProjects = await _sql.LoadSingleObjectInTransaction<FamilyStudyProjects, dynamic>("spGetByFKFamilyStudyProjects", new { PKIdtblFamilyStudyProjects=FK });
                //Step 2) Get Parent Key for all children tables
                var PKId = familyStudyProjects.PKIdtblFamilyStudyProjects;
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
                FamilyStudyProjectsAll familyStudyProjectsAll = new FamilyStudyProjectsAll
                {
                    Id = familyStudyProjects.Id,
                    DateCreated = familyStudyProjects.DateCreated,
                    DateWhenCreated = familyStudyProjects.DateWhenCreated,
                    FamilyStudyTitle = familyStudyProjects.FamilyStudyTitle,
                    FamilyStudyDescription = familyStudyProjects.FamilyStudyDescription,
                    FamilyStudyFindings = familyStudyProjects.FamilyStudyFindings,
                    PKIdtblFamilyStudyProjects = familyStudyProjects.PKIdtblFamilyStudyProjects,
                    ReferencesList = referencesList,
                    ScripturesList = scripturesList,
                    Tags = tagsList,
                    DocumentsList = documentsList
                };
                return familyStudyProjectsAll;
            }
            catch
            {
                _logger.LogInformation("Unable to retreive full record of Family Study Prjects Record of {ForeignKey}.", FK);
                throw;
            }
        }
    }
}
