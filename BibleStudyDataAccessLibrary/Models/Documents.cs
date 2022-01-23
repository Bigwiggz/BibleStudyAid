using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public string FKTableIdandName { get; set; }
        public string ContentType { get; set; }
        public string ContentDisposition { get; set; }
        public long ContentSize { get; set; }
        public string UniqueFileName { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public Guid UniqueGUIDId { get; set; }
        public DateTime DateUploaded { get; set; }
        public string DocumentDescription { get; set; }
        public bool IsDeleted { get; set; }
    }
}
