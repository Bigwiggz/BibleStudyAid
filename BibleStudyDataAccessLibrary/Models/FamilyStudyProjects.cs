using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class FamilyStudyProjects
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateWhenCreated { get; set; }
        public string FamilyStudyTitle { get; set; }
        public string FamilyStudyDescription { get; set; }
        public string FamilyStudyFindings { get; set; }
        public string PKIdtblFamilyStudyProjects { get; set; }
        public bool IsDeleted { get; set; }
    }
}
