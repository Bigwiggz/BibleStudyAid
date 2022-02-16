using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models.HelperModels
{
    public class TopLevelTablesSelector
    {
        public int? Id { get; set; }
        public string ControllerName { get; set; }
        public object ReturnedObject { get; set; }
    }
}
