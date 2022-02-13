using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class References
    {
        public int Id { get; set; }
        public string FKTableIdandName { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
