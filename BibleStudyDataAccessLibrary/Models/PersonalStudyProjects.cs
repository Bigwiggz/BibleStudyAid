﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class PersonalStudyProjects
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PersonalStudyTitle { get; set; }
        public string PersonalStudyDescription { get; set; }
        public string PersonalStudyQuestionAssignment { get; set; }
        public DateTime DateFinished { get; set; }
        public string BaseScripture { get; set; }
        public string PKIdtblPersonalStudyProjects { get; set; }    
        public bool IsDeleted { get; set; }
    }
}
