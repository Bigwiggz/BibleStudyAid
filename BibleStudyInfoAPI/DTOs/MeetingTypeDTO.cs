using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.DTOs
{
    public class MeetingTypeDTO
    {
        public int Id { get; set; }
        public string MeetingTypeName { get; set; }
        public string MeetingTypeDescription { get; set; }
    }
}
