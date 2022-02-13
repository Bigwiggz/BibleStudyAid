
using BibleStudyDataAccessLibrary.Models.Enums;

namespace BibleStudyAidMVC.ViewModels
{
    public class TalksViewModel
    {
        public int Id { get; set; }
        public string TalkTitle { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateGiven { get; set; }
        public MeetingType MeetingType { get; set; }
        public string Description { get; set; }
        public string ThemeScripture { get; set; }
        public string PKIdtblTalks { get; set; }
        public bool IsDeleted { get; set; }
    }
}
