using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.DTOs
{
    public class MeetingAssembliesDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateofMeeting { get; set; }
        public string PartTitle { get; set; }
        public int MeetingTypeId { get; set; }
        public string Scripture { get; set; }
        public string LessonLearnedDescription { get; set; }
        public string PKldtblMeetingAssemblies { get; set; }
    }
}
