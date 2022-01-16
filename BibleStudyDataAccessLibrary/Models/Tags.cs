using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public DateTime TagCreatedDate { get;}
        public bool IsDeleted { get; set; }
    }
}
