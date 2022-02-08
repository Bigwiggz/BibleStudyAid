using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class SpiritualGems
    {
        public int Id { get; set; }
        public string BriefDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime DateUpdated { get; set; }
        public string PKIdtblSpiritualGems { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
