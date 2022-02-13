using System;
using System.Collections.Generic;
using System.Text;
using BibleStudyDataAccessLibrary.Models.Enums;

namespace BibleStudyDataAccessLibrary.Models
{
    public class Talks
    {
        public int Id { get; set; }
        public string TalkTitle { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateGiven { get; set; }
        public BibleStudyDataAccessLibrary.Models.Enums.MeetingType MeetingType { get; set; }
        public string Description { get; set; }
        public string TalkDocumentName { get; set; }
        public string ThemeScripture { get; set; }
        public string PKIdtblTalks { get; set; }
        public bool IsDeleted { get; set; }
    }
}
