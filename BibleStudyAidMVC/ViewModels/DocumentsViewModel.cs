namespace BibleStudyAidMVC.ViewModels
{
    public class DocumentsViewModel
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
        public IFormFile Document { get; set; }
        public bool IsDeleted { get; set; }
    }
}
