using BibleStudyDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyAidBusinessLogic.Models
{
    public class AllDashboardItems
    {
        public List<DailyBibleReading> DailyBibleReadingList { get; set; }
        public List<FamilyStudyProjects> FamilyStudyProjectsList { get;set; }
        public List<MeetingsAssemblies> MeetingsAssembliesList { get; set; }
        public List<SpiritualGems> SpiritualGemsList {get; set; }
        public List<Tags> TagsList { get; set; }
        public List<Talks> TalksList { get; set; } 

        public List<Documents> DocumentsList { get; set; }
        public List<References> ReferencesList { get; set; }
        public List<Scriptures> ScripturesList { get; set; }
        public List<WorldMapItem> WorldMapItemList { get; set; }

        public List<TimeEntry> TimeEntryProjectsList { get; set; }
        public List<TimeEntry> TimeChildEntryList { get;set; }
    }
}
