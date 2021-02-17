using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class DailyBibleReadingData: IGenericInterface<DailyBibleReading>
    {
        private readonly IConfiguration _config;


        public DailyBibleReadingData(IConfiguration config)
        {
            _config = config;

        }

        public async void InsertAsync(DailyBibleReading dailyBibleReading)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);


            await sql.SaveData<DailyBibleReading>("spCreateDailyBibleReading", dailyBibleReading);

        }

        public async void UpdateAsync(DailyBibleReading dailyBibleReading)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            await sql.SaveData<DailyBibleReading>("spUpdateDailyBibleReading", dailyBibleReading);
        }

        public async void DeleteAsync(object Id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p= new
            {
                Id = Id
            };

            await sql.SaveData("spDeleteDailyBibleReading", p);
        }

        public async Task<IEnumerable<DailyBibleReading>> GetAllAsync()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var result=await sql.LoadData<DailyBibleReading, dynamic>("spGetAllDailyBibleReading", new { });

            return result;
        }

        public async Task<DailyBibleReading> GetByIdAsync(object Id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p = new
            {
                Id = Id
            };

            var result = await sql.LoadSingleRecord<DailyBibleReading, dynamic>("spGetByIdDailyBibleReading", p);

            return result; 
        }

        public async void SaveFullDailyBibleReading(DailyBibleReading dailyBibleReading, 
            List<References> references, 
            List<Scriptures> scriptures,
            List<TagsToOtherTables> tagsToOtherTables)
        {
            //TODO: Make this SOLID/DRY/BETTER
            using(SqlDataAccess sql = new SqlDataAccess(_config))
            {
                try
                {
                    sql.StartTransaction("DBBibleStudyAid");

                    //Step 1: Save to Master Table dailyBibleReading
                    sql.SaveDataInTransaction<DailyBibleReading>("spCreateDailyBibleReading", dailyBibleReading);

                    //Step 2: Get the Id from the Master Table
                    string tblId=await sql.LoadSingleObjectInTransaction<string, dynamic>("spInsertDailyBibleReadingLookup", new { });

                    //Step 3: add Id to references and add in all references
                    foreach (var item in references)
                    {
                        item.FIKTableIdandName = tblId;
                        sql.SaveDataInTransaction("spCreateReferences", item);
                    }

                    //Step 4: add Id to all scriptures and add in all scriptures
                    foreach (var item in scriptures)
                    {
                        item.FKTableIdandName = tblId;
                        sql.SaveDataInTransaction("spCreateReferences", item);
                    }

                    //Step 5: add Id to all tagsToOtherTables
                    foreach (var item in tagsToOtherTables)
                    {
                        item.FKTableIdandName = tblId;
                        sql.SaveDataInTransaction("spCreateReferences", item);
                    }


                    sql.CommitTransaction();
                }
                catch
                {
                    sql.RollBackTransaction();
                    throw;
                }
            }

        }
    }
}
