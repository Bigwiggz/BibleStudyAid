using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyAidBusinessLogic.Models
{
    public class TimeEntry
    {
        public DateTime DateOfRecord { get; set; }
        public string RecordType { get; set; }
        public string RecordDescription { get; set; }
    }
}
