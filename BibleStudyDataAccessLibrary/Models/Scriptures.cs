using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class Scriptures
    {
        public int Id { get; set; }
        public string Scripture { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }
        public Guid UniqueId { get; set; }
        public string FKTableIdandName { get; set; }
        public DateTime DateUpdated { get; set; }   
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
