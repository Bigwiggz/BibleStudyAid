using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models.ComplexModels
{
    public class SpiritualGemsAll:SpiritualGems
    {
        public List<References> ReferencesList { get; set; }
        public List<Scriptures> ScripturesList { get; set; }
        public List<Tags> Tags { get; set; }
        public List<Documents> DocumentsList { get; set; }
    }
}
