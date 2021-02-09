using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class Talks
    {
        public int Id { get; set; }
        public string TalkTitle { get; set; }
        public DateTime CreatedDate { get;}
        public DateTime DateGiven { get; set; }
        public int MeetingTypeId { get; set; }
        public string Description { get; set; }
        public byte[] TalkDocument { get; set; }
        public string ThemeScripture { get; set; }
        public string PKldtblTalks { get;}
    }
}
