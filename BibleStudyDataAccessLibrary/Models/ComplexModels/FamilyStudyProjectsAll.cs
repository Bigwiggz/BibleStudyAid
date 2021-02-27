using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models.ComplexModels
{
    public class FamilyStudyProjectsAll
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateWhenCreated { get; set; }
        public string FamilyStudyTitle { get; set; }
        public string FamilyStudyDescription { get; set; }
        public string FamilyStudyFindings { get; set; }
        public string PKIdtblFamilyStudyProjects { get; set; }
        public List<References> ReferencesList { get; set; }
        public List<Scriptures> ScripturesList { get; set; }
        public List<TagsToOtherTables> TagsToOtherTables { get; set; }
        public List<Documents> DocumentsList { get; set; }

    }
}
