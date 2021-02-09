using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class PersonalStudyFindings
    {
        public int Id { get; set; }
        public string Scripture { get; set; }
        public string Explanation { get; set; }
        public string FKldtblPeronalStudyFindings { get; set; }
        public int FKPersonalStudyProjectId { get; set; }
    }
}
