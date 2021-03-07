using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyBWAUI.Base.ScriptureSelectorBL.Models
{
    public class BibleCitation
    {
        public string BibleBook { get; set; }
        public int? BibleChapter { get; set; }
        public int? BibleVerse { get; set; }
        public string FullBibleCitation 
        {
            get { return $"{BibleBook} {BibleChapter}:{BibleVerse}"; } 
        }
    }
}
