﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class TagsToOtherTables
    {
        public int Id { get; set; }
        public int TagsId { get; set; }
        public int tblId { get; set; }
        public string tblName { get; set; }
        public string FKTableIdandName { get; set; }
    }
}
