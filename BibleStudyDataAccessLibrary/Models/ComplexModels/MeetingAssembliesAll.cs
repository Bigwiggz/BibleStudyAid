using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models.ComplexModels
{
    public class MeetingAssembliesAll
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateofMeeting { get; set; }
        public string PartTitle { get; set; }
        public int MeetingTypeId { get; set; }
        public string Scripture { get; set; }
        public string LessonLearnedDescription { get; set; }
        public string PKldtblMeetingAssemblies { get; set; }
        public List<References> ReferencesList { get; set; }
        public List<Scriptures> ScripturesList { get; set; }
        public List<TagsToOtherTables> TagsToOtherTables { get; set; }
        public List<Documents> DocumentsList { get; set; }

    }
}
