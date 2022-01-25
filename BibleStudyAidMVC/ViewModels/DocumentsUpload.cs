namespace BibleStudyAidMVC.ViewModels
{
    public class DocumentsUpload
    {
        public string FKTableIdandName { get; set; }
        public List<IFormFile> Document { get; set; }
    }
}
