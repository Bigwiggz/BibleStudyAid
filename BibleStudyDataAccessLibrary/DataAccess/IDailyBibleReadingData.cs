﻿using BibleStudyDataAccessLibrary.Models;
using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public interface IDailyBibleReadingData
    {
        void DeleteAsync(object Id);
        Task<IEnumerable<DailyBibleReading>> GetAllAsync();
        Task<DailyBibleReading> GetByIdAsync(object Id);
        Task<DailyBibleReadingAll> GetParentAndAllChildrenRecordsAsync(int Id);
        void InsertAsync(DailyBibleReading dailyBibleReading);
        void SaveFullParentAndAllChildrenRecords(DailyBibleReading dailyBibleReading, List<References> references, List<Scriptures> scriptures, List<TagsToOtherTables> tagsToOtherTables, List<Documents> documents);
        void UpdateAsync(DailyBibleReading dailyBibleReading);
    }
}