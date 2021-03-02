using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyBWAUI.ViewModels
{
    public class DailyBibleReadingViewModel
    {
        public int Id { get; set; }
        public DateTime DateTimeWhenDone { get; }
        public string ScriptureStartPoint { get; set; }
        public string ScriptureEndPoint { get; set; }
        public string LessonLearnedDescription { get; set; }
        public DateTime DateRead { get; set; }
        public string PKIdtblDailyBibleReadings { get; set; }
    }
}
