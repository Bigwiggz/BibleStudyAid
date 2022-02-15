using BibleStudyDataAccessLibrary.Models.ComplexModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.GenericInterfaces
{
    public interface IMasterTableInterface<T> where T: class
    {
        Task<T> GetParentAndAllChildrenRecordsAsync(int Id);
        Task<PersonalStudyProjectsAll> GetParentAndAllChildrenRecordsByForeignKeyAsync(string FK);
    }
}
