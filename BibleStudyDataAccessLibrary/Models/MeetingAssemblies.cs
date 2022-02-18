using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class MeetingsAssemblies
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateofMeeting { get; set; }
        public string PartTitle { get; set; }
        public MeetingType MeetingType { get; set; }
        public string Scripture { get; set; }
        public string LessonLearnedDescription { get; set; }
        public string PKldtblMeetingsAssemblies { get; set; }
        public bool IsDeleted { get; set; }
    }
}
