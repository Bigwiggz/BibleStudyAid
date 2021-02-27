using BibleStudyDataAccessLibrary.GenericInterfaces;
using BibleStudyDataAccessLibrary.Internal;
using BibleStudyDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.DataAccess
{
    public class MeetingAssembliesData: IGenericInterface<MeetingAssemblies>
    {
        //TODO: Finish wiring up the ISqlDataAccess for Meeting Assemblies
        private readonly ISqlDataAccess _sql;

        public MeetingAssembliesData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void DeleteAsync(object Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MeetingAssemblies>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MeetingAssemblies> GetByIdAsync(object Id)
        {
            throw new NotImplementedException();
        }

        public void InsertAsync(MeetingAssemblies obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(MeetingAssemblies obj)
        {
            throw new NotImplementedException();
        }
    }
}
