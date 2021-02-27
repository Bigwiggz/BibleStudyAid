using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyDataAccessLibrary.GenericInterfaces
{
    interface IChildTableInterface<T> where T: class
    {
        Task<IEnumerable<T>> GetByForeignKey(Object obj);
    }
}
