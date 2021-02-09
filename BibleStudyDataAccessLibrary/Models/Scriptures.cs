using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class Scriptures
    {
        public int Id { get; set; }
        public string Scripture { get; set; }
        public string UniqueId { get; set; }
        public string FKTableIdandName { get; set; }
    }
}
