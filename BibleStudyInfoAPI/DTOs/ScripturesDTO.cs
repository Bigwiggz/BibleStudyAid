using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.DTOs
{
    public class ScripturesDTO
    {
        public int Id { get; set; }
        public string Scripture { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }
        public string UniqueId { get; set; }
        public string FKTableIdandName { get; set; }
    }
}
