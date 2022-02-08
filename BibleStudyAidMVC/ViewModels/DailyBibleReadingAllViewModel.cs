﻿using BibleStudyDataAccessLibrary.Models;

namespace BibleStudyAidMVC.ViewModels
{
    public class DailyBibleReadingAllViewModel:DailyBibleReadingViewModel
    {
        public List<References> ReferencesList { get; set; }
        public List<Scriptures> ScripturesList { get; set; }
        public List<Tags> Tags { get; set; }
        public List<Documents> DocumentsList { get; set; }
        public List<IFormFile> DocumentFiles { get; set; }
        public string BibleText { get; set; }
    }
}
