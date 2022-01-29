using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class TagsToOtherTables
    {
        public int Id { get; set; }
        public int TagsId { get; set; }
        public string FKTableIdandName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
