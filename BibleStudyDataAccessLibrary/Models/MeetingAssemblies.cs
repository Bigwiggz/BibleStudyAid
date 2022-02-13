using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class MeetingAssemblies
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateofMeeting { get; set; }
        public string PartTitle { get; set; }
        public MeetingType MeetingType { get; set; }
        public string Scripture { get; set; }
        public string LessonLearnedDescription { get; set; }
        public string PKldtblMeetingAssemblies { get; set; }
        public bool IsDeleted { get; set; }
    }
}
