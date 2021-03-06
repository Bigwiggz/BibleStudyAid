using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyBWAUI.Base.ScriptureSelectorBL.Models
{
    public class BibleCitation
    {
        public string BibleBook { get; set; }
        public string BibleChapter { get; set; }
        public string BibleVerse { get; set; }

        private string fullBibleCitation;
        public string FullBibleCitation 
        {
            get { return fullBibleCitation; } 
            set { fullBibleCitation = $"{BibleBook} {BibleChapter}:{BibleVerse}"; } 
        }
    }
}
