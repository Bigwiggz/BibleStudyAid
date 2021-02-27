using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.DTOs
{
    public class DocumentsDTO
    {
        public int Id { get; set; }
        public string FKProject { get; set; }
        public string DocumentName { get; set; }
        public byte[] Document { get; set; }
        public DateTime DateUploaded { get; set; }
        public string DocumentType { get; set; }
    }
}
