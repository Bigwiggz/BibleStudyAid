﻿using BibleStudyDataAccessLibrary.Models;

namespace BibleStudyAidMVC.ViewModels
{
    public class DailyBibleReadingAllViewModel
    {
        public int Id { get; set; }
        public DateTime DateTimeWhenDone { get; }
        public string ScriptureStartPoint { get; set; }
        public string ScriptureEndPoint { get; set; }
        public string LessonLearnedDescription { get; set; }
        public DateTime DateRead { get; set; }
        public string PKIdtblDailyBibleReadings { get; set; }
        public List<References> ReferencesList { get; set; }
        public List<Scriptures> ScripturesList { get; set; }
        public List<Tags> Tags { get; set; }
        public List<Documents> DocumentsList { get; set; }
        public List<IFormFile> DocumentFiles { get; set; }
        public string BibleText { get; set; }
    }
}
