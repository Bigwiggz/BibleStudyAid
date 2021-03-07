using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyBWAUI.ViewModels
{
    public class ScripturesViewModel
    {
        public int Id { get; set; }
        public string Scripture { get; set; }
        public string UniqueId { get; set; }
        public string FKTableIdandName { get; set; }
    }
}
